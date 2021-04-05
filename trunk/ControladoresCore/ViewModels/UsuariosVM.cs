using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomDataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class UsuariosVM : BaseVM
    {
        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9]+$",
            ErrorMessage = "Los caracteres ':' , '.' , ';' , ',' , '*' , ' ' , '/' y '\' no están permitidos")]
        [StringLength(40, MinimumLength = 1)]
        public string UserName { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(40, MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",
            ErrorMessage = "La contraseña debe tener una Mayúscula, una minúscula y un numero")]
        public string Pass { get; set; }

        [Compare("Pass", ErrorMessage = "Las contraseñas no coinciden")]
        [Display(Name = "Repetir contraseña(*)")]
        public string PassConfirmar { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(40, MinimumLength = 2)]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(40, MinimumLength = 2)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [Display(Name = "Email")]
        [EmailAddress]
        [StringLength(60, MinimumLength = 8)]
        public string Email { get; set; }

        [Display(Name = "Email alternativo")]
        [StringLength(60)]
        public string Email2 { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(60)]
        public string Telefono { get; set; }

        [Display(Name = "Teléfono alternativo")]
        [StringLength(60)]
        public string Telefono2 { get; set; }

        [Display(Name = "Nombre completo")] public string NombreCompleto { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(1000)]
        public string Direccion { get; set; }

        [StringLength(1000)] public string Observaciones { get; set; }

        public string UltimoLoginSesionId { get; set; }

        [Display(Name = "Rol de usuario")] public int RolDeUsuarioId { get; set; }


        //public Operacion Operacion { get; set; }

        //[Display(Name = "Título"), Required(ErrorMessage = "El título es requerido"), StringLength(maximumLength: 150, MinimumLength = 3)]
        public bool Activo { get; set; }


        [Campo("RolDeUsuarioId")] public List<RolesDe_UsuariosVM> Roles { get; set; }

        public string CodigoDelContexto { get; set; }

        [Display(Name = "Roles del usuario")] public string RolesDeUsuario { get; set; }
    }
}