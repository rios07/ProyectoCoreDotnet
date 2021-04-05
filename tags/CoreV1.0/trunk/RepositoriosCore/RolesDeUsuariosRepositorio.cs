using ModelosCore;

using RepositoriosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IRolesDeUsuariosRepositorio : IRepositorio<RolesDeUsuarios, RolesDeUsuariosExt>
    {

    }

    public class RolesDeUsuariosRepositorio : BaseRepositorios<RolesDeUsuarios, RolesDeUsuariosExt>, IRolesDeUsuariosRepositorio
    {
        public RolesDeUsuariosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }
    }
}