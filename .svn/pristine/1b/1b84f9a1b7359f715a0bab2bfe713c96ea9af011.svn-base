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
    public class LogEnviosDeCorreosController : BaseControladores<LogEnviosDeCorreos, LogEnviosDeCorreosExt, LogEnviosDeCorreosVM>
    {
        private ILogEnviosDeCorreosServicio _LogEnviosDeCorreosServicio;

        public LogEnviosDeCorreosController(ILogEnviosDeCorreosServicio pLogEnviosDeCorreosServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _LogEnviosDeCorreosServicio = pLogEnviosDeCorreosServicio;
        }

        public override IBaseServicios<LogEnviosDeCorreos, LogEnviosDeCorreosExt> GetServicio()
        {
            return _LogEnviosDeCorreosServicio;
        }

    }
}

