namespace ControladoresCore.ViewModels
{
    public class RolesDe_UsuariosVM : BaseVM
    {
        public string Nombre { get; set; }
        public string Observaciones { get; set; }
        public bool PermiteAsignacionDePermisos { get; set; }
        public bool Activo { get; set; }
    }
}