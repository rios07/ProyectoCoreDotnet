using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class LoginVM : BaseVM
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Debe ingresar un usuario")]
        [StringLength(40)]
        public string Usuario { get; set; }

        [Display(Name = "Contexto")]
        [Required(ErrorMessage = "Debe ingresar un contexto")]
        [StringLength(40)]
        public string Contexto { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(40)]
        public string Contraseña { get; set; }


        [Display(Name = "Android id")]
        public string AndroidId { get; set; }


        public string Imei { get; set; }
    }
}