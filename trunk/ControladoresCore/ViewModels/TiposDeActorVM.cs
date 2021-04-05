using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControladoresCore.ViewModels
{
    public class TiposDeActorVM : BaseVM
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30)]
        public string Nombre { get; set; }

        [AllowHtml] [StringLength(1000)] public string Observaciones { get; set; }

        public bool Activo { get; set; }
    }
}