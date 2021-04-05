using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IActoresRepositorio : IRepositorio<Actores, ActoresExt>
    {
    }

    public class ActoresRepositorio : BaseRepositorios<Actores, ActoresExt>, IActoresRepositorio
    {
        public ActoresRepositorio(IConexion miConexion) : base(miConexion)
        {
        }
    }
}