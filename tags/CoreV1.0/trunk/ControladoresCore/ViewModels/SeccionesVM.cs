using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class SeccionesVM : BaseVM
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(maximumLength: 30)]
        public string Nombre { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Observaciones { get; set; }

       
    }
}