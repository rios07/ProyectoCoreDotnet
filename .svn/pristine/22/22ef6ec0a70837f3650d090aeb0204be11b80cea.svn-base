using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ControladoresCore.ViewModels;

namespace ControladoresCore.ViewModels
{
    public class RolesDeUsuariosVM : BaseVM
    {
        [StringLength(maximumLength: 30)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Observaciones { get; set; }
        public bool PermiteAsignacionDePermisos { get; set; }

    }
}