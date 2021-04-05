using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class EstadosDeSoportesVM : BaseVM
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30)]
        public string Nombre { get; set; }

        [StringLength(1000)] public string Observaciones { get; set; }
    }
}