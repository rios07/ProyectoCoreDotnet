using FuncionesCore;

namespace ModelosCore
{
    public class Pass : BaseModelo
    {
        public string PassActual { get; set; }

        public string PassNuevo { get; set; }
        //public DateTime FechaDeEjecucion { get; set; } = DateTime.Today;

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            if (PassActual == null) pControllerBag.Add("La Contraseña es un campo obligatorio", true);
            if (PassNuevo == null) pControllerBag.Add("La Contraseña es un campo obligatorio", true);
            return true;
        }
    }
}