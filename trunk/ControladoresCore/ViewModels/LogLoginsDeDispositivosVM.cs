using System;
using ControladoresCore.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControladoresCore.ViewModels
{
    public class LogLoginsDeDispositivosVM : BaseVM
    {
        public int DispositivoId { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; }
        public DateTime FechaDeEjecucion { get; set; }
        public DateTime InicioValides { get; set; }
        public DateTime FinValidez { get; set; }

        public string Dispositivo { get; set; }
        public string Usuario { get; set; }
        public string FechaDeEjecucionFormateado { get; set; }
        public string InicioValidesFormateado { get; set; }
        public string FinValidezFormateado { get; set; }

    }
}