using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface INotasRepositorio : IRepositorio<Notas, NotasExt>
    {
    }

    public class NotasRepositorio : BaseRepositorios<Notas, NotasExt>, INotasRepositorio
    {
        public NotasRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}