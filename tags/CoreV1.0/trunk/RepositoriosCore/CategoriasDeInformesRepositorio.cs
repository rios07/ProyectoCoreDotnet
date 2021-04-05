using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface ICategoriasDeInformesRepositorio : IRepositorio<CategoriasDeInformes, CategoriasDeInformesExt>
    {

    }

    public class CategoriasDeInformesRepositorio : BaseRepositorios<CategoriasDeInformes, CategoriasDeInformesExt>, ICategoriasDeInformesRepositorio
    {
        public CategoriasDeInformesRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }
    }
}
