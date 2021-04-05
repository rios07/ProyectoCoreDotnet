using System.Web.Mvc;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class NotasController : BaseControladores<Notas, NotasExt, NotasVM>
    {
        private readonly IIconosCSSServicio _iconosCssServicio;
        private readonly INotasServicio _NotasServicio;

        public NotasController(INotasServicio pNotasServicio,
            ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio,
            INotificacionesServicio pNotificacionesServicio,
            IIconosCSSServicio pIconosCSSServicio) : base(pLogErroresServicio, pUsuariosSevicio,
            pNotificacionesServicio)
        {
            _NotasServicio = pNotasServicio;
            _iconosCssServicio = pIconosCSSServicio;
        }

        public override IBaseServicios<Notas, NotasExt> GetServicio()
        {
            return _NotasServicio;
        }


        public JsonResult GetIcon(int IconoCSSId)
        {
            _iconosCssServicio.SetDatosDeLogin(_NotasServicio.GetDatosDeLogin());
            IconosCSS icon = _iconosCssServicio.Registro(IconoCSSId, ref _controllerBag);
            var css = icon.CSS;
            return Json(css, JsonRequestBehavior.AllowGet);
        }
    }
}