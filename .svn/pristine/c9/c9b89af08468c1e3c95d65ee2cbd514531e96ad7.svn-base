using System.Web.Mvc;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class RelAsig_RolesDeUsuarios_A_PaginasController : BaseControladores<RelAsig_RolesDeUsuarios_A_Paginas,
        RelAsig_RolesDeUsuarios_A_PaginasExt, RelAsig_RolesDeUsuarios_A_PaginasVM>
    {
        private IPaginasServicio _paginasServicio;
        private readonly IRelAsig_RolesDeUsuarios_A_PaginasServicio _rolPaginaServicio;

        public RelAsig_RolesDeUsuarios_A_PaginasController(
            IRelAsig_RolesDeUsuarios_A_PaginasServicio pRolPaginaServicio, ILogErroresServicio pLogErroresServicio,
            IPaginasServicio pPaginasServicio, IUsuariosServicio pUsuariosSevicio,
            INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio,
            pNotificacionesServicio)
        {
            _rolPaginaServicio = pRolPaginaServicio;
            _paginasServicio = pPaginasServicio;
        }

        public override IBaseServicios<RelAsig_RolesDeUsuarios_A_Paginas, RelAsig_RolesDeUsuarios_A_PaginasExt>
            GetServicio()
        {
            return _rolPaginaServicio;
        }

        public JsonResult UpdateEnListado(RelAsig_RolesDeUsuarios_A_PaginasVM pPermisos)
        {
            var model = new RelAsig_RolesDeUsuarios_A_Paginas
            {
                AutorizadoA_CargarLaPagina = pPermisos.AutorizadoA_CargarLaPagina,
                AutorizadoA_AccionesEspeciales = pPermisos.AutorizadoA_AccionesEspeciales,
                AutorizadoA_OperarLaPagina = pPermisos.AutorizadoA_OperarLaPagina,
                AutorizadoA_VerRegAnulados = pPermisos.AutorizadoA_VerRegAnulados,
                Id = pPermisos.Id
            };
            _rolPaginaServicio.Update(model, ref _controllerBag);
            if (_controllerBag.TieneErrores())
                return Json(new {Resultado = false}, JsonRequestBehavior.AllowGet);
            return Json(new {Resultado = true}, JsonRequestBehavior.AllowGet);
        }
    }
}