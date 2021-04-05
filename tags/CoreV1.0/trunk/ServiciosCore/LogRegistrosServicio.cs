using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore
{
    public interface ILogRegistrosServicio : IBaseServicios<LogRegistros, LogRegistrosExt>
    {

    }
    public class LogRegistrosServicio : BaseServicios<LogRegistros, LogRegistrosExt>, ILogRegistrosServicio
    {
        private ILogRegistrosRepositorio _LogRegistrosRepositorio;
        private IUsuariosRepositorio _usuariosRepositorio;
        private ITiposDeOperacionesRepositorio _tiposDeOperacionesRepositorio;
        private ITablasRepositorio _tablasRepositorio;

        public LogRegistrosServicio(ILogRegistrosRepositorio pLogRegistrosRepositorio, IUsuariosRepositorio pUsuariosRepositorio, ITiposDeOperacionesRepositorio pTiposDeOperacionesRepositorio, ITablasRepositorio pTablasRepositorio)
        {
            _LogRegistrosRepositorio = pLogRegistrosRepositorio;
            _usuariosRepositorio = pUsuariosRepositorio;
            _tiposDeOperacionesRepositorio = pTiposDeOperacionesRepositorio;
            _tablasRepositorio = pTablasRepositorio;
        }

        public override IRepositorio<LogRegistros, LogRegistrosExt> GetRepositorio()
        {
            return _LogRegistrosRepositorio;
        }
        
        [ListadoDDL]
        public List<UsuariosExt> UsuariosDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<UsuariosExt>)_usuariosRepositorio.ListadoDDL(ref pControllerBag, pActivo,pId);
        }

        [ListadoDDL]
        public List<TiposDeOperacionesExt> TiposDeOperacionesDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<TiposDeOperacionesExt>)_tiposDeOperacionesRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        [ListadoDDL]
        public List<TablasExt> TablasDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<TablasExt>)_tablasRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }
        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _tiposDeOperacionesRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _tablasRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _usuariosRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }
    }

}
