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
    public interface ITareasServicio : IBaseServicios<Tareas, TareasExt>
    {

    }
    public class TareasServicio : BaseServicios<Tareas, TareasExt>, ITareasServicio
    {
        private ITareasRepositorio _tareasRepositorio;
        private ITiposDeTareasRepositorio _tiposDeTareasRepositorio;
        private IImportanciasDeTareasRepositorio _importanciasDeTareasRepositorio;
        private IEstadosDeTareasRepositorio _estadosDeTareasRepositorio;
        private IUsuariosRepositorio _usuariosRepositorio;

        public TareasServicio(ITareasRepositorio pTareasRepositorio, ITiposDeTareasRepositorio pTiposDeTareasRepositorio, IImportanciasDeTareasRepositorio pImportanciasDeTareasRepositorio, IEstadosDeTareasRepositorio pEstadosDeTareasRepositorio, IUsuariosRepositorio pUsuariosRepositorio)
        {
            _tiposDeTareasRepositorio = pTiposDeTareasRepositorio;
            _tareasRepositorio = pTareasRepositorio;
            _importanciasDeTareasRepositorio = pImportanciasDeTareasRepositorio;
            _estadosDeTareasRepositorio = pEstadosDeTareasRepositorio;
            _usuariosRepositorio = pUsuariosRepositorio;
        }

        public override IRepositorio<Tareas, TareasExt> GetRepositorio()
        {
            return _tareasRepositorio;
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            _tiposDeTareasRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _importanciasDeTareasRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _estadosDeTareasRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _usuariosRepositorio.SetDatosDeLogin(pDatosDeLogin);
            base.SetDatosDeLogin(pDatosDeLogin);
        }

        [ListadoDDL]
        public List<TiposDeTareasExt> ListadoTareas(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<TiposDeTareasExt>)_tiposDeTareasRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        [ListadoDDL]
        public List<ImportanciasDeTareasExt> ListadoImportancias(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<ImportanciasDeTareasExt>)_importanciasDeTareasRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        [ListadoDDL]
        public List<EstadosDeTareasExt> ListadoEstados(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<EstadosDeTareasExt>)_estadosDeTareasRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }


        [ListadoDDL]
        public List<UsuariosExt> ListadoUsuarios(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<UsuariosExt>)_usuariosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }
    }

}
