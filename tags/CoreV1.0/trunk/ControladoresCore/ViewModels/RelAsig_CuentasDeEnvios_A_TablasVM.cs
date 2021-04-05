using CustomDataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ControladoresCore.ViewModels
{
    public class RelAsig_CuentasDeEnvios_A_TablasVM : BaseVM
    {
        public int CuentaDeEnvioId { get; set; }
        public int TablaId { get; set; }

        [Campo("TablaId")]
        public List<TablasVM> Tablas { get; set; }
        [Campo("CuentaDeEnvioId")]
        public List<CuentasDeEnviosVM> Cuentas { get; set; }
        public string Tabla { get; set; }
        [Display(Name = "Nombre de cuenta")]
        public string CuentaDeEnvio { get; set; }
        [Display(Name = "Cuenta de email")]
        public string CuentaDeEmail { get; set; }

        public string Puerto { get; set; }
        public string Smtp { get; set; }
    }
}