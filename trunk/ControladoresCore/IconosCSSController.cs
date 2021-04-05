using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class IconosCSSController : BaseControladores<IconosCSS, IconosCSSExt, IconosCSSVM>
    {
        private readonly IIconosCSSServicio _IconosCSSServicio;

        public IconosCSSController(IIconosCSSServicio pIconosCSSServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _IconosCSSServicio = pIconosCSSServicio;
        }

        public override IBaseServicios<IconosCSS, IconosCSSExt> GetServicio()
        {
            return _IconosCSSServicio;
        }
    }
}