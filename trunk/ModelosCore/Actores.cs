using FuncionesCore;

namespace ModelosCore
{
    public class Actores : BaseModelo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int TipoDeActorId { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }


        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true; //TODO:Hacer validacion
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }

    public class ActoresExt : Actores
    {
        public bool Activo { get; set; }
        public string TipoDeActor { get; set; }
        public string Contexto { get; set; }
    }
}