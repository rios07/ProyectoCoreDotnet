using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    /// <summary>
    ///     Aquí van los campos exclusivos de la tabla.
    /// </summary>
    public class Usuarios : BaseModelo
    {
        [Ignorar(Operacion.update)] public string UserName { get; set; }

        [Ignorar(Operacion.update)] public string Pass { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }

        [Ignorar(Operacion.update)] public int RolDeUsuarioId { get; set; }


        public override bool Valido(ref ControllerBag pControllerBag)
        {
            //if (UserName == null)
            //    pControllerBag.Add("El Nombre de Cuenta es obligatorio", true);
            //if (Nombre == null)
            //    pControllerBag.Add("La Contraseña es un campo obligatorio", true);
            //if (Pass == null)
            //    if (pControllerBag.Operacion != Operacion.update)
            //        pControllerBag.Add("El nombre es obligatorio", true);

            //if (Apellido == null)
            //    pControllerBag.Add("El apellido es obligatorio", true);

            return !pControllerBag.TieneElementos();
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }

    /// <summary>
    ///     Ext: Extension de campos, ya sea por datos correspondientes a las FK u otro motivo.
    /// </summary>
    public class UsuariosExt : Usuarios
    {
        public bool Activo { get; set; }


        public string RolesDeUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string CodigoDelContexto { get; set; }
    }
}