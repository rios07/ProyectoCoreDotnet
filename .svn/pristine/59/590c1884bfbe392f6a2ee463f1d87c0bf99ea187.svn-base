using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControladoresCore.ViewModels
{
    public class DispositivosVM : BaseVM
    {

        [Display(Name = "Usuario asignado")]
        
        public int AsignadoAUsuarioId { get; set; }
        [StringLength(maximumLength: 50)]
        [Required]
        public string MachineName { get; set; }

        [StringLength(maximumLength: 100)]
        [Required]
        public string OSVersion { get; set; }

        [StringLength(maximumLength: 50)]
        public string UserMachineName { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Observaciones { get; set; }

        [Display(Name = "Clave privada entregada")]
        public bool ClavePrivadaEntregada { get; set; }

        [Display(Name = "Clave privada")]
        [Required]
        public string ClavePrivada { get; set; }

        [Display(Name = "Fecha de entrega de clave")]
        public DateTime ClavePrivadaFechaEntrega { get; set; }

        //public string ClavePrivadaEntregada { get; set; }
        //public DateTime ClavePrivadaFechaEntrega { get; set; }
        //public bool ClavePrivadaEntregada { get; set; }


        //----------SALIDA-----------//
        public bool Activo { get; set; }
        [Display(Name = "Usuario asignado"), Required(ErrorMessage = "Campo obligatorio")]
        public string AsignadoAUsuario { get; set; }
        public List<UsuariosVM> Usuarios { get; set; }
    }
}