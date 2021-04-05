using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

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
        private readonly IEstadosDeSoportesRepositorio _estadosDeSoportesRepositorio;
        private readonly IPrioridadesDeSoportesRepositorio _prioridadesDeSoportesRepositorio;
        private readonly ISoportesRepositorio _soportesRepositorio;
        private readonly IUsuariosRepositorio _usuariosRepositorio;

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
        public IEnumerable<PrioridadesDeSoportes> ListadoPrioridades(ref ControllerBag pControllerBag, bool? pActivo,
            int pId)
        {
            return _prioridadesDeSoportesRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _usuariosRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _estadosDeSoportesRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _prioridadesDeSoportesRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }

        /// <summary>
        ///     Devuelve SoportesRepositorio para que lo use el Servicio base.
        /// </summary>
        /// <returns></returns>
        public override IRepositorio<Soportes, SoportesExt> GetRepositorio()
        {
            return _soportesRepositorio;
        }
    }
}