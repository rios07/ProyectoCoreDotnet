using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface ILogRegistrosRepositorio : IRepositorio<LogRegistros, LogRegistrosExt>
    {
    }

    public class LogRegistrosRepositorio : BaseRepositorios<LogRegistros, LogRegistrosExt>, ILogRegistrosRepositorio
    {
        public LogRegistrosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}