using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IEstadosDeSoportesRepositorio : IRepositorio<EstadosDeSoportes, EstadosDeSoportes>
    {
    }

    public class EstadosDeSoportesRepositorio : BaseRepositorios<EstadosDeSoportes, EstadosDeSoportes>,
        IEstadosDeSoportesRepositorio
    {
        public EstadosDeSoportesRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}