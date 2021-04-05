using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControladoresCore.ViewModels
{
    public class CategoriasDeInformesVM : BaseVM
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string Nombre { get; set; }
        [AllowHtml]
        [StringLength(maximumLength: 1000, MinimumLength = 1)]
        public string Observaciones { get; set; }
        public bool Activo { get; set; }

    }
}