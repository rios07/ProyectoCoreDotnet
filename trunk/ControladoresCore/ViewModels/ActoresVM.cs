using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CustomDataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class ActoresVM : BaseVM
    {
        [Required]
        [Display(Name = "Tipo de actor")]
        public int TipoDeActorId { get; set; }

        public bool Activo { get; set; }
        public string TipoDeActor { get; set; }

        [Display(Name = "Código")]
        [Required]
        [StringLength(16, MinimumLength = 1)]
        public string Codigo { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nombre { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 1)]
        public string Email { get; set; }

        [Display(Name = "Email alternativo")]
        [StringLength(60)]
        [EmailAddress]
        public string Email2 { get; set; }

        [Display(Name = "Teléfono")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Telefono { get; set; }

        [Display(Name = "Teléfono alternativo")]
        [StringLength(50)]
        public string Telefono2 { get; set; }

        [Display(Name = "Dirección")]
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Direccion { get; set; }

        [AllowHtml] public string Observaciones { get; set; }

        public string Contexto { get; set; }
        //public string Contexto { get; set; }

        [Campo("TipoDeActorId")] public List<TiposDeActorVM> TiposDeActor { get; set; }
    }
}