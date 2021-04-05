using Dapper;
using ModelosCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RepositoriosCore.Base
{


    /// <summary>
    /// Interfaz que van a implementar las interfaces de los repositorios particulares para exponer sus métodos
    /// </summary>
    /// <typeparam name="Modelo"></typeparam>
    /// <typeparam name="ModeloExt"></typeparam>
    public interface IRepositorio<Modelo, ModeloExt> where Modelo : BaseModelos where ModeloExt : Modelo
    {
        IEnumerable<ModeloExt> Listar();
        Modelo Registro(int pId);
        int Insert(Modelo pObj);
        int Update(Modelo pObj);
        bool Delete(int pId);
        void SetDatosDeLogin(DatosDeLogin pDatosDeLogin);
    }
    /// <summary>
    /// repositorio base del cual heredan todos, maneja el acceso a la base de datos de forma genérica
    /// </summary>
    /// <typeparam name="Modelo"></typeparam>
    /// <typeparam name="ModeloExt"></typeparam>
    public abstract class BaseRepositorios<Modelo, ModeloExt> where Modelo : BaseModelos, new() where ModeloExt : Modelo
    {
        private IConexion miConexion;
        private DatosDeLogin datosDeLogin;

        public BaseRepositorios(IConexion pMiConexion)
        {
            miConexion = pMiConexion;
            datosDeLogin = new DatosDeLogin();
        }

        private class ABMParams {
            public string sResSQL { get; set; } = "";
            public DateTime fechaDeEjecucion { get; set; } = DateTime.Now;
        }

        private class BaseParams {
            public string sResSQL { get; set; } = "";
        }

        private class ListParams  {
            public string sResSQL { get; set; } = "";
            public string ordenarPor { get; set; } = "";
            public bool sentido { get; set; } = true;
            public string filtro { get; set; } = "";
            public bool activo { get; set; } = true;
        }

        public virtual IEnumerable<ModeloExt> Listar()
        {
            List<ModeloExt> _lista = new List<ModeloExt>();

            using (IDbConnection _db = miConexion.GetConexion())
            {
                DynamicParameters _parametros = new DynamicParameters(new ListParams());
                _parametros.Add("UsuarioQueEjecuta_Id", datosDeLogin.usuario_Id);
                _lista = _db.Query<ModeloExt>("usp_" + new Modelo().GetType().Name + "___listado_cFiltros_cPag",
                    _parametros,
                    commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return _lista;
        }

        public virtual Modelo Registro(int pId)
        {
            Modelo _obj = null;
            using (IDbConnection _db = miConexion.GetConexion())
            {
                _obj = _db.Query<Modelo>("usp_" + new Modelo().GetType().Name + "___registro_by_@id",
                    new { usuarioQueEjecuta_Id = datosDeLogin.usuario_Id, Id = pId, sResSQL = "" },
                    commandType: CommandType.StoredProcedure)
                    .SingleOrDefault();
            }
            return _obj;
        }

        public virtual int Insert(Modelo pObj)
        {
            int _ret;
            DynamicParameters _parametros = new DynamicParameters(new ABMParams());
            _parametros.Add("UsuarioQueEjecuta_Id", datosDeLogin.usuario_Id);
            _parametros.AddDynamicParams(pObj);
            using (IDbConnection db = miConexion.GetConexion())
            {
                _ret = db.Execute("usp_" + new Modelo().GetType().Name + "___insert",
                    _parametros,
                    commandType: CommandType.StoredProcedure);
            }
            return _ret;
        }

        public virtual int Update(Modelo pObj)
        {
            int _ret;
            DynamicParameters _parametros = new DynamicParameters(new ABMParams());
            _parametros.Add("UsuarioQueEjecuta_Id", datosDeLogin.usuario_Id);
            _parametros.AddDynamicParams(pObj);
            using (IDbConnection db = miConexion.GetConexion())
            {
                _ret = db.Execute("usp_" + new Modelo().GetType().Name + "___update_by_@id",
                    _parametros,
                    commandType: CommandType.StoredProcedure);
            }
            return _ret;
        }

        public virtual bool Delete(int pId)
        {
            int _ret;
            using (IDbConnection _db = miConexion.GetConexion())
            {
                _ret = _db.Execute("usp_" + new Modelo().GetType().Name + "___Update_Campos_@Activo_by_@id",
                    new { usuarioQueEjecuta_Id = datosDeLogin.usuario_Id, fechaDeEjecucion = System.DateTime.Now, Id = pId, sResSQL = "", activo = false },
                    commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        protected int CustomExecute<ModeloIn>(ModeloIn pObj, string pSp) where ModeloIn : class, new()
        {
            int _ret;
            using (IDbConnection _db = miConexion.GetConexion())
            {
                _ret = _db.Execute(pSp,
                    pObj,
                    commandType: CommandType.StoredProcedure);
            }
            return _ret;
        }

        protected ModeloOut CustomQuery<ModeloIn, ModeloOut>(ModeloIn pObj, string pSp) where ModeloIn : class, new() where ModeloOut : class, new()
        {
            ModeloOut _ret = null;
            using (IDbConnection _db = miConexion.GetConexion())
            {
                _ret = _db.Query<ModeloOut>(pSp,
                    pObj,
                    commandType: CommandType.StoredProcedure)
                    .SingleOrDefault();
            }
            return _ret;
        }

        protected IEnumerable<ModeloOut> CustomMultipleQuery<ModeloIn, ModeloOut>(ModeloIn pObj, string pSp) where ModeloIn : class, new() where ModeloOut : class, new()
        {
            List<ModeloOut> _lista = new List<ModeloOut>();

            using (IDbConnection _db = miConexion.GetConexion())
            {
                DynamicParameters _parametros = new DynamicParameters(new BaseParams());
                _parametros.Add("UsuarioQueEjecuta_Id", datosDeLogin.usuario_Id);
                _parametros.AddDynamicParams(pObj);
                _lista = _db.Query<ModeloOut>(pSp,
                    _parametros,
                    commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return _lista;
        }

        public void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            this.datosDeLogin = pDatosDeLogin;
        }
    }

}