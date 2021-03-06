using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladoresCore.ViewModels
{
    public class  FuncionesDePaginasVM : BaseVM
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(maximumLength: 30)]
        public string Nombre { get; set; }

    }
}
