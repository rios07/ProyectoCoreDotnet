using FuncionesCore;

namespace ModelosCore
{
    public class RolesDeUsuarios : BaseModelo
    {
        public string Nombre { get; set; }
        public string Observaciones { get; set; }
        public bool PermiteAsignacionDePermisos { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true; //TODO:Hacer validacion
        }
    }

    public class RolesDeUsuariosExt : RolesDeUsuarios
    {
    }
}