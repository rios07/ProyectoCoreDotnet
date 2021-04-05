using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class PrioridadesDeSoportesVM : BaseVM
    {
        [StringLength(12)] public string Nombre { get; set; }

        [StringLength(1000)] public string Observaciones { get; set; }
    }
}