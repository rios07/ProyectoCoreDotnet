using FuncionesCore;

namespace ModelosCore
{
    public class RelAsig_Contactos_A_TiposDeContactos : BaseModelo
    {
        public int ContactoId { get; set; }
        public string TipoDeContactoIdsString { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }

    public class RelAsig_Contactos_A_TiposDeContactosExt : RelAsig_Contactos_A_TiposDeContactos
    {
    }
}