using FuncionesCore;

namespace ModelosCore
{
    public class IconosCSS : BaseModelo
    {
        public string Nombre { get; set; }
        public string CSS { get; set; }
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

    public class IconosCSSExt : IconosCSS
    {
    }
}