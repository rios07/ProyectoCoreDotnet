using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using _DatosDelSistema;
using Dapper;
using FuncionesCore;
using ModelosCore;
using ModelosCore.CustomAnnotations;

namespace RepositoriosCore.Base
{
    #region Definición de Parámetros

    public class ABMParams
    {
        public string sResSQL { get; set; } = "";
        public DateTime fechaDeEjecucion { get; set; } = FechasYHoras.FechaYTiempoAhora(); // Debería ser un null.
    }

    public class BaseParams
    {
        public string sResSQL { get; set; } = "";
    }

    public class ListParams
    {
        public string ordenarPor { get; set; } = "";
        public bool sentido { get; set; } = true;

        public string filtro { get; set; } = "";

        //public bool activo { get; set; } = true;
        public int RegistrosPorPagina { get; set; } = -1;
        public int NumeroDePagina { get; set; } = 0;
        public int TotalDeRegistros { get; set; } = 0;
        public DateTime FechaDeEjecucion { get; set; } = FechasYHoras.FechaYTiempoAhora();
    }

    #endregion

    /// <summary>
    ///     Interfaz que van a implementar las interfaces de los repositorios particulares para exponer sus métodos
    /// </summary>
    /// <typeparam name="Modelo"></typeparam>
    /// <typeparam name="ModeloExt"></typeparam>
    public interface IRepositorio<Modelo, ModeloExt> where Modelo : BaseModelo where ModeloExt : Modelo
    {
        bool Delete(int pId, ref ControllerBag pControllerBag);
        int Insert(Modelo pObj, ref ControllerBag pControllerBag);
        int InsertByIdString(Modelo pObj, string pCampoIdString, ref ControllerBag pControllerBag);
        IEnumerable<ModeloExt> Listado(ref ControllerBag pControllerBag);

        IEnumerable<ModeloExt> Listado(Dictionary<string, string> filtros, ref ListParams pListParams,
            ref ControllerBag pControllerBag);

        IEnumerable<ModeloExt> ListadoDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId);

        IEnumerable<ModeloExt> ListadoDDLAnonimo(ref ControllerBag pControllerBag, bool? pActivo, int pId,
            string pContexto);

