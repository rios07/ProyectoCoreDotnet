using FuncionesCore;

namespace ModelosCore
{
    public class RelAsig_RolesDeUsuarios_A_Paginas : BaseModelo
    {
        public bool AutorizadoA_CargarLaPagina { get; set; }
        public bool AutorizadoA_OperarLaPagina { get; set; }
        public bool AutorizadoA_VerRegAnulados { get; set; }
        public bool AutorizadoA_AccionesEspeciales { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class RelAsig_RolesDeUsuarios_A_PaginasExt : RelAsig_RolesDeUsuarios_A_Paginas
    {
        public string Pagina { get; set; }
        public string Seccion { get; set; }
        public string RolDeUsuario { get; set; }
        public int RolDeUsuarioId { get; set; }
    }
}