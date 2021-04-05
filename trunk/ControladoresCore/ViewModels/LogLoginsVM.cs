using System;
using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class LogLoginsVM : BaseVM
    {
        public string UsuarioIngresado { get; set; }
        public int TipoDeLoginId { get; set; }
        public string TipoDeLogin { get; set; }
        public int DispositivoId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeEjecucion { get; set; }

        public string FechaDeEjecucionFormateado { get; set; }
    }
}