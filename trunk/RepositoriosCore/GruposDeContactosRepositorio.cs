using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IGruposDeContactosRepositorio : IRepositorio<GruposDeContactos, GruposDeContactosExt>
    {
    }

    public class GruposDeContactosRepositorio : BaseRepositorios<GruposDeContactos, GruposDeContactosExt>,
        IGruposDeContactosRepositorio
    {
        public GruposDeContactosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}