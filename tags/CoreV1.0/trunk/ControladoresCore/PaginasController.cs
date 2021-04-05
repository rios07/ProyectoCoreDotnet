using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControladoresCore
{

    public class PaginasController : BaseControladores<Paginas, PaginasExt, PaginasVM>
    {
        IPaginasServicio _paginasServicio;

        public PaginasController(IPaginasServicio paginasServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosServicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosServicio, pNotificacionesServicio)
        {
            _paginasServicio = paginasServicio;
        }

        public override IBaseServicios<Paginas, PaginasExt> GetServicio()
        {
            return _paginasServicio;
        }

        public override ActionResult Insert(PaginasVM pObj)
        {
            string idStrings = String.Join(",", pObj.RolesStringList);
            idStrings = idStrings + ",1";
            pObj.RolesIdsString_CargarLaPagina = idStrings;
            pObj.RolesIdsString_AccionesEspeciales = idStrings;
            pObj.RolesIdsString_OperarLaPagina = idStrings;
            pObj.RolesIdsString_OperarLaPagina = idStrings;
            return base.Insert(pObj);
        }
    }
}
