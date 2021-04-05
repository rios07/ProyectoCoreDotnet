using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class PrioridadesDeSoportesVM : BaseVM
    {
        [StringLength(maximumLength: 12)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Observaciones { get; set; }

       
    }
}