using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface ILogEnviosDeCorreosServicio : IBaseServicios<LogEnviosDeCorreos, LogEnviosDeCorreosExt>
    {
    }

    public class LogEnviosDeCorreosServicio : BaseServicios<LogEnviosDeCorreos, LogEnviosDeCorreosExt>,
        ILogEnviosDeCorreosServicio
    {
        private readonly ILogEnviosDeCorreosRepositorio _LogEnviosDeCorreosRepositorio;

        public LogEnviosDeCorreosServicio(ILogEnviosDeCorreosRepositorio pLogEnviosDeCorreosRepositorio)
        {
            _LogEnviosDeCorreosRepositorio = pLogEnviosDeCorreosRepositorio;
        }

        public override IRepositorio<LogEnviosDeCorreos, LogEnviosDeCorreosExt> GetRepositorio()
        {
            return _LogEnviosDeCorreosRepositorio;
        }
    }
}