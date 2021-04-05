using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladoresCore.ViewModels
{
    public class NotificacionesVM : BaseVM
    {
        public string Usuario { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Cuerpo { get; set; }
        public string Icono { get; set; }
        [Display(Name = "Icono")]
        public string IconoCSS { get; set; }

        public string Tabla { get; set; }
        [Display(Name = "Número")]
        public int Numero { get; set; }
        [Display(Name = "Fecha"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Required]
        [DataType(DataType.Text)]
       // [Remote("CheckFecha", "Informes")]
        public DateTime Fecha { get; set; }

        public string FechaParaListado { get; set; }

        public int RegistroId { get; set; }
        public int UsuarioDestinatarioId { get; set; }
        public int CantRegistros { get; set; }
        public bool Nueva { get; set; }
        [Display(Name = "Antigüedad")]
        public string Antiguedad { get; set; }
        [Display(Name ="Leída")]
        public bool Leida { get; set; }


    }
}
