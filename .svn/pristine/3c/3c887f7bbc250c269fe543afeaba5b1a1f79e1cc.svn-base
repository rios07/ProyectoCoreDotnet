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
    public class EnviosDeCorreosController : BaseControladores<EnviosDeCorreos, EnviosDeCorreosExt, EnviosDeCorreosVM>
    {
        private IEnviosDeCorreosServicio _EnviosDeCorreosServicio;

        public EnviosDeCorreosController(IEnviosDeCorreosServicio pEnviosDeCorreosServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _EnviosDeCorreosServicio = pEnviosDeCorreosServicio;
        }

        public override IBaseServicios<EnviosDeCorreos, EnviosDeCorreosExt> GetServicio()
        {
            return _EnviosDeCorreosServicio;
        }

    }
}