        bool PrecargaInicialDeUnaPagina(Operacion pOp, ref ControllerBag pControllerBag);
        ModeloExt Registro(int pId, ref ControllerBag pControllerBag);
        void SetDatosDeLogin(DatosDeLogin pDatosDeLogin);
        DatosDeLogin GetDatosDeLogin();
        int Update(Modelo pObj, ref ControllerBag pControllerBag);
    }

    /// <summary>
    ///     repositorio base del cual heredan todos, maneja el acceso a la base de datos de forma genérica
    /// </summary>
    /// <typeparam name="Modelo"></typeparam>
    /// <typeparam name="ModeloExt"></typeparam>
    public abstract class BaseRepositorios<Modelo, ModeloExt> : IRepositorio<Modelo, ModeloExt>
        where Modelo : BaseModelo, new() where ModeloExt : Modelo
    {
        protected DatosDeLogin _datosDeLogin;
        private DateTime _fechaDeEjecucion;
        private readonly IConexion _miConexion;


        private readonly bool
            _nuevaVersion =
                true; //Para mantener las soluciones viejas donde no es obligatorio poner false. Al solucionar borrar


        public BaseRepositorios(IConexion pMiConexion)
        {
            _miConexion = pMiConexion;
            _datosDeLogin = new DatosDeLogin();
            _fechaDeEjecucion = FechasYHoras.FechaYTiempoAhora(); // Todo se controla con esta.
        }


        #region Precarga Inicial De Una Página

        public virtual bool PrecargaInicialDeUnaPagina(Operacion pOp, ref ControllerBag pControllerBag)
        {
            var sResSQL = "";
            var m = new Modelo();
            DatosDeUnaPagina obj = null;

            var parametros = new DynamicParameters();
            parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
            parametros.Add("fechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
            parametros.Add("Tabla", m.GetType().Name);
            parametros.Add("FuncionDePagina", pOp.ToString());
            parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);

            if (_nuevaVersion)
                parametros.Add("Seccion", pControllerBag.Seccion);
            //parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
            //parametros.Add("Token", pControllerBag.Token);
            else
                AgregarSeccion(ref parametros, ref pControllerBag, m);


            parametros.Add("FuncionDePagina", pOp.ToString());


            using (IDbConnection db = _miConexion.GetConexion())
            {
                obj = db.Query<DatosDeUnaPagina>(
                        "usp_Paginas__PermisosDePrecargaInicial", //usp_Paginas__PermisosDePrecargaInicial usp_PrecargaInicialDeUnaPagina
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .SingleOrDefault();
            }

            sResSQL = parametros.Get<string>("sResSQL");
            pControllerBag.DatosDeUnaPagina = obj;
            pControllerBag.Add(sResSQL);

            return true;
        }

        #endregion


        #region Login

        public void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            _datosDeLogin = pDatosDeLogin;
        }

        #endregion

        public DatosDeLogin GetDatosDeLogin()
        {
            return _datosDeLogin;
        }


        #region Manejo de los retornos de SQL

        public bool RetornoSQL(Operacion op, int cantidad, string sResSQL, ref ControllerBag pControllerBag)
        {
            var plural = "";
            if (cantidad > 1) plural = "s";
            var operacion = "";
            //throw new Exception();
            if (sResSQL == "") return true;

            pControllerBag.Add(sResSQL, true);
            return false;
        }

        #endregion

        public void AgregarSeccion(ref DynamicParameters pParams, ref ControllerBag pControllerBag, Modelo pObj)
        {
            if (!pObj.GetType().GetCustomAttributes(typeof(SinSeccion), false).Any())
                if (pControllerBag.Seccion != null)
                    pParams.Add("Seccion", pControllerBag.Seccion);
        }

        public void AgregarCodigoDeContexto(ref DynamicParameters pParams, ref ControllerBag pControllerBag)
        {
            if (pControllerBag.EsAnonima)
                if (pControllerBag.Seccion.ToLower() == "web")
                    if (!pParams.ParameterNames.Contains("CodigoDeContexto"))
                    {
                        if (pControllerBag.CodigoDeContexto != "")
                            pParams.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                        else
                            throw new Exception("El codigo de contexto no fue cargado");
                    }
        }

        public void ExtendedAddDynamicParams(ref DynamicParameters pParams, Modelo pObj, Operacion pOperacion)
        {
            var props = pObj.GetType().GetProperties().ToList();
            foreach (var prop in props)
                //busco en los metodos del servicio que devuelva un IEnumerable que sean mapeable con la propiedad actual

                if (prop.GetCustomAttributes(typeof(Ignorar), false).Cast<Ignorar>().Count() != 0)
                {
                    var atributes = (Ignorar[])prop.GetCustomAttributes(typeof(Ignorar), false);
                    var ignorar = false;
                    foreach (var atribute in atributes)
                        if (atribute.Value() == pOperacion)
                            ignorar = true;
                    if (!ignorar) pParams.Add(prop.Name, pObj.GetType().GetProperty(prop.Name).GetValue(pObj, null));
                }
                else
                {
                    if (prop.Name == "Id" && pOperacion == Operacion.insert)
                        pParams.Add("Id", pObj.Id, DbType.Int32, ParameterDirection.Output);
                    else
                        pParams.Add(prop.Name, pObj.GetType().GetProperty(prop.Name).GetValue(pObj, null));
                }
        }

        public void ExtendedAddDynamicParams<ModeloIn>(ref DynamicParameters pParams, ModeloIn pObj,
            Operacion pOperacion) where ModeloIn : class, new()
        {
            var props = pObj.GetType().GetProperties().ToList();
            foreach (var prop in props)
                //busco en los metodos del servicio que devuelva un IEnumerable que sean mapeable con la propiedad actual

                if (prop.GetCustomAttributes(typeof(Ignorar), false).Cast<Ignorar>().Count() != 0)
                {
                    var atributes = (Ignorar[])prop.GetCustomAttributes(typeof(Ignorar), false);
                    var ignorar = false;
                    foreach (var atribute in atributes)
                        if (atribute.Value() == pOperacion)
                            ignorar = true;
                    if (!ignorar) pParams.Add(prop.Name, pObj.GetType().GetProperty(prop.Name).GetValue(pObj, null));
                }
                else
                {
                    //if (prop.Name == "Id" && pOperacion == Operacion.insert)
                    //{
                    //    pParams.Add("Id", pObj.Id, DbType.Int32, ParameterDirection.Output);
                    //}
                    //else
                    //{
                    pParams.Add(prop.Name, pObj.GetType().GetProperty(prop.Name).GetValue(pObj, null));
                    //}
                }
        }

        private bool TieneActivo()
        {
            var props = typeof(ModeloExt)
                .GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance).ToList();

            foreach (var propertyInfo in props)
                if (propertyInfo.Name.ToLower() == "activo")
                    return true;

            return false;
        }


        #region Consultas/Ejecuciones Estándares

        public virtual bool Delete(int pId, ref ControllerBag pControllerBag)
        {
            var ret = 0;
            var sResSQL = "";
            var m = new Modelo();


            if (sResSQL == "")
            {
                var parametros = new DynamicParameters();
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("fechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
                parametros.Add("Id", pId);
                parametros.Add("Tabla", m.GetType().Name);
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);


                if (_nuevaVersion)
                {
                    parametros.Add("Seccion", pControllerBag.Seccion);
                    parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                    parametros.Add("Token", pControllerBag.Token);
                }
                else
                {
                    AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                    AgregarSeccion(ref parametros, ref pControllerBag, m);
                }

                using (IDbConnection db = _miConexion.GetConexion())
                {
                    ret = db.Execute("usp_TablaDinamica__DeleteOActivo_by_@id",
                        parametros,
                        commandType: CommandType.StoredProcedure);
                    sResSQL = parametros.Get<string>("sResSQL");
                }
            }

            return RetornoSQL(Operacion.delete, ret, sResSQL, ref pControllerBag);
        }

        public virtual IEnumerable<ModeloExt> Listado(ref ControllerBag pControllerBag)
        {
            var lista = new List<ModeloExt>();
            var sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                var parametros = new DynamicParameters(new ListParams());
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
                //Paso new Modelo() para que consiga el Type dentro de la funcion;
                if (_nuevaVersion)
                {
                    parametros.Add("Seccion", pControllerBag.Seccion);
                    parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                    parametros.Add("Token", pControllerBag.Token);
                }
                else
                {
                    AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                    AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
                }

                LogParams(parametros, "usp_" + new Modelo().GetType().Name + "__Listado");
                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__Listado",
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<string>("sResSQL");
            }

            RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }

        public virtual IEnumerable<ModeloExt> Listado(Dictionary<string, string> filtros, ref ListParams pListParams,
            ref ControllerBag pControllerBag)
        {
            var lista = new List<ModeloExt>();
            var sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                var parametros = new DynamicParameters(pListParams);
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);

                if (_nuevaVersion)
                {
                    parametros.Add("Seccion", pControllerBag.Seccion);
                    parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                    parametros.Add("Token", pControllerBag.Token);
                }
                else
                {
                    AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                    AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
                }


                //Agrego todos los filtros
                foreach (var filtro in filtros) parametros.Add(filtro.Key, filtro.Value);
                parametros.Output(pListParams, p => p.TotalDeRegistros);

                LogParams(parametros, "usp_" + new Modelo().GetType().Name + "__Listado");


                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__Listado",
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<string>("sResSQL");
            }

            RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }

        public virtual IEnumerable<ModeloExt> Listado(Dictionary<string, string> filtros,
            ref ControllerBag pControllerBag)
        {
            var lista = new List<ModeloExt>();
            var sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                var ParametrosRequeridos = new ListParams();
                var parametros = new DynamicParameters(ParametrosRequeridos);
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
                if (_nuevaVersion)
                {
                    parametros.Add("Seccion", pControllerBag.Seccion);
                    parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                    parametros.Add("Token", pControllerBag.Token);
                }
                else
                {
                    AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                    AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
                }


                //Agrego todos los filtros
                foreach (var filtro in filtros)
                    if (filtro.Value == "")
                        parametros.Add(filtro.Key, "-1");
                    else
                        parametros.Add(filtro.Key, filtro.Value);

                LogParams(parametros, "usp_" + new Modelo().GetType().Name + "__Listado");


                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__Listado",
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<string>("sResSQL");
            }

            RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }

        public virtual IEnumerable<ModeloExt> ListadoDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            var lista = new List<ModeloExt>();
            var sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("FechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
                if (TieneActivo()) parametros.Add("Activo", pActivo);
                parametros.Add("Id", pId);

                if (_nuevaVersion)
                {
                    parametros.Add("Seccion", pControllerBag.Seccion);
                    parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                    parametros.Add("Token", pControllerBag.Token);
                }
                else
                {
                    AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                    AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
                }

                LogParams(parametros, "usp_" + new Modelo().GetType().Name + "__ListadoDDLoCBXL");

                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__ListadoDDLoCBXL",
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<string>("sResSQL");
            }

            //RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }

        public virtual IEnumerable<ModeloExt> ListadoDDLAnonimo(ref ControllerBag pControllerBag, bool? pActivo,
            int pId, string pContexto)
        {
            var lista = new List<ModeloExt>();
            var sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("FechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
                if (TieneActivo()) parametros.Add("Activo", pActivo);
                parametros.Add("Id", pId);
                if (_nuevaVersion)
                {
                    parametros.Add("Seccion", pControllerBag.Seccion);
                    parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                    parametros.Add("Token", pControllerBag.Token);
                }
                else
                {
                    AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                    AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
                }

                LogParams(parametros, "usp_" + new Modelo().GetType().Name + "__ListadoDDLoCBXL");

                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__ListadoDDLoCBXL",
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<string>("sResSQL");
            }

            //RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }

        public virtual int Insert(Modelo pObj, ref ControllerBag pControllerBag)
        {
            int ret;
            var sResSQL = "";
            var parametros = new DynamicParameters(new ABMParams());
            parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
            //parametros.AddDynamicParams(pObj);
            ExtendedAddDynamicParams(ref parametros, pObj, Operacion.insert);
            parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
            if (_nuevaVersion)
            {
                parametros.Add("Seccion", pControllerBag.Seccion);
                parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                parametros.Add("Token", pControllerBag.Token);
            }
            else
            {
                AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                AgregarSeccion(ref parametros, ref pControllerBag, pObj);
            }


            //parametros.Output(pObj, x => x.Id);
            LogParams(parametros, "usp_" + new Modelo().GetType().Name + "__insert");

            using (IDbConnection db = _miConexion.GetConexion())
            {
                ret = db.Execute("usp_" + new Modelo().GetType().Name + "__insert",
                    parametros,
                    commandType: CommandType.StoredProcedure);
            }

            sResSQL = parametros.Get<string>("sResSQL");
            if (sResSQL == "") pObj.Id = parametros.Get<int>("Id");
            RetornoSQL(Operacion.insert, ret, sResSQL, ref pControllerBag);
            return pObj.Id;
        }

        public virtual int InsertByIdString(Modelo pObj, string pCampoIdString, ref ControllerBag pControllerBag)
        {
            int ret;
            var sResSQL = "";
            var parametros = new DynamicParameters(new ABMParams());
            parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
            //parametros.AddDynamicParams(pObj);
            ExtendedAddDynamicParams(ref parametros, pObj, Operacion.insert);
            parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
            if (_nuevaVersion)
            {
                parametros.Add("Seccion", pControllerBag.Seccion);
                parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                parametros.Add("Token", pControllerBag.Token);
            }
            else
            {
                AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                AgregarSeccion(ref parametros, ref pControllerBag, pObj);
            }

            //parametros.Output(pObj, x => x.Id);
            LogParams(parametros, "usp_" + new Modelo().GetType().Name + "__insert_by_@" + pCampoIdString);

            using (IDbConnection db = _miConexion.GetConexion())
            {
                ret = db.Execute("usp_" + new Modelo().GetType().Name + "__insert_by_@" + pCampoIdString,
                    parametros,
                    commandType: CommandType.StoredProcedure);
            }

            sResSQL = parametros.Get<string>("sResSQL");
            if (sResSQL == "") pObj.Id = parametros.Get<int>("Id");
            RetornoSQL(Operacion.insert, ret, sResSQL, ref pControllerBag);
            return pObj.Id;
        }

        public virtual ModeloExt Registro(int pId, ref ControllerBag pControllerBag)
        {
            ModeloExt obj = null;
            var parametros = new DynamicParameters();
            var sResSQL = "";
            parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
            parametros.Add("Id", pId);
            parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
            parametros.Add("FechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
            if (_nuevaVersion)
            {
                parametros.Add("Seccion", pControllerBag.Seccion);
                parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                parametros.Add("Token", pControllerBag.Token);
            }
            else
            {
                AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
            }

            LogParams(parametros, "usp_" + new Modelo().GetType().Name + "__registro_by_@id");

            using (IDbConnection db = _miConexion.GetConexion())
            {
                obj = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__registro_by_@id",
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .SingleOrDefault();
                sResSQL = parametros.Get<string>("sResSQL");
            }

            RetornoSQL(Operacion.registro, 1, sResSQL, ref pControllerBag);
            return obj;
        }

        public virtual int Update(Modelo pObj, ref ControllerBag pControllerBag)
        {
            int ret;
            var sResSQL = "";
            var parametros = new DynamicParameters(new ABMParams());
            parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
            //parametros.AddDynamicParams(pObj);
            ExtendedAddDynamicParams(ref parametros, pObj, Operacion.update);
            parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
            if (_nuevaVersion)
            {
                parametros.Add("Seccion", pControllerBag.Seccion);
                parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                parametros.Add("Token", pControllerBag.Token);
            }
            else
            {
                AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                AgregarSeccion(ref parametros, ref pControllerBag, pObj);
            }

            LogParams(parametros, "usp_" + new Modelo().GetType().Name + "__update_by_@id");

            using (IDbConnection db = _miConexion.GetConexion())
            {
                ret = db.Execute("usp_" + new Modelo().GetType().Name + "__update_by_@id",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                sResSQL = parametros.Get<string>("sResSQL");
            }

            RetornoSQL(Operacion.update, ret, sResSQL, ref pControllerBag);
            return ret;
        }

        public virtual int UpdateCampo(int pId, string pCampo, object pValor, ref ControllerBag pControllerBag)
        {
            int ret;
            var sResSQL = "";
            var parametros = new DynamicParameters(new ABMParams());
            parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
            parametros.Add("Id", pId);
            parametros.Add("Tabla", new Modelo().GetType().Name);
            parametros.Add("Campo", pCampo);
            parametros.Add("ValorDelCampo", pValor);
            parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
            if (_nuevaVersion)
            {
                parametros.Add("Seccion", pControllerBag.Seccion);
                parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                parametros.Add("Token", pControllerBag.Token);
            }
            else
            {
                AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
            }

            LogParams(parametros, "usp_TablaDinamica__Update_@Campo_by_@id");

            using (IDbConnection db = _miConexion.GetConexion())
            {
                ret = db.Execute("usp_TablaDinamica__Update_@Campo_by_@id",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                sResSQL = parametros.Get<string>("sResSQL");
            }

            RetornoSQL(Operacion.update, ret, sResSQL, ref pControllerBag);
            return ret;
        }

        #endregion


        #region Consultas/Ejecuciones Customizadas

        protected int CustomExecute<ModeloIn>(ModeloIn pObj, string pSp, ref ControllerBag pControllerBag)
            where ModeloIn : class, new()
        {
            int ret;
            var sResSQL = "";

            using (IDbConnection db = _miConexion.GetConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("FechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());

                //parametros.AddDynamicParams(pObj);

                if (_nuevaVersion)
                {
                    parametros.Add("Seccion", pControllerBag.Seccion);
                    parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                    parametros.Add("Token", pControllerBag.Token);
                }
                else
                {
                    AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                    AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
                }


                ExtendedAddDynamicParams(ref parametros, pObj, Operacion.custom);
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString,
                    ParameterDirection.Output); //TODO: Ver de usar esta variable

                LogParams(parametros, pSp);


                ret = db.Execute(pSp,
                    parametros,
                    commandType: CommandType.StoredProcedure);
                sResSQL = parametros.Get<string>("sResSQL");
            }

            RetornoSQL(Operacion.custom, ret, sResSQL, ref pControllerBag);
            return ret;
        }

        protected ModeloOut CustomQuery<ModeloIn, ModeloOut>(ModeloIn pObj, string pSp,
            ref ControllerBag pControllerBag) where ModeloIn : class, new() where ModeloOut : class, new()
        {
            ModeloOut ret = null;
            var sResSQL = "";

            using (IDbConnection db = _miConexion.GetConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("FechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
                parametros.AddDynamicParams(pObj);
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);

                if (_nuevaVersion)
                {
                    parametros.Add("Seccion", pControllerBag.Seccion);
                    parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                    parametros.Add("Token", pControllerBag.Token);
                }
                else
                {
                    AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                    AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
                }

                LogParams(parametros, pSp);

                ret = db.Query<ModeloOut>(pSp,
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .SingleOrDefault();
                sResSQL = parametros.Get<string>("sResSQL");
            }

            RetornoSQL(Operacion.custom, 0, sResSQL, ref pControllerBag);
            return ret;
        }
        protected ModeloOut CustomQueryNoEstandar<ModeloIn, ModeloOut>(ModeloIn pObj, string pSp,
            ref ControllerBag pControllerBag) where ModeloIn : class, new() where ModeloOut : class, new()
        {
            ModeloOut ret = null;
            var sResSQL = "";

            using (IDbConnection db = _miConexion.GetConexion())
            {
                var parametros = new DynamicParameters();
                parametros.AddDynamicParams(pObj);



                LogParams(parametros, pSp);

                ret = db.Query<ModeloOut>(pSp,
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .SingleOrDefault();
            }
            
            return ret;
        }

        protected IEnumerable<ModeloOut> CustomMultipleQuery<ModeloIn, ModeloOut>(ModeloIn pObj, string pSp,
            ref ControllerBag pControllerBag) where ModeloIn : class, new() where ModeloOut : class, new()
        {
            var lista = new List<ModeloOut>();
            var sResSQL = "";

            using (IDbConnection db = _miConexion.GetConexion())
            {
                var parametros = new DynamicParameters(new BaseParams());
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("FechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
                parametros.AddDynamicParams(pObj);
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);

                if (_nuevaVersion)
                {
                    parametros.Add("Seccion", pControllerBag.Seccion);
                    parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                    parametros.Add("Token", pControllerBag.Token);
                }
                else
                {
                    AgregarCodigoDeContexto(ref parametros, ref pControllerBag);
                    AgregarSeccion(ref parametros, ref pControllerBag, new Modelo());
                }
                LogParams(parametros, pSp);


                lista = db.Query<ModeloOut>(pSp, parametros, commandType: CommandType.StoredProcedure).ToList();
                sResSQL = parametros.Get<string>("sResSQL");
            }

            RetornoSQL(Operacion.custom, 0, sResSQL, ref pControllerBag);
            return lista;
        }

        #endregion

        private void LogParams(object pObj, string pSP)
        {
            NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {
                bool activeLog = bool.Parse(ConfigurationManager.AppSettings["activeLog"]);
                if (activeLog)
                {
                    Logger.Info("SP: " + pSP);

                    string jsonToLog = Newtonsoft.Json.JsonConvert.SerializeObject(pObj);
                    Logger.Info(jsonToLog);
                }
            }
            catch (Exception e)
            {
                string jsonToLog = Newtonsoft.Json.JsonConvert.SerializeObject(e);
                Logger.Info(jsonToLog);
            }

        }
    }
}