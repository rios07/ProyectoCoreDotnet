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
    public interface IRelAsig_RolesDeUsuarios_A_UsuariosServicio : IBaseServicios<RelAsig_RolesDeUsuarios_A_Usuarios, RelAsig_RolesDeUsuarios_A_UsuariosExt>
    {
        List<RelAsig_RolesDeUsuarios_A_Usuarios> ObtenerRoles(int pId, ref ControllerBag pControllerbag);
        bool UpdateRoles(RegistroRolesUsuarios pCambioRoles, ref ControllerBag pControllerBag);
    }
    public class RelAsig_RolesDeUsuarios_A_UsuariosServicio : BaseServicios<RelAsig_RolesDeUsuarios_A_Usuarios, RelAsig_RolesDeUsuarios_A_UsuariosExt>, IRelAsig_RolesDeUsuarios_A_UsuariosServicio
    {
        private IRelAsig_RolesDeUsuarios_A_UsuariosRepositorio _rolUsuarioRepositorio;
        private IUsuariosRepositorio _usuariosRepositorio;
        public RelAsig_RolesDeUsuarios_A_UsuariosServicio(IRelAsig_RolesDeUsuarios_A_UsuariosRepositorio pRolUsuarioRepositorio, IUsuariosRepositorio pUsuariosRepositorio)
        {
            _rolUsuarioRepositorio = pRolUsuarioRepositorio;
            _usuariosRepositorio = pUsuariosRepositorio;
        }
        public List<RelAsig_RolesDeUsuarios_A_Usuarios> ObtenerRoles(int pId, ref ControllerBag pControllerbag)
        {
            return _rolUsuarioRepositorio.ObtenerRoles(pId,ref pControllerbag);
        }
        public override IRepositorio<RelAsig_RolesDeUsuarios_A_Usuarios, RelAsig_RolesDeUsuarios_A_UsuariosExt> GetRepositorio()
        {
            return _rolUsuarioRepositorio;
        }

        public bool UpdateRoles(RegistroRolesUsuarios pCambioRoles, ref ControllerBag pControllerBag)
        {

            return _rolUsuarioRepositorio.UpdateRoles(pCambioRoles, ref pControllerBag);
        }

        [ListadoDDL]
        public List<UsuariosExt> CargarUsuariosDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {

            return (List<UsuariosExt>)_usuariosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }
    }

}
