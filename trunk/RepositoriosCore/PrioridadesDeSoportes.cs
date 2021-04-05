using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IPrioridadesDeSoportesRepositorio : IRepositorio<PrioridadesDeSoportes, PrioridadesDeSoportes>
    {
    }

    public class PrioridadesDeSoportesRepositorio : BaseRepositorios<PrioridadesDeSoportes, PrioridadesDeSoportes>,
        IPrioridadesDeSoportesRepositorio
    {
        public PrioridadesDeSoportesRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}