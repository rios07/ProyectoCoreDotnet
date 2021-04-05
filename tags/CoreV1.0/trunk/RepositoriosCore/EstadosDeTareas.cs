using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IEstadosDeTareasRepositorio : IRepositorio<EstadosDeTareas, EstadosDeTareasExt>
    {

    }

    public class EstadosDeTareasRepositorio : BaseRepositorios<EstadosDeTareas, EstadosDeTareasExt>, IEstadosDeTareasRepositorio
    {
        public EstadosDeTareasRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }
    }
}
