using _DatosDelSistema;
using Dapper;
using FuncionesCore;
using ModelosCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RepositoriosCore;
using System.Dynamic;
using System.Reflection;
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
    /// Interfaz que van a implementar las interfaces de los repositorios particulares para exponer sus métodos
    /// </summary>
    /// <typeparam name="Modelo"></typeparam>
    /// <typeparam name="ModeloExt"></typeparam>
    public interface IRepositorio<Modelo, ModeloExt> where Modelo : BaseModelo where ModeloExt : Modelo
    {
        bool Delete(int pId, ref ControllerBag pControllerBag);
        int Insert(Modelo pObj, ref ControllerBag pControllerBag);
        int InsertByIdString(Modelo pObj, string pCampoIdString, ref ControllerBag pControllerBag);
        IEnumerable<ModeloExt> Listado(ref ControllerBag pControllerBag);
        IEnumerable<ModeloExt> Listado(Dictionary<String, String> filtros, ref ListParams pListParams, ref ControllerBag pControllerBag);
        IEnumerable<ModeloExt> ListadoDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId);
        IEnumerable<ModeloExt> ListadoDDLAnonimo(ref ControllerBag pControllerBag, bool? pActivo, int pId, string pContexto);
        bool PrecargaInicialDeUnaPagina(Operacion pOp, ref ControllerBag pControllerBag);
        ModeloExt Registro(int pId, ref ControllerBag pControllerBag);
        void SetDatosDeLogin(DatosDeLogin pDatosDeLogin);
        DatosDeLogin GetDatosDeLogin();
        int Update(Modelo pObj, ref ControllerBag pControllerBag);
    }

    /// <summary>
    /// repositorio base del cual heredan todos, maneja el acceso a la base de datos de forma genérica
    /// </summary>
    /// <typeparam name="Modelo"></typeparam>
    /// <typeparam name="ModeloExt"></typeparam>
    public abstract class BaseRepositorios<Modelo, ModeloExt> : IRepositorio<Modelo, ModeloExt> where Modelo : BaseModelo, new() where ModeloExt : Modelo
    {
        private IConexion _miConexion;
        protected DatosDeLogin _datosDeLogin;
        private DateTime _fechaDeEjecucion;


        private bool _nuevaVersion = true;//Para mantener las soluciones viejas donde no es obligatorio poner false. Al solucionar borrar


        public BaseRepositorios(IConexion pMiConexion)
        {
            _miConexion = pMiConexion;
            _datosDeLogin = new DatosDeLogin();
            _fechaDeEjecucion = FechasYHoras.FechaYTiempoAhora(); // Todo se controla con esta.
        }


        #region Precarga Inicial De Una Página
        public virtual bool PrecargaInicialDeUnaPagina(Operacion pOp, ref ControllerBag pControllerBag)
        {
            string sResSQL = "";
            Modelo m = new Modelo();
            DatosDeUnaPagina obj = null;

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
            parametros.Add("fechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
            parametros.Add("Tabla", m.GetType().Name);
            parametros.Add("FuncionDePagina", pOp.ToString());
            parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);

            if (_nuevaVersion)
            {
                parametros.Add("Seccion", pControllerBag.Seccion);
                //parametros.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                //parametros.Add("Token", pControllerBag.Token);
            }
            else
            {
                AgregarSeccion(ref parametros, ref pControllerBag, m);
            }


            parametros.Add("FuncionDePagina", pOp.ToString());
            

            using (IDbConnection db = _miConexion.GetConexion())
            {
                obj = db.Query<DatosDeUnaPagina>("usp_Paginas__PermisosDePrecargaInicial",//usp_Paginas__PermisosDePrecargaInicial usp_PrecargaInicialDeUnaPagina
                    parametros,
                    commandType: CommandType.StoredProcedure)
                        .SingleOrDefault();
            }

            sResSQL = parametros.Get<String>("sResSQL");
            pControllerBag.DatosDeUnaPagina = obj;
            pControllerBag.Add(sResSQL);

            return true;
        }
        #endregion


        #region Consultas/Ejecuciones Estándares
        public virtual bool Delete(int pId, ref ControllerBag pControllerBag)
        {
            int ret = 0;
            string sResSQL = "";
            Modelo m = new Modelo();


            if (sResSQL == "")
            {
                DynamicParameters parametros = new DynamicParameters();
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
                    sResSQL = parametros.Get<String>("sResSQL");
                }
            }

            return RetornoSQL(Operacion.delete, ret, sResSQL, ref pControllerBag);
        }

        public virtual IEnumerable<ModeloExt> Listado(ref ControllerBag pControllerBag)
        {
            List<ModeloExt> lista = new List<ModeloExt>();
            string sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                DynamicParameters parametros = new DynamicParameters(new ListParams());
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


                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__Listado",
                    parametros,
                    commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<String>("sResSQL");
            }

            RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }

        public virtual IEnumerable<ModeloExt> Listado(Dictionary<String, String> filtros, ref ListParams pListParams, ref ControllerBag pControllerBag)
        {
            List<ModeloExt> lista = new List<ModeloExt>();
            string sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                DynamicParameters parametros = new DynamicParameters(pListParams);
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
                foreach (KeyValuePair<string, string> filtro in filtros)
                {
                    parametros.Add(filtro.Key, filtro.Value);
                }
                parametros.Output(pListParams, p => p.TotalDeRegistros);
                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__Listado",
                    parametros,
                    commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<String>("sResSQL");
            }

            RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }

        public virtual IEnumerable<ModeloExt> Listado(Dictionary<String, String> filtros, ref ControllerBag pControllerBag)
        {
            List<ModeloExt> lista = new List<ModeloExt>();
            string sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                ListParams ParametrosRequeridos = new ListParams();
                DynamicParameters parametros = new DynamicParameters(ParametrosRequeridos);
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
                foreach (KeyValuePair<string, string> filtro in filtros)
                {
                    if (filtro.Value == "")
                    {
                        parametros.Add(filtro.Key, "-1");
                    }
                    else
                    {
                        parametros.Add(filtro.Key, filtro.Value);
                    }
                }

                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__Listado",
                    parametros,
                    commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<String>("sResSQL");
            }

            RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }
        public virtual IEnumerable<ModeloExt> ListadoDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            List<ModeloExt> lista = new List<ModeloExt>();
            string sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("FechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
                parametros.Add("Activo", pActivo);
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



                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__ListadoDDLoCBXL",
                    parametros,
                    commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<String>("sResSQL");
            }

            //RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }

        public virtual IEnumerable<ModeloExt> ListadoDDLAnonimo(ref ControllerBag pControllerBag, bool? pActivo, int pId, string pContexto)
        {
            List<ModeloExt> lista = new List<ModeloExt>();
            string sResSQL = "";
            using (IDbConnection db = _miConexion.GetConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("UsuarioQueEjecutaId", _datosDeLogin.UsuarioId);
                parametros.Add("FechaDeEjecucion", FechasYHoras.FechaYTiempoAhora());
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);
                parametros.Add("Activo", pActivo);
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



                lista = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__ListadoDDLoCBXL",
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .ToList();
                sResSQL = parametros.Get<String>("sResSQL");
            }

            //RetornoSQL(Operacion.listado, lista.Count, sResSQL, ref pControllerBag);
            return lista;
        }

        public virtual int Insert(Modelo pObj, ref ControllerBag pControllerBag)
        {
            int ret;
            string sResSQL = "";
            DynamicParameters parametros = new DynamicParameters(new ABMParams());
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

            using (IDbConnection db = _miConexion.GetConexion())
            {
                ret = db.Execute("usp_" + new Modelo().GetType().Name + "__insert",
                    parametros,
                    commandType: CommandType.StoredProcedure);
            }
            sResSQL = parametros.Get<String>("sResSQL");
            if (sResSQL == "")
            {
                pObj.Id = parametros.Get<int>("Id");
            }
            RetornoSQL(Operacion.insert, ret, sResSQL, ref pControllerBag);
            return pObj.Id;
        }

        public virtual int InsertByIdString(Modelo pObj, string pCampoIdString, ref ControllerBag pControllerBag)
        {
            int ret;
            string sResSQL = "";
            DynamicParameters parametros = new DynamicParameters(new ABMParams());
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

            using (IDbConnection db = _miConexion.GetConexion())
            {
                ret = db.Execute("usp_" + new Modelo().GetType().Name + "__insert_by_@" + pCampoIdString,
                    parametros,
                    commandType: CommandType.StoredProcedure);
            }
            sResSQL = parametros.Get<String>("sResSQL");
            if (sResSQL == "")
            {
                pObj.Id = parametros.Get<int>("Id");
            }
            RetornoSQL(Operacion.insert, ret, sResSQL, ref pControllerBag);
            return pObj.Id;
        }

        public virtual ModeloExt Registro(int pId, ref ControllerBag pControllerBag)
        {
            ModeloExt obj = null;
            DynamicParameters parametros = new DynamicParameters();
            string sResSQL = "";
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


            using (IDbConnection db = _miConexion.GetConexion())
            {
                obj = db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "__registro_by_@id",
                    parametros,
                    commandType: CommandType.StoredProcedure)
                        .SingleOrDefault();
                sResSQL = parametros.Get<String>("sResSQL");
            }

            RetornoSQL(Operacion.registro, 1, sResSQL, ref pControllerBag);
            return obj;
        }

        public virtual int Update(Modelo pObj, ref ControllerBag pControllerBag)
        {
            int ret;
            string sResSQL = "";
            DynamicParameters parametros = new DynamicParameters(new ABMParams());
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


            using (IDbConnection db = _miConexion.GetConexion())
            {
                ret = db.Execute("usp_" + new Modelo().GetType().Name + "__update_by_@id",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                sResSQL = parametros.Get<String>("sResSQL");
            }

            RetornoSQL(Operacion.update, ret, sResSQL, ref pControllerBag);
            return ret;
        }

        public virtual int UpdateCampo(int pId, string pCampo, Object pValor, ref ControllerBag pControllerBag)
        {
            int ret;
            string sResSQL = "";
            DynamicParameters parametros = new DynamicParameters(new ABMParams());
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


            using (IDbConnection db = _miConexion.GetConexion())
            {
                ret = db.Execute("usp_TablaDinamica__Update_@Campo_by_@id",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                sResSQL = parametros.Get<String>("sResSQL");
            }

            RetornoSQL(Operacion.update, ret, sResSQL, ref pControllerBag);
            return ret;
        }
        #endregion


        #region Consultas/Ejecuciones Customizadas
        protected int CustomExecute<ModeloIn>(ModeloIn pObj, string pSp, ref ControllerBag pControllerBag) where ModeloIn : class, new()
        {
            int ret;
            string sResSQL = "";

            using (IDbConnection db = _miConexion.GetConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
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
                parametros.Add("sResSQL", sResSQL, DbType.AnsiString, ParameterDirection.Output);//TODO: Ver de usar esta variable

                ret = db.Execute(pSp,
                    parametros,

                    commandType: CommandType.StoredProcedure);
                sResSQL = parametros.Get<String>("sResSQL");
            }

            RetornoSQL(Operacion.custom, ret, sResSQL, ref pControllerBag);
            return ret;
        }

        protected ModeloOut CustomQuery<ModeloIn, ModeloOut>(ModeloIn pObj, string pSp, ref ControllerBag pControllerBag) where ModeloIn : class, new() where ModeloOut : class, new()
        {
            ModeloOut ret = null;
            string sResSQL = "";

            using (IDbConnection db = _miConexion.GetConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
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


                ret = db.Query<ModeloOut>(pSp,
                    parametros,
                    commandType: CommandType.StoredProcedure)
                        .SingleOrDefault();
                sResSQL = parametros.Get<String>("sResSQL");
            }

            RetornoSQL(Operacion.custom, 0, sResSQL, ref pControllerBag);
            return ret;
        }

        protected IEnumerable<ModeloOut> CustomMultipleQuery<ModeloIn, ModeloOut>(ModeloIn pObj, string pSp, ref ControllerBag pControllerBag) where ModeloIn : class, new() where ModeloOut : class, new()
        {
            List<ModeloOut> lista = new List<ModeloOut>();
            string sResSQL = "";

            using (IDbConnection db = _miConexion.GetConexion())
            {
                DynamicParameters parametros = new DynamicParameters(new BaseParams());
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


                lista = db.Query<ModeloOut>(pSp, parametros, commandType: CommandType.StoredProcedure).ToList();
                sResSQL = parametros.Get<String>("sResSQL");

            }

            RetornoSQL(Operacion.custom, 0, sResSQL, ref pControllerBag);
            return lista;
        }
        #endregion


        #region Login
        public void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            _datosDeLogin = pDatosDeLogin;
        }
        #endregion


        #region Manejo de los retornos de SQL
        public bool RetornoSQL(Operacion op, int cantidad, string sResSQL, ref ControllerBag pControllerBag)
        {
            string plural = "";
            if (cantidad > 1) { plural = "s"; }
            string operacion = "";
            //throw new Exception();
            if (sResSQL == "")
            {
                
                return true;
            }
            else
            {
                pControllerBag.Add(sResSQL, true);
                return false;
            }
        }


        #endregion

        public DatosDeLogin GetDatosDeLogin()
        {
            return _datosDeLogin;
        }

        public void AgregarSeccion(ref DynamicParameters pParams, ref ControllerBag pControllerBag, Modelo pObj)
        {
            if (!pObj.GetType().GetCustomAttributes(typeof(SinSeccion), false).Any())
            {
                if (pControllerBag.Seccion != null)
                {
                    pParams.Add("Seccion", pControllerBag.Seccion);
                }
            }
        }

        public void AgregarCodigoDeContexto(ref DynamicParameters pParams, ref ControllerBag pControllerBag)
        {
            if (pControllerBag.EsAnonima)
            {
                if (pControllerBag.Seccion.ToLower() == "web")
                {
                    if (!pParams.ParameterNames.Contains("CodigoDeContexto"))
                    {
                        if (pControllerBag.CodigoDeContexto != "")
                            pParams.Add("CodigoDelContexto", pControllerBag.CodigoDeContexto);
                        else
                        {
                            throw new Exception("El codigo de contexto no fue cargado");
                        }
                    }
                }
            }
        }
        public void ExtendedAddDynamicParams(ref DynamicParameters pParams, Modelo pObj, Operacion pOperacion)
        {
            List<PropertyInfo> props = pObj.GetType().GetProperties().ToList();
            foreach (PropertyInfo prop in props)
            {
                //busco en los metodos del servicio que devuelva un IEnumerable que sean mapeable con la propiedad actual

                if (prop.GetCustomAttributes(typeof(Ignorar), false).Cast<Ignorar>().Count() != 0)
                {
                    Ignorar[] atributes = (Ignorar[])prop.GetCustomAttributes(typeof(Ignorar), false);
                    bool ignorar = false;
                    foreach (Ignorar atribute in atributes)
                    {
                        if (atribute.Value() == pOperacion)
                        {
                            ignorar = true;
                        }
                    }
                    if (!ignorar)
                    {
                        pParams.Add(prop.Name, pObj.GetType().GetProperty(prop.Name).GetValue(pObj, null));
                    }
                }
                else
                {
                    if (prop.Name == "Id" && pOperacion == Operacion.insert)
                    {
                        pParams.Add("Id", pObj.Id, DbType.Int32, ParameterDirection.Output);
                    }
                    else
                    {
                        pParams.Add(prop.Name, pObj.GetType().GetProperty(prop.Name).GetValue(pObj, null));
                    }
                }
            }
        }
        public void ExtendedAddDynamicParams<ModeloIn>(ref DynamicParameters pParams, ModeloIn pObj, Operacion pOperacion) where ModeloIn : class, new()
        {
            List<PropertyInfo> props = pObj.GetType().GetProperties().ToList();
            foreach (PropertyInfo prop in props)
            {
                //busco en los metodos del servicio que devuelva un IEnumerable que sean mapeable con la propiedad actual

                if (prop.GetCustomAttributes(typeof(Ignorar), false).Cast<Ignorar>().Count() != 0)
                {
                    Ignorar[] atributes = (Ignorar[])prop.GetCustomAttributes(typeof(Ignorar), false);
                    bool ignorar = false;
                    foreach (Ignorar atribute in atributes)
                    {
                        if (atribute.Value() == pOperacion)
                        {
                            ignorar = true;
                        }
                    }
                    if (!ignorar)
                    {
                        pParams.Add(prop.Name, pObj.GetType().GetProperty(prop.Name).GetValue(pObj, null));
                    }
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
        }
    }
}