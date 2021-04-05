/* Ordenar por nombre los ussing */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CustomDataAnnotations;

namespace ControladoresCore.ViewModels
{
    /// <summary>
    ///     ViewModel de Informes.
    /// </summary>
    public class InformesVM : BaseVM //, IValidatableObject
    {
        //[Display(Name = "id del usuario")]
        //public string Usuario_Id { get; set; }
        [Display(Name = "Título")]
        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(150, MinimumLength = 3)]
        public string Titulo { get; set; }

        [AllowHtml]
        [Display(Name = "Contenido")]
        [Required(ErrorMessage = "El contenido es requerido")]
        [StringLength(2000, MinimumLength = 1)]
        public string Texto { get; set; }

        [StringLength(1000)] public string Observaciones { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [DataType(DataType.Text)]
        //[Remote("CheckFecha", "Informes")]
        public DateTime FechaDeInforme { get; set; }

        [Display(Name = "Fecha")] public string FechaDeInformeFormateado { get; set; }

        [Display(Name = "Categoría")]
        [Key]
        [Range(0, 9999)]
        [Required(ErrorMessage = "La categoría es requerida")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public int CategoriaDeInformeId { get; set; }

        [Display(Name = "Generada por")] public string Usuario { get; set; }

        public int? UsuarioId { get; set; } = -2;

        [Display(Name = "Activo")] public bool Activo { get; set; }

        [Display(Name = "Categoría")] public string CategoriaDeInforme { get; set; }
        //public bool Activo { get; set; }
        /* ver q tb usan virtual ICollection dentro del modelo*/


        [Display(Name = "Categoría")]
        [Campo("CategoriaDeInformeId")]
        public List<CategoriasDeInformesVM> Categorias { get; set; } //TODO: 

        [Display(Name = "Adjuntos")] public int CantidadDeAdjuntos { get; set; }


        public override string ToString()
        {
            return Titulo + "\t" + Texto + "\t" + FechaDeInforme + "\t" + CategoriaDeInforme;
        }
    }
}