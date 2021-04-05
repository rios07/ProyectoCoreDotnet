using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControladoresCore.ViewModels
{
    public class TiposDeActorVM : BaseVM
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(maximumLength: 30)]
        public string Nombre { get; set; }
        [AllowHtml]
        [StringLength(maximumLength: 1000)]
        public string Observaciones { get; set; }
        public bool Activo { get; set; }

    }
}
