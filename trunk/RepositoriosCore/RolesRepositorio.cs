using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IRolesRepositorio : IRepositorio<RolesDeUsuarios, RolesDeUsuarios>
    {
    }

    public class RolesRepositorio : BaseRepositorios<RolesDeUsuarios, RolesDeUsuarios>, IRolesRepositorio
    {
        public RolesRepositorio(IConexion miConexion) : base(miConexion)
        {
        }
    }
}