using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FuncionesCore;

namespace ControladoresCore.ViewModels
{
    public class NotasVM : BaseVM
    {
        public int UsuarioId { get; set; } = -2;

        [Display(Name = "Icono")]
        public int IconoCSSId { get; set; }

        [Display(Name = "Creada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Fecha { get; set; } = FFechas.FechaAhora();

        public string FechaFormateado { get; set; }

        [Display(Name = " ")] public string IconoCSS { get; set; }

        [Display(Name = "Vencimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [DataType(DataType.Text)]

        // [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public DateTime FechaDeVencimiento { get; set; }

        public string FechaDeVencimientoFormateado { get; set; }

        [Display(Name = "Título")] [Required] public string Titulo { get; set; }

        [Required] public string Cuerpo { get; set; }

        [Display(Name = "Pública")] public bool CompartirConTodos { get; set; }

        [Display(Name = "Generada por")] public string Usuario { get; set; }

        public List<IconosCSSVM> IconosDDL { get; set; }
    }
}