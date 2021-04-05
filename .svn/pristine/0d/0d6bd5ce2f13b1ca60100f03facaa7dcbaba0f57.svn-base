using System;
using FuncionesCore;

namespace ModelosCore
{
    public class RelAsig_RolesDeUsuarios_A_Usuarios : BaseModelo
    {
        public string Rol { get; set; }
        public int RolDeUsuarioId { get; set; }
        public bool Asignado { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class RelAsig_RolesDeUsuarios_A_UsuariosExt : RelAsig_RolesDeUsuarios_A_Usuarios
    {
        public bool PermiteEdicion { get; set; }
    }
}