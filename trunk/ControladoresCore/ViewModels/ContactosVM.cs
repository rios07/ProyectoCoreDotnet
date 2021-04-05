using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class ContactosVM : BaseVM
    {
        [Display(Name = "Es una Organización?")]
        public bool EsUnaOrganizacion { get; set; }

        [Display(Name = "Organización")]
        [StringLength(100)] public string Organizacion { get; set; }

        [Display(Name = "Nombre completo")]
        [StringLength(150)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string NombreCompleto { get; set; }

        [StringLength(50)] public string Alias { get; set; }

        [Display(Name = "Relación")]
        [StringLength(50)]
        public string RelacionConElContacto { get; set; }

        [RegularExpression(
            @"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = "El email no es valido")]
        [StringLength(60)]
        public string Email { get; set; }

        [Display(Name = "Email secundario")]
        [StringLength(60)]
        [RegularExpression(
            @"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = "El email no es valido")]
        public string Email2 { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(60)]
        public string Telefono { get; set; }

        [StringLength(60)]
        [Display(Name = "Teléfono secundario")]
        public string Telefono2 { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(1000)]
        public string Direccion { get; set; }

        [StringLength(255)] public string Url { get; set; }

        public string Observaciones { get; set; }

        [Display(Name = "Tipo De Contacto")]
        [Required(ErrorMessage = "El tipo de contacto es obligatorio")]
        public int[] TiposDeContactosIds { get; set; }

        public List<TiposDeContactosVM> TiposDeContactos { get; set; }

        //public bool Activo { get; set; }

        [Display(Name = "Tipos")] public string TiposDeContacto { get; set; }

        public string TipoDeContactoIdsString { get; set; }

        [Display(Name = "Grupos del contacto")]
        public string GruposDeContacto { get; set; }

        public List<GruposDeContactosVM> GruposDeContactos { get; set; }
        public List<GruposDeContactosVM> GruposDelContacto { get; set; }
        public int[] GrupoDeContactoId { get; set; }

        public string GrupoDeContactoIdsString { get; set; }
        //public int GrupoDeContactoId { get; set; }
    }
}