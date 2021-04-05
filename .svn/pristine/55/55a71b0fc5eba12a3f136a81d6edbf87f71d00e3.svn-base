using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface ILogErroresAppServicio : IBaseServicios<LogErroresApp, LogErroresAppExt>
    {

    }

    public class LogErroresAppServicio : BaseServicios<LogErroresApp, LogErroresAppExt>, ILogErroresAppServicio
    {
        private ILogErroresAppRepositorio _LogErroresAppRepositorio;

        public LogErroresAppServicio(ILogErroresAppRepositorio pLogErroresAppRepositorio)
        {
            _LogErroresAppRepositorio = pLogErroresAppRepositorio;
        }

        public override IRepositorio<LogErroresApp, LogErroresAppExt> GetRepositorio()
        {
            return _LogErroresAppRepositorio;
        }
    }

}