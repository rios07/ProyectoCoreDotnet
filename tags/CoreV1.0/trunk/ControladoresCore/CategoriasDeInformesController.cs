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
    public class CategoriasDeInformesController : BaseControladores<CategoriasDeInformes, CategoriasDeInformesExt, CategoriasDeInformesVM>
    {
        private ICategoriasDeInformesServicio _CategoriasDeInformesServicio;

        public CategoriasDeInformesController(ICategoriasDeInformesServicio pCategoriasDeInformesServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _CategoriasDeInformesServicio = pCategoriasDeInformesServicio;
        }

        public override IBaseServicios<CategoriasDeInformes, CategoriasDeInformesExt> GetServicio()
        {
            return _CategoriasDeInformesServicio;
        }

        public ActionResult Listado_admin(string pParam = "")
        {
            return base.Listado(pParam);
        }
    }
}

