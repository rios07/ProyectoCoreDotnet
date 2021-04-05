using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladoresCore.ViewModels
{
    public class RelAsig_RolesDeUsuarios_A_UsuariosVM : BaseVM
    {
        public string Rol { get; set; }
        public int RolDeUsuarioId { get; set; }
        public bool Asignado { get; set; }
        [Display(Name = "Fecha desde"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? FechaDesde { get; set; }
        [Display(Name = "Fecha hasta"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? FechaHasta { get; set; }

        public List<UsuariosVM> Usuarios { get; set; }
       
        

    }
}
