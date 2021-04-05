using CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControladoresCore.ViewModels
{
    public class TareasVM : BaseVM
    {
        public int Numero { get; set; }

        [Required(ErrorMessage = "El usuario interesado es obligatorio"), Display(Name = "Usuario interesado")]
        public int UsuarioOriginanteId { get; set; }

        [Required(ErrorMessage = "El usuario destinatario es obligatorio"), Display(Name = "Usuario destinatario")]
        public int UsuarioDestinatarioId { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria"), Display(Name = "Fecha de inicio"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeInicio { get; set; }
        public string FechaDeInicioParaListado { get; set; }

        [Display(Name = "Fecha límite"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaLimite { get; set; }
        public string FechaLimiteParaListado { get; set; }

        [Required(ErrorMessage = "El tipo de tarea es obligatoria"), Display(Name = "Tipo de tarea")]
        public int TipoDeTareaId { get; set; }

        [Required,Display(Name = "Estado de tarea")]
        public int EstadoDeTareaId { get; set; } = 1;

        [Required(ErrorMessage = "La importancia de tarea es obligatoria"), Display(Name = "Importancia de tarea")]
        public int ImportanciaDeTareaId { get; set; }

        public int RegistroId { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio"), Display(Name = "Título"), StringLength(maximumLength: 100)]
        public string Titulo { get; set; }

        [Display(Name = "Observaciones"), StringLength(maximumLength: 2000), AllowHtml]
        public string Observaciones { get; set; }

        public string TablaDeReferencia { get; set; }

        [Campo("TipoDeTareaId")]
        public List<TiposDeTareasVM> TiposDeTareas { get; set; }

        [Display(Name = "Tipo")]
        public string TipoDeTarea { get; set; }

        [Campo("EstadoDeTareaId")]
        public List<EstadosDeTareasVM> EstadosDeTareas { get; set; }

        [Display(Name = "Estado ")]
        public string EstadoDeTarea { get; set; }

        [Campo("ImportanciaDeTareaId")]
        public List<ImportanciasDeTareasVM> Importancias { get; set; }

        [Display(Name = "Importancia")]
        public string ImportanciaDeTarea { get; set; }

        [Campo("UsuarioDestinatarioId")]
        public List<UsuariosVM> Usuarios { get; set; }

        public string Usuario { get; set; }


        public bool Activo { get; set; }

        [Display(Name = "Destinatario")]
        public string UsuarioDestinatario { get; set; }

        [Display(Name = "Usuario originante")]
        public string UsuarioOriginante { get; set; }

        public string RegistroDeReferencia { get; set; }

        [Display(Name = "¿Enviar correo?")]
        public bool EnviarCorreo { get; set; }

    }
}

