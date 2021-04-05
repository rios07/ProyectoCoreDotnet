using FuncionesCore;

namespace ModelosCore
{
    public class GruposDeContactos : BaseModelo
    {
        public string Nombre { get; set; }
        public string Observaciones { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }

    public class GruposDeContactosExt : GruposDeContactos
    {
        public string ContactoIdsString { get; set; }

        public string ContactosDelGrupo { get; set; }
    }
}