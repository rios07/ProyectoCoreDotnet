using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControladoresCore
{
    public class InformesController : ArchivosManagerController<Informes, InformesExt, InformesVM>
    {
        private IInformesServicio _informesServicio;

        public InformesController(IInformesServicio pInformesServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio,IArchivosServicio pArchivosServicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pArchivosServicio, pNotificacionesServicio)
        {
            _informesServicio = pInformesServicio;
        }

        public override IBaseServicios<Informes, InformesExt> GetServicio()
        {
            return _informesServicio;
        }

        

        public JsonResult CheckFecha(DateTime FechaDeInforme)
        {
            DateTime FechaMinima = new DateTime(1753, 01, 01);
            DateTime FechaMaxima = new DateTime(9999, 01, 01);
            DateTime FechaActual = (DateTime)FechaDeInforme;
            if ((FechaActual < FechaMinima) || FechaActual > FechaMaxima)
            {
                return Json("La fecha debe ser mayor a (01/01/1753)", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}
