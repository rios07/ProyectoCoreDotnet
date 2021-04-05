using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;


namespace ControladoresCore.Base
{
    public class LogErroresAppController : BaseApiController<LogErroresApp, LogErroresAppExt, LogErroresAppVM>
    {
        private ILogErroresAppServicio _LogErroresAppServicio;
        private new string _seccion = "Administracion";
        public LogErroresAppController(ILogErroresAppServicio pLogErroresAppSevicio, ILogErroresServicio pLogErroresServicio): base(pLogErroresServicio)
        {
            _LogErroresAppServicio = pLogErroresAppSevicio;
        }

        protected override IBaseServicios<LogErroresApp, LogErroresAppExt> GetServicio()
        {
            return _LogErroresAppServicio;
        }

    }
}