using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface ILogLoginsServicio : IBaseServicios<LogLogins, LogLoginsExt>
    {
    }

    public class LogLoginsServicio : BaseServicios<LogLogins, LogLoginsExt>, ILogLoginsServicio
    {
        private readonly ILogLoginsRepositorio _LogLoginsRepositorio;

        public LogLoginsServicio(ILogLoginsRepositorio pLogLoginsRepositorio)
        {
            _LogLoginsRepositorio = pLogLoginsRepositorio;
        }

        public override IRepositorio<LogLogins, LogLoginsExt> GetRepositorio()
        {
            return _LogLoginsRepositorio;
        }
    }
}