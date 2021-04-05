using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;

using ServiciosCore;

using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;

//hola 
namespace ControladoresCore
{
    public class NotasController : BaseControladores<Notas, NotasExt, NotasVM>
    {
        private INotasServicio _NotasServicio;
        private IIconosCSSServicio _iconosCssServicio;
        public NotasController(INotasServicio pNotasServicio,
                               ILogErroresServicio pLogErroresServicio,
                               IUsuariosServicio pUsuariosSevicio,
                               INotificacionesServicio pNotificacionesServicio,
                               IIconosCSSServicio pIconosCSSServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
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
            string css = icon.CSS;
            return Json(css, JsonRequestBehavior.AllowGet);
        }

    }
}