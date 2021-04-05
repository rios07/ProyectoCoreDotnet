using System;
using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class LogEnviosDeCorreosVM : BaseVM
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de envío")]
        public DateTime Fecha { get; set; }

        public string FechaFormateado { get; set; }
        public int EnvioDeCorreoId { get; set; }

        [Display(Name = "Enviado")] public bool Satisfactorio { get; set; }

        public string ObservacionesDeRevision { get; set; }
        public string Observaciones { get; set; }
        public int UsuarioId { get; set; } = -1;

        [Display(Name = "Originante")] public string UsuarioOriginante { get; set; }

        [Display(Name = "Destinatario")] public string UsuarioDestinatario { get; set; }

        public string Asunto { get; set; }
    }
}