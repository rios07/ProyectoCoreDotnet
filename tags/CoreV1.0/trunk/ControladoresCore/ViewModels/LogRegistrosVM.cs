using CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladoresCore.ViewModels
{
    public class LogRegistrosVM : BaseVM
    {
        [Display(Name = "Tabla")]
        public string Tabla { get; set; }
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Display(Name = "Fecha de ejecución")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeEjecucion { get; set; }
        [Display(Name = "Registro id")]
        public int RegistroId { get; set; }
        [Display(Name = "Tipo de operación")]
        public string TipoDeOperacion { get; set; }

        public int TablaId { get; set; }
        [Campo("TablaId")]
        public List<TablasVM> Tablas { get; set; }
        public int TipoDeOperacionId { get; set; }
        [Campo("TipoDeOperacionId")]
        public List<TiposDeOperacionesVM> TiposDeOperaciones { get; set; }
        public int UsuarioId { get; set; }
        [Campo("UsuarioId")]
        public List<UsuariosVM> Usuarios { get; set; }

    }
}
