using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System.Collections.Generic;
using System.Web.Mvc;

//hola 
namespace ControladoresCore
{
    public class TiposDeContactosController : BaseControladores<TiposDeContactos, TiposDeContactosExt, TiposDeContactosVM>
    {
        private ITiposDeContactosServicio _TiposDeContactosServicio;

        public TiposDeContactosController(ITiposDeContactosServicio pTiposDeContactosServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _TiposDeContactosServicio = pTiposDeContactosServicio;
        }

        public override IBaseServicios<TiposDeContactos, TiposDeContactosExt> GetServicio()
        {
            return _TiposDeContactosServicio;
        }

        public override ActionResult Insert(string pTabla = "", int pRegistroId = 1)
        {
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            return base.Insert(pTabla, pRegistroId);
        }

        public override ActionResult Registro(int pParam)
        {
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            return base.Registro(pParam);
        }

        public override ActionResult Listado(string pParam = "")
        {
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            return base.Listado(pParam);
        }
    }
}