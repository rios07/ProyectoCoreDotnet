using FuncionesCore;

namespace ModelosCore
{
    public class RelAsig_TiposDeContactos_A_Contextos : BaseModelo
    {
        public int TipoDeContactoId { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }

    public class RelAsig_TiposDeContactos_A_ContextosExt : RelAsig_TiposDeContactos_A_Contextos
    {
        public string Nombre { get; set; }
        public bool Asignado { get; set; }
        public int NumeroDeRegistro { get; set; }
        public string TipoDeContacto { get; set; }
    }
}