using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladoresCore.ViewModels
{
    public class ImportanciasDeTareasVM : BaseVM
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(maximumLength: 30)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Observaciones { get; set; }
        [Required(ErrorMessage = "La nomenclatura es obligatoria")]
        [StringLength(maximumLength: 12)]
        public string Nomenclatura { get; set; }
    }
}
