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
    public class IconosCSSController : BaseControladores<IconosCSS, IconosCSSExt, IconosCSSVM>
    {
        private IIconosCSSServicio _IconosCSSServicio;

        public IconosCSSController(IIconosCSSServicio pIconosCSSServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _IconosCSSServicio = pIconosCSSServicio;
        }

        public override IBaseServicios<IconosCSS, IconosCSSExt> GetServicio()
        {
            return _IconosCSSServicio;
        }

    }
}