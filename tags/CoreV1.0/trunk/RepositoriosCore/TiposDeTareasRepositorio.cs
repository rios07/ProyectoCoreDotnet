using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface ITiposDeTareasRepositorio : IRepositorio<TiposDeTareas, TiposDeTareasExt>
    {

    }

    public class TiposDeTareasRepositorio : BaseRepositorios<TiposDeTareas, TiposDeTareasExt>, ITiposDeTareasRepositorio
    {
        public TiposDeTareasRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }
    }
}
