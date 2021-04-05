using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;
using System.Collections.Generic;

namespace RepositoriosCore
{
    public interface IRelAsig_RolesDeUsuarios_A_UsuariosRepositorio : IRepositorio<RelAsig_RolesDeUsuarios_A_Usuarios, RelAsig_RolesDeUsuarios_A_UsuariosExt>
    {
        List<RelAsig_RolesDeUsuarios_A_Usuarios> ObtenerRoles(int pId, ref ControllerBag pControllerbag);
        bool UpdateRoles(RegistroRolesUsuarios pCambioRoles, ref ControllerBag pControllerBag);
    }

    public class RelAsig_RolesDeUsuarios_A_UsuariosRepositorio : BaseRepositorios<RelAsig_RolesDeUsuarios_A_Usuarios, RelAsig_RolesDeUsuarios_A_UsuariosExt>, IRelAsig_RolesDeUsuarios_A_UsuariosRepositorio
    {
        public RelAsig_RolesDeUsuarios_A_UsuariosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }

        public List<RelAsig_RolesDeUsuarios_A_Usuarios> ObtenerRoles(int pId, ref ControllerBag pControllerbag)
        {
            object data = new { UsuarioId = pId };
            return (List<RelAsig_RolesDeUsuarios_A_Usuarios>)CustomMultipleQuery<object, RelAsig_RolesDeUsuarios_A_Usuarios>(data, "usp_RelAsig_RolesDeUsuarios_A_Usuarios__Listado_by_@UsuarioId", ref pControllerbag);
        }

        public bool UpdateRoles(RegistroRolesUsuarios pCambioRoles, ref ControllerBag pControllerBag)
        {
            object usuarioId = new { UsuarioId = pCambioRoles.UsuarioID };
            CustomExecute(usuarioId, "usp_RelAsig_RolesDeUsuarios_A_Usuarios__Delete_by_@UsuarioId", ref pControllerBag);
            foreach (RelAsig_RolesDeUsuarios_A_Usuarios item in pCambioRoles.Roles)
            {
                if (item.Asignado == true) { 
                object pObj = new { item.RolDeUsuarioId, UsuarioId = pCambioRoles.UsuarioID, item.FechaDesde, item.FechaHasta, item.Id };
                CustomExecute(pObj, "usp_RelAsig_RolesDeUsuarios_A_Usuarios__Insert", ref pControllerBag);
                }
            }

            return true;
        }
    }
}
