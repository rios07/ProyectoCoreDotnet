using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ControladoresCore.ViewModels
{
    public class TiposDeTareasVM : BaseVM
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(maximumLength: 30)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Observaciones { get; set; }

        public bool Activo { get; set; }
    }
}
