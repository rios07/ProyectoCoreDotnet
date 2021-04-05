using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

namespace ControladoresCore
{
    public class SoportesController : ArchivosManagerController<Soportes, SoportesExt, SoportesVM>
    {
        private readonly ISoportesServicio _soportesServicio;

        public SoportesController(ISoportesServicio pSoportesServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, IArchivosServicio pArchivosServicio,
            INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio,
            pArchivosServicio, pNotificacionesServicio)
        {
            _soportesServicio = pSoportesServicio;
        }

        public override IBaseServicios<Soportes, SoportesExt> GetServicio()
        {
            return _soportesServicio;
        }
    }
}