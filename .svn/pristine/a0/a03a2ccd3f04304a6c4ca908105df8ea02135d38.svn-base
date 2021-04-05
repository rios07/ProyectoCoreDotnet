using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class ArchivosVM : BaseVM
    {
        public int RegistroId { get; set; }

        [Display(Name = "Nombre a mostrar")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100, MinimumLength = 1)]
        public string NombreAMostrar { get; set; }

        [StringLength(1000, MinimumLength = 1)]
        public string Observaciones { get; set; }
    }
}