using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomDataAnnotations;

namespace ControladoresCore.ViewModels
{
    public class PaginasVM : BaseVM
    {
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [Display(Name = "Tabla")]
        public int TablaId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [Display(Name = "Función de pagina")]
        public int FuncionDePaginaId { get; set; }

        public string Nombre { get; set; }
        public string Titulo { get; set; }

        [StringLength(1000)] public string Observaciones { get; set; }

        public string Tips { get; set; }
        public string Tabla { get; set; }
        public string FuncionDePagina { get; set; }
        public bool SeMuestraEnAsignacionDePermisos { get; set; } = true;

        [Campo("TablaId")] public List<TablasVM> ListaTablas { get; set; }

        [Campo("FuncionDePaginaId")] public List<FuncionesDePaginasVM> ListaFuncionesDePaginas { get; set; }

        public List<RolesDeUsuariosVM> Roles { get; set; }

        [Display(Name = "Roles")] public string[] RolesStringList { get; set; }

        public string RolesIdsString_CargarLaPagina { get; set; }
        public string RolesIdsString_OperarLaPagina { get; set; }
        public string RolesIdsString_VerRegAnulados { get; set; }
        public string RolesIdsString_AccionesEspeciales { get; set; }
    }
}