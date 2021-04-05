using System;
using System.Web.Mvc;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

namespace ControladoresCore
{
    public class NotificacionesController : BaseControladores<Notificaciones, NotificacionesExt, NotificacionesVM>
    {
        private readonly INotificacionesServicio _NotificacionesServicio;

        public NotificacionesController(INotificacionesServicio pNotificacionesServicio,
            ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio) : base(pLogErroresServicio,
            pUsuariosSevicio, pNotificacionesServicio)
        {
            _NotificacionesServicio = pNotificacionesServicio;
        }

        public override IBaseServicios<Notificaciones, NotificacionesExt> GetServicio()
        {
            return _NotificacionesServicio;
        }

        public ActionResult InsertDirigido(string pTabla, int pId)
        {
            var VM = new NotificacionesVM
            {
                Tabla = pTabla,
                RegistroId = pId
            };
            return View(VM);
        }

        public JsonResult MarcarLeidaMulti(int[] pIds)
        {
            try
            {
                foreach (int pId in pIds)
                {
                    base.NotificacionVista(pId);
                }
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }

        }
    }
}