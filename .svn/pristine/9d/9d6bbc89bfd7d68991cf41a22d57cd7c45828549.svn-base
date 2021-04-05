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
    public class ProvinciasController : BaseControladores<Provincias, ProvinciasExt, ProvinciasVM>
    {
        private IProvinciasServicio _ProvinciasServicio;

        public ProvinciasController(IProvinciasServicio pProvinciasServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _ProvinciasServicio = pProvinciasServicio;
        }

        public override IBaseServicios<Provincias, ProvinciasExt> GetServicio()
        {
            return _ProvinciasServicio;
        }

    }
}