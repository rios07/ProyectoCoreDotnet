using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{

    public interface ILogLoginsDeDispositivosRepositorio : IRepositorio<LogLoginsDeDispositivos, LogLoginsDeDispositivosExt>
    {
    }
    public class LogLoginsDeDispositivosRepositorio:BaseRepositorios<LogLoginsDeDispositivos, LogLoginsDeDispositivosExt>, ILogLoginsDeDispositivosRepositorio
    {
        public LogLoginsDeDispositivosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}