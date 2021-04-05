using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;

namespace ServiciosCore
{
    public interface ISoportesServicio : IBaseServicios<Soportes, SoportesExt>
    {
        IEnumerable<Usuarios> ListadoUsuarios(ref ControllerBag pControllerBag, bool? pActivo, int pId);
        IEnumerable<EstadosDeSoportes> ListadoEstados(ref ControllerBag pControllerBag, bool? pActivo, int pId);
        IEnumerable<PrioridadesDeSoportes> ListadoPrioridades(ref ControllerBag pControllerBag, bool? pActivo, int pId);
    }

    public class SoportesServicio : BaseServicios<Soportes, SoportesExt>, ISoportesServicio
    {
        private ISoportesRepositorio _soportesRepositorio;
        private IUsuariosRepositorio _usuariosRepositorio;
        private IEstadosDeSoportesRepositorio _estadosDeSoportesRepositorio;
        private IPrioridadesDeSoportesRepositorio _prioridadesDeSoportesRepositorio;

        public SoportesServicio(ISoportesRepositorio pSoportesRepositorio, 
                                IUsuariosRepositorio pUsuariosRepositorio, 
                                IEstadosDeSoportesRepositorio pEstadosDeSoportesRepositorio,
                                IPrioridadesDeSoportesRepositorio pPrioridadesDeSoportesRepositorio)
        {
            _soportesRepositorio = pSoportesRepositorio;
            _usuariosRepositorio = pUsuariosRepositorio;
            _estadosDeSoportesRepositorio = pEstadosDeSoportesRepositorio;
            _prioridadesDeSoportesRepositorio = pPrioridadesDeSoportesRepositorio;
        }

        [ListadoDDL]
        public IEnumerable<Usuarios> ListadoUsuarios(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return _usuariosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        [ListadoDDL]
        public IEnumerable<EstadosDeSoportes> ListadoEstados(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return _estadosDeSoportesRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        [ListadoDDL]
        public IEnumerable<PrioridadesDeSoportes> ListadoPrioridades(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return _prioridadesDeSoportesRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        /// <summary>
        /// Devuelve SoportesRepositorio para que lo use el Servicio base.
        /// </summary>
        /// <returns></returns>
        public override IRepositorio<Soportes, SoportesExt> GetRepositorio()
        {
            return _soportesRepositorio;
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _usuariosRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _estadosDeSoportesRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _prioridadesDeSoportesRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }
    }
}
