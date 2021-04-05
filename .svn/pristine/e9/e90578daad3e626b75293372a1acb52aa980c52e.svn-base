using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;

using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class LogErroresAppController : BaseControladores<LogErroresApp, LogErroresAppExt, LogErroresAppVM>
    {
        private ILogErroresAppServicio _LogErroresAppServicio;

        public LogErroresAppController(ILogErroresAppServicio pLogErroresAppServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _LogErroresAppServicio = pLogErroresAppServicio;
        }


        public override IBaseServicios<LogErroresApp, LogErroresAppExt> GetServicio()
        {
            return _LogErroresAppServicio;
        }

    }
}