using FuncionesCore;

namespace ModelosCore
{
    public class Tablas : BaseModelo
    {
        public string Nombre { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class TablasExt : Tablas
    {
    }
}