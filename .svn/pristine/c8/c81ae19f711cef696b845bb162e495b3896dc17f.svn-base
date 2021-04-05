using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FuncionesCore;

namespace ControladoresCore.ViewModels
{
    public class SoportesVM : BaseVM
    {
        [Display(Name = "Usuario que cerró")] public int UsuarioQueCerroId { get; set; } = 1;

        [Display(Name = "Usuario que solicita")]
        public int UsuarioQueSolicitaId { get; set; }

        [Display(Name = "Fecha de cierre")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Text)]
        public DateTime? FechaDeCierre { get; set; } = null;

        public string FechaDeCierreFormateado { get; set; }

        [Display(Name = "Texto(*)")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [AllowHtml]
        public string Texto { get; set; }

        [Display(Name = "Prioridad")] public int PrioridadDeSoporteId { get; set; } = 1;

        [Display(Name = "Estado")] public int EstadoDeSoporteId { get; set; } = 1;

        [Display(Name = "Usuario que cerró")] public string UsuarioQueCerro { get; set; }

        [Display(Name = "Usuario que solicitó")]
        public string UsuarioQueSolicita { get; set; }

        [Display(Name = "Prioridad")] public string PrioridadDeSoporte { get; set; }

        public Operacion Operacion { get; set; }

        public bool Activo { get; set; }

        //public List<PrioridadVM> Roles { get; set; }

        public string UsuarioQueEjecuta { get; set; }

        [Display(Name = "Email usuario que creó")]
        public string EmailUsuarioQueCreo { get; set; }

        [Display(Name = "Email usuario que solicitó")]
        public string EmailUsuarioQueSolicito { get; set; }

        [Display(Name = "Fecha de creación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Text)]
        public DateTime? FechaDeEjecucion { get; set; }

        public string FechaDeEjecucionFormateado { get; set; }
        public int Numero { get; set; }

        [Display(Name = "Estado")] public string EstadoDeSoporte { get; set; }

        public string ObservacionesDeEstadoDeSoportes { get; set; }
        public string Prioridad { get; set; }
        public string Observaciones { get; set; }
        public string ObservacionesPrivadas { get; set; }
        public bool Cerrado { get; set; }

        public List<UsuariosVM> Usuarios { get; set; }
        public List<EstadosDeSoportesVM> EstadosDeSoporte { get; set; }
        public List<PrioridadesDeSoportesVM> PrioridadesDeSoporte { get; set; }
    }
}