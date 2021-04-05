using System.Web.Mvc;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class RelAsig_TiposDeContactos_A_ContextosController : BaseControladores<RelAsig_TiposDeContactos_A_Contextos
        , RelAsig_TiposDeContactos_A_ContextosExt, RelAsig_TiposDeContactos_A_ContextosVM>
    {
        private readonly IRelAsig_TiposDeContactos_A_ContextosServicio _RelAsig_TiposDeContactos_A_ContextosServicio;

        public RelAsig_TiposDeContactos_A_ContextosController(
            IRelAsig_TiposDeContactos_A_ContextosServicio pRelAsig_TiposDeContactos_A_ContextosServicio,
            ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _RelAsig_TiposDeContactos_A_ContextosServicio = pRelAsig_TiposDeContactos_A_ContextosServicio;
        }

        public override IBaseServicios<RelAsig_TiposDeContactos_A_Contextos, RelAsig_TiposDeContactos_A_ContextosExt>
            GetServicio()
        {
            return _RelAsig_TiposDeContactos_A_ContextosServicio;
        }

        public JsonResult SwapAsignacion(int pTipoDeContactoId)
        {
            return Json(
                _RelAsig_TiposDeContactos_A_ContextosServicio.SwapAsignacion(pTipoDeContactoId, ref _controllerBag),
                JsonRequestBehavior.AllowGet);
        }
    }
}