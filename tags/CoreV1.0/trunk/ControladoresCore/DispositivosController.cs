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
    public class DispositivosController : BaseControladores<Dispositivos, DispositivosExt, DispositivosVM>
    {
        private IDispositivosServicio _DispositivosServicio;

        public DispositivosController(IDispositivosServicio pDispositivosServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _DispositivosServicio = pDispositivosServicio;
        }

        public override IBaseServicios<Dispositivos, DispositivosExt> GetServicio()
        {
            return _DispositivosServicio;
        }

    }
}

