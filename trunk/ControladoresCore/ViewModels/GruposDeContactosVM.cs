using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class GruposDeContactosVM : BaseVM
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30)]
        public string Nombre { get; set; }

        [StringLength(1000)] public string Observaciones { get; set; }

        public List<ContactosVM> Contactos { get; set; }
        public List<ContactosVM> ContactosDeGrupo { get; set; }
        public int[] ContactosIds { get; set; }
        public string ContactoIdsString { get; set; }

        [Display(Name = "Contactos")] public string ContactosDelGrupo { get; set; }
    }
}