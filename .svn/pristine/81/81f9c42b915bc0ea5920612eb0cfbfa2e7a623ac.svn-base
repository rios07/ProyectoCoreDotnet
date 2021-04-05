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
    public class LogLoginsController : BaseControladores<LogLogins, LogLoginsExt, LogLoginsVM>
    {
        private ILogLoginsServicio _LogLoginsServicio;

        public LogLoginsController(ILogLoginsServicio pLogLoginsServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _LogLoginsServicio = pLogLoginsServicio;
        }

        public override IBaseServicios<LogLogins, LogLoginsExt> GetServicio()
        {
            return _LogLoginsServicio;
        }

    }
}