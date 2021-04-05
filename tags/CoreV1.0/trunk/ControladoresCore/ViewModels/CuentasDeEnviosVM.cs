using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControladoresCore.ViewModels
{
    public class CuentasDeEnviosVM : BaseVM
    {

        [StringLength(maximumLength: 40)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [StringLength(maximumLength: 60)]
        [EmailAddress(ErrorMessage = "Email no válido")]
        [Required(ErrorMessage = "El email es obligatorio")]
        [Display(Name = "Cuenta de Email")]
        public string CuentaDeEmail { get; set; }

        [StringLength(maximumLength: 40)]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [Display(Name = "Contraseña")]
        public string PwdDeEmail { get; set; }

        [StringLength(maximumLength: 60)]
        [Required(ErrorMessage = "El SMTP es obligatorio")]
        public string Smtp { get; set; }

        [Required(ErrorMessage = "El puerto es obligatorio")]
        public int Puerto { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Observaciones { get; set; }

    }
}