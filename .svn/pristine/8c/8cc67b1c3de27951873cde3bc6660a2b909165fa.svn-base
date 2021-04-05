using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladoresCore.ViewModels
{
    public class ArchivosVM : BaseVM
    {
        public int RegistroId { get; set; }
        [Display(Name = "Nombre a mostrar"), Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string NombreAMostrar { get; set; }
        [StringLength(maximumLength: 1000, MinimumLength = 1)]
        public string Observaciones { get; set; }

       
    }
}
