using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface ILogLoginsDeDispositivosServicio: IBaseServicios<LogLoginsDeDispositivos, LogLoginsDeDispositivosExt>
    {
        //IEnumerable<Paginas> GetPaginas();
    }
    public class LogLoginsDeDispositivosServicio:BaseServicios<LogLoginsDeDispositivos, LogLoginsDeDispositivosExt>, ILogLoginsDeDispositivosServicio
    {

        private readonly ILogLoginsDeDispositivosRepositorio _LogLoginsDeDispositivosRepositorio;

        public LogLoginsDeDispositivosServicio(ILogLoginsDeDispositivosRepositorio pLogLoginsDeDispositivosRepositorio)
        {
            _LogLoginsDeDispositivosRepositorio = pLogLoginsDeDispositivosRepositorio;
        }
        public override IRepositorio<LogLoginsDeDispositivos, LogLoginsDeDispositivosExt> GetRepositorio()
        {
            return _LogLoginsDeDispositivosRepositorio;
        }
    }
}