using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IPaginasRepositorio : IRepositorio<Paginas, PaginasExt>
    {
    }

    public class PaginasRepositorio : BaseRepositorios<Paginas, PaginasExt>, IPaginasRepositorio
    {
        public PaginasRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }

        public override int Insert(Paginas pObj, ref ControllerBag pControllerBag)
        {
            return CustomExecute(pObj, "usp_Paginas__InsertSegunRoles", ref pControllerBag);
        }
    }
}