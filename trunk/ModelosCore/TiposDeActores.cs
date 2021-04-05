using FuncionesCore;

namespace ModelosCore
{
    public class TiposDeActores : BaseModelo
    {
        public string Nombre { get; set; }
        public string Observaciones { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class TiposDeActoresExt : TiposDeActores
    {
        public bool Activo { get; set; }
    }
}