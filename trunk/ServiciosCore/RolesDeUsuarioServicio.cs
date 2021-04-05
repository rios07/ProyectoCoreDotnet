using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface IRolesDeUsuariosServicio : IBaseServicios<RolesDeUsuarios, RolesDeUsuariosExt>
    {
    }

    public class RolesDeUsuarioServicio : BaseServicios<RolesDeUsuarios, RolesDeUsuariosExt>, IRolesDeUsuariosServicio
    {
        private readonly IRolesDeUsuariosRepositorio _RolesDeUsuariosRepositorio;

        public RolesDeUsuarioServicio(IRolesDeUsuariosRepositorio pRolesDeUsuariosRepositorio)
        {
            _RolesDeUsuariosRepositorio = pRolesDeUsuariosRepositorio;
        }

        public override IRepositorio<RolesDeUsuarios, RolesDeUsuariosExt> GetRepositorio()
        {
            return _RolesDeUsuariosRepositorio;
        }
    }
}