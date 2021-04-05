using System.Web.Mvc;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

namespace ControladoresCore
{
    public class LogLoginsDeDispositivosController : BaseControladores<LogLoginsDeDispositivos,LogLoginsDeDispositivosExt,LogLoginsDeDispositivosVM>
    {

        private readonly ILogLoginsDeDispositivosServicio _logLoginsDeDispositivoServicio;
        public LogLoginsDeDispositivosController(ILogLoginsDeDispositivosServicio pLogLoginsDeDispositivoServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosServicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosServicio, pNotificacionesServicio)
        {
            _logLoginsDeDispositivoServicio = pLogLoginsDeDispositivoServicio;
        }

        public override IBaseServicios<LogLoginsDeDispositivos, LogLoginsDeDispositivosExt> GetServicio()
        {
            return  _logLoginsDeDispositivoServicio;
        }
    }
}