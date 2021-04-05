using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class PassVM : BaseVM
    {
        [Display(Name = "Contraseña antigua")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(150, MinimumLength = 6)]
        public string PassActual { get; set; }

        [Display(Name = "Nueva contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(150, MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",
            ErrorMessage = "La contraseña debe tener una Mayuscula, una minuscula y un numero")]
        [DataType(DataType.Password)]
        public string PassNuevo { get; set; }

        [Display(Name = "Repetir contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(150, MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",
            ErrorMessage = "La contraseña debe tener una Mayuscula, una minuscula y un numero")]
        [DataType(DataType.Password)]
        [Compare("PassNuevo")]
        public string ConfirmarPass { get; set; }
    }
}