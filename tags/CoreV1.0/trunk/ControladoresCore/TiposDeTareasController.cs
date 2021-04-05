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
    public class TiposDeTareasController : BaseControladores<TiposDeTareas, TiposDeTareasExt, TiposDeTareasVM>
    {
        private ITiposDeTareasServicio _TiposDeTareasServicio;

        public TiposDeTareasController(ITiposDeTareasServicio pTiposDeTareasServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _TiposDeTareasServicio = pTiposDeTareasServicio;
        }

        public override IBaseServicios<TiposDeTareas, TiposDeTareasExt> GetServicio()
        {
            return _TiposDeTareasServicio;
        }

    }
}

