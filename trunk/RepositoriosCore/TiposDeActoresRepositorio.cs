using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface ITiposDeActoresRepositorio : IRepositorio<TiposDeActores, TiposDeActores>
    {
    }

    public class TiposDeActoresRepositorio : BaseRepositorios<TiposDeActores, TiposDeActores>,
        ITiposDeActoresRepositorio
    {
        public TiposDeActoresRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}