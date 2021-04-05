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
    public class RelAsig_Contactos_A_GruposDeContactosController : BaseControladores<RelAsig_Contactos_A_GruposDeContactos, RelAsig_Contactos_A_GruposDeContactosExt, RelAsig_Contactos_A_GruposDeContactosVM>
    {
        private IRelAsig_Contactos_A_GruposDeContactosServicio _RelAsig_Contactos_A_GruposDeContactosServicio;

        public RelAsig_Contactos_A_GruposDeContactosController(IRelAsig_Contactos_A_GruposDeContactosServicio pRelAsig_Contactos_A_GruposDeContactosServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _RelAsig_Contactos_A_GruposDeContactosServicio = pRelAsig_Contactos_A_GruposDeContactosServicio;
        }

        public override IBaseServicios<RelAsig_Contactos_A_GruposDeContactos, RelAsig_Contactos_A_GruposDeContactosExt> GetServicio()
        {
            return _RelAsig_Contactos_A_GruposDeContactosServicio;
        }

    }
}