using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControladoresCore
{
    public class NotificacionesController : BaseControladores<Notificaciones, NotificacionesExt, NotificacionesVM>
    {
        private INotificacionesServicio _NotificacionesServicio;

        public NotificacionesController(INotificacionesServicio pNotificacionesServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _NotificacionesServicio = pNotificacionesServicio;
        }

        public override IBaseServicios<Notificaciones, NotificacionesExt> GetServicio()
        {
            return _NotificacionesServicio;
        }

        public ActionResult InsertDirigido(string pTabla,int pId)
        {
            NotificacionesVM VM = new NotificacionesVM
            {
                Tabla = pTabla,
                RegistroId = pId
            };
            return View(VM);
        }
    }
}
