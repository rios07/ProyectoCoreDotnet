/* Ordenar por nombre los ussing */
using CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControladoresCore.ViewModels
{
    /// <summary>
    /// ViewModel de Informes.
    /// </summary>
    public class LogErroresVM : BaseVM
    {
        public string Pagina { get; set; }
        public string Capa { get; set; }
        public string Metodo { get; set; }
        public string MensajeDeError { get; set; }
        public string MachineName { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        public string FechaDeEjecucion { get; set; }
        public string FechaDeEjecucionParaListado { get; set; }

        [Display(Name = "N° Línea")]
        public string LineaDeError { get; set; }

        [Display(Name = "N° Error")]
        public int NumeroDeError { get; set; }

        public int TablaId { get; set; }
        [Campo("TablaId")]
        public List<TablasVM> Tablas { get; set; }

    }
}