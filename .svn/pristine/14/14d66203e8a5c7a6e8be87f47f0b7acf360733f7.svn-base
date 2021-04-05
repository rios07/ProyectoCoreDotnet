using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    public class RelAsig_Usuarios_A_Recursos : BaseModelo
    {
        public int UsuarioId { get; set; }
        public int RecursoId { get; set; }

        [Ignorar(Operacion.update)]
        [Ignorar(Operacion.insert)]
        public string UsuarioIdsString { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }

    public class RelAsig_Usuarios_A_RecursosExt : RelAsig_Usuarios_A_Recursos
    {
        private string NombreCompleto { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
    }
}