using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface ITareasRepositorio : IRepositorio<Tareas, TareasExt>
    {

    }

    public class TareasRepositorio : BaseRepositorios<Tareas, TareasExt>, ITareasRepositorio
    {

        public TareasRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }

    }
}
