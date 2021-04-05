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
    public class LogRegistrosController : BaseControladores<LogRegistros, LogRegistrosExt, LogRegistrosVM>
    {
        private ILogRegistrosServicio _LogRegistrosServicio;
        

        public LogRegistrosController(ILogRegistrosServicio pLogRegistrosServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _LogRegistrosServicio = pLogRegistrosServicio;
        }

        public override IBaseServicios<LogRegistros, LogRegistrosExt> GetServicio()
        {
            return _LogRegistrosServicio;
        }

    }
}

