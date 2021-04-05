using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class
        LogEnviosDeCorreosController : BaseControladores<LogEnviosDeCorreos, LogEnviosDeCorreosExt, LogEnviosDeCorreosVM
        >
    {
        private readonly ILogEnviosDeCorreosServicio _LogEnviosDeCorreosServicio;

        public LogEnviosDeCorreosController(ILogEnviosDeCorreosServicio pLogEnviosDeCorreosServicio,
            ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio,
            INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio,
            pNotificacionesServicio)
        {
            _LogEnviosDeCorreosServicio = pLogEnviosDeCorreosServicio;
        }

        public override IBaseServicios<LogEnviosDeCorreos, LogEnviosDeCorreosExt> GetServicio()
        {
            return _LogEnviosDeCorreosServicio;
        }
    }
}