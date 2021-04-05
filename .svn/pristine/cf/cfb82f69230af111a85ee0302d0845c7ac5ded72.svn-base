using System.Collections.Generic;
using FuncionesCore;

namespace ModelosCore
{
    public class RegistroRolesUsuarios : BaseModelo
    {
        public List<Usuarios> Usuarios { get; set; }
        public string NombreUsuario { get; set; }
        public int UsuarioID { get; set; }
        public List<RelAsig_RolesDeUsuarios_A_Usuarios> Roles { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }
}