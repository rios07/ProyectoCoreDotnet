using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Web.Mvc;
using ControladoresCore.ViewModels;

namespace ControladoresCore.ViewModels
{
    public class ReservasDeRecursosVM : BaseVM
    {
        [Display(Name = "Usuario originante")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int UsuarioOriginanteId { get; set; }
        [Display(Name = "Usuario destinatario")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int UsuarioDestinatarioId { get; set; }
        [Display(Name = "Recurso")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int RecursoId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de pedido")]
        public DateTime FechaDePedido { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de aprobación")]
        public DateTime FechaDeAprobacion { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de inicio")]
        public DateTime FechaDeInicio { get; set; }
        public string FechaDeInicioParaListado { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha limite")]
        public DateTime FechaLimite { get; set; }
        public string FechaLimiteParaListado { get; set; }
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Display(Name = "Observaciones del originante")]
        public string ObservacionesDelOriginante { get; set; }
        [Display(Name = "Observaciones del aprobador")]
        public string ObservacionesDelAprobador { get; set; }
        [Display(Name = "Reserva aprobada")]
        public bool ReservaAprobada { get; set; }

        public List<UsuariosVM> UsuariosDDL { get; set; }
        public List<RecursosVM> RecursosDDL { get; set; }

        [Display(Name = "Usuario originante")]
        public string UsuarioOriginante { get; set; }
        [Display(Name = "Usuario destinatario")]
        public string UsuarioDestinatario { get; set; }
        public string Recurso { get; set; }

        public bool EsResponsable { get; set; }

    }
}