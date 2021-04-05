using System.Web.Mvc;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

namespace ControladoresCore
{
    public class LogErroresController : BaseControladores<LogErrores, LogErroresExt, LogErroresVM>
    {
        private readonly ILogErroresServicio _logErroresServicio;

        public LogErroresController(ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuarioServicio,
            INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuarioServicio,
            pNotificacionesServicio)
        {
            _logErroresServicio = pLogErroresServicio;
        }

        public override IBaseServicios<LogErrores, LogErroresExt> GetServicio()
        {
            return _logErroresServicio;
        }

        [HttpPost]
        public ActionResult Delete(int pId, FormCollection pCollection)
        {
            try
            {
                return RedirectToAction("Listado");
            }
            catch
            {
                return View();
            }
        }
    }
}