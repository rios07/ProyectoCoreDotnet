using System;
using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;

//hola 
namespace ControladoresCore
{
    public class ReservasDeRecursosController : BaseControladores<ReservasDeRecursos, ReservasDeRecursosExt, ReservasDeRecursosVM>
    {
        private IReservasDeRecursosServicio _ReservasDeRecursosServicio;
        private IRecursosServicio _recursosServicio;
        public ReservasDeRecursosController(IReservasDeRecursosServicio pReservasDeRecursosServicio,
                                            ILogErroresServicio pLogErroresServicio,
                                            IUsuariosServicio pUsuariosSevicio, 
                                            INotificacionesServicio pNotificacionesServicio,
                                            IRecursosServicio pRecursosServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _ReservasDeRecursosServicio = pReservasDeRecursosServicio;
            _recursosServicio = pRecursosServicio;
        }

        public override IBaseServicios<ReservasDeRecursos, ReservasDeRecursosExt> GetServicio()
        {
            return _ReservasDeRecursosServicio;
        }

        public JsonResult AprobarReserva(int pParam, string pObservacionesDelAprobador)
        {
            _ReservasDeRecursosServicio.AprobarReserva(pParam, pObservacionesDelAprobador, ref _controllerBag);
            if (_controllerBag.TieneErrores())
            {
                string contenido = _controllerBag[0].Contenido;
                _controllerBag.Clear();
                return Json(contenido, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EsResponsable(int pRecursoId)
        {
            _recursosServicio.SetDatosDeLogin(_ReservasDeRecursosServicio.GetDatosDeLogin());
            bool resp = _recursosServicio.EsResponsableDelRecurso(pRecursoId, ref _controllerBag);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Disponibilidad()
        {
            ReservasDeRecursosVM VM = new ReservasDeRecursosVM();
            CargarDDLs(VM,true);
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            return View(VM);
        }

        public JsonResult CheckearDisponibilidad(int pRecursoId, DateTime pFechaDeInicio, DateTime pFechaLimite)
        {
            _ReservasDeRecursosServicio.CheckearDisponibilidad(pRecursoId,pFechaDeInicio,pFechaLimite,ref _controllerBag);
            if (_controllerBag.TieneErrores())
            {
                string contenido = _controllerBag[0].Contenido;
                _controllerBag.Clear();
                return Json(contenido, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
 