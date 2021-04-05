using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IProvinciasRepositorio : IRepositorio<Provincias, ProvinciasExt>
    {

    }

    public class ProvinciasRepositorio : BaseRepositorios<Provincias, ProvinciasExt>, IProvinciasRepositorio
    {
        public ProvinciasRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }
    }
}
