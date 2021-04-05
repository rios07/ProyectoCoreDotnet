using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ControladoresCore.ViewModels;

namespace ControladoresCore.ViewModels
{
    public class RecursosVM : BaseVM
    {
        public bool Activo { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }
        public string Observaciones { get; set; }
        [Display(Name = "Usuario responsable")]
        public int UsuarioResponsableId { get; set; }
        [Display(Name = "Usuario/s responsable/s")]
        public string UsuariosResponsables { get; set; }
        public List<UsuariosVM> UsuariosDDL { get; set; }
        //[Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Usuario/s responsable/s")]
        public int[] UsuarioIds { get; set; }
        [Display(Name = "Usuario/s responsable/s")]
        public string UsuariosIdsString { get; set; }
    }
}