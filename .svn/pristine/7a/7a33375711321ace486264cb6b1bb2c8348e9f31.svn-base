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
    public class CuentasDeEnviosController : BaseControladores<CuentasDeEnvios, CuentasDeEnviosExt, CuentasDeEnviosVM>
    {
        private ICuentasDeEnviosServicio _CuentasDeEnviosServicio;

        public CuentasDeEnviosController(ICuentasDeEnviosServicio pCuentasDeEnviosServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _CuentasDeEnviosServicio = pCuentasDeEnviosServicio;
        }

        public override IBaseServicios<CuentasDeEnvios, CuentasDeEnviosExt> GetServicio()
        {
            return _CuentasDeEnviosServicio;
        }

    }
}

