using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore
{
    public interface IRelAsig_RolesDeUsuarios_A_PaginasServicio : IBaseServicios<RelAsig_RolesDeUsuarios_A_Paginas, RelAsig_RolesDeUsuarios_A_PaginasExt>
    {

    }
    public class RelAsig_RolesDeUsuarios_A_PaginasServicio : BaseServicios<RelAsig_RolesDeUsuarios_A_Paginas, RelAsig_RolesDeUsuarios_A_PaginasExt>, IRelAsig_RolesDeUsuarios_A_PaginasServicio
    {
        private IRelAsig_RolesDeUsuarios_A_PaginasRepositorioRepositorio _RolPaginaRepositorio;
        private IRolesRepositorio _rolesRepositorio;
        private ITablasRepositorio _tablasRepositorio;

        public RelAsig_RolesDeUsuarios_A_PaginasServicio(IRelAsig_RolesDeUsuarios_A_PaginasRepositorioRepositorio pRolPaginaRepositorio, IRolesRepositorio pRolesRepositorio, ITablasRepositorio pTablasRepositorio)
        {
            _RolPaginaRepositorio = pRolPaginaRepositorio;
            _rolesRepositorio = pRolesRepositorio;
            _tablasRepositorio = pTablasRepositorio;
        }

        public override IRepositorio<RelAsig_RolesDeUsuarios_A_Paginas, RelAsig_RolesDeUsuarios_A_PaginasExt> GetRepositorio()
        {
            return _RolPaginaRepositorio;
        }

        [ListadoDDL]
        public IEnumerable<RolesDeUsuarios> ListadoRolesDe_Usuarios(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _rolesRepositorio.SetDatosDeLogin(GetDatosDeLogin());
            return _rolesRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        [ListadoDDL]
        public List<TablasExt> TablasDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _tablasRepositorio.SetDatosDeLogin(GetDatosDeLogin());
            return (List<TablasExt>)_tablasRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }
    }

}

