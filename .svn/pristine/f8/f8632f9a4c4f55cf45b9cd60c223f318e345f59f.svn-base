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
    public class RelAsig_RolesDeUsuarios_A_PaginasController : BaseControladores<RelAsig_RolesDeUsuarios_A_Paginas, RelAsig_RolesDeUsuarios_A_PaginasExt, RelAsig_RolesDeUsuarios_A_PaginasVM>
    {
        private IRelAsig_RolesDeUsuarios_A_PaginasServicio _rolPaginaServicio;
        private IPaginasServicio _paginasServicio;

        public RelAsig_RolesDeUsuarios_A_PaginasController(IRelAsig_RolesDeUsuarios_A_PaginasServicio pRolPaginaServicio, ILogErroresServicio pLogErroresServicio, IPaginasServicio pPaginasServicio, IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _rolPaginaServicio = pRolPaginaServicio;
            _paginasServicio = pPaginasServicio;
        }

        public override IBaseServicios<RelAsig_RolesDeUsuarios_A_Paginas, RelAsig_RolesDeUsuarios_A_PaginasExt> GetServicio()
        {
            return _rolPaginaServicio;
        }

        public JsonResult UpdateEnListado(RelAsig_RolesDeUsuarios_A_PaginasVM pPermisos)
        {
            RelAsig_RolesDeUsuarios_A_Paginas model = new RelAsig_RolesDeUsuarios_A_Paginas
            {
                AutorizadoA_CargarLaPagina = pPermisos.AutorizadoA_CargarLaPagina,
                AutorizadoA_AccionesEspeciales = pPermisos.AutorizadoA_AccionesEspeciales,
                AutorizadoA_OperarLaPagina = pPermisos.AutorizadoA_OperarLaPagina,
                AutorizadoA_VerRegAnulados = pPermisos.AutorizadoA_VerRegAnulados,
                Id = pPermisos.Id
            };
            _rolPaginaServicio.Update(model, ref _controllerBag);
            if (_controllerBag.TieneErrores())
            {
                return Json(new { Resultado = false },JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Resultado = true }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}

