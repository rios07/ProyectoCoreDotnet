using System.Web.Mvc;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class CategoriasDeInformesController : BaseControladores<CategoriasDeInformes, CategoriasDeInformesExt,
        CategoriasDeInformesVM>
    {
        private readonly ICategoriasDeInformesServicio _CategoriasDeInformesServicio;

        public CategoriasDeInformesController(ICategoriasDeInformesServicio pCategoriasDeInformesServicio,
            ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio,
            INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio,
            pNotificacionesServicio)
        {
            _CategoriasDeInformesServicio = pCategoriasDeInformesServicio;
        }

        public override IBaseServicios<CategoriasDeInformes, CategoriasDeInformesExt> GetServicio()
        {
            return _CategoriasDeInformesServicio;
        }

        public ActionResult Listado_admin(string pParam = "")
        {
            return base.Listado(pParam);
        }
    }
}