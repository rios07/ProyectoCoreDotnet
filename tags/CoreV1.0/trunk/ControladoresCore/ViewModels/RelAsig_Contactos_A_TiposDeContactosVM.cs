using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ControladoresCore.ViewModels;

namespace ControladoresCore.ViewModels
{
    public class RelAsig_Contactos_A_TiposDeContactosVM : BaseVM
    {
        public int ContactoId { get; set; }
        public int TipoDeContactoIdsString { get; set; }

    }
}