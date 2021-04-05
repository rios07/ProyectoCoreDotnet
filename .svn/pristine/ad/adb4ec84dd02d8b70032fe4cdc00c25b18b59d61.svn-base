using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

namespace ControladoresCore
{
    public class ActoresController : BaseControladores<Actores, ActoresExt, ActoresVM>
    {
        private readonly IActoresServicio _actoresServicio;

        public ActoresController(IActoresServicio pActoresServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosServicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosServicio, pNotificacionesServicio)
        {
            _actoresServicio = pActoresServicio;
        }

        public override IBaseServicios<Actores, ActoresExt> GetServicio()
        {
            return _actoresServicio;
        }
    }
}