using FuncionesCore;

namespace ModelosCore
{
    public class Secciones : BaseModelo
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

    public class SeccionesExt : Secciones
    {
    }
}