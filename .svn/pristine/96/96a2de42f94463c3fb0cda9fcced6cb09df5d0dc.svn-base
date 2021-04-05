using CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladoresCore.ViewModels
{
    public class RelAsig_RolesDeUsuarios_A_PaginasVM : BaseVM
    {
        public string Pagina { get; set; }
        public string RolDeUsuario { get; set; }
        public int RolDeUsuarioId { get; set; }
        public bool AutorizadoA_CargarLaPagina { get; set; }
        public bool AutorizadoA_OperarLaPagina { get; set; }
        public bool AutorizadoA_VerRegAnulados { get; set; }
        public bool AutorizadoA_AccionesEspeciales { get; set; }
        [Campo("RolDeUsuarioId")]
        public List<RolesDe_UsuariosVM> Roles { get; set; }
        [Campo("TablaId")]
        public List<TablasVM> Tablas { get; set; }
        public int TablaId { get; set; }
        public string Seccion { get; set; }

        public List<SeccionesVM> Secciones { get; set; }

    }
        
}
