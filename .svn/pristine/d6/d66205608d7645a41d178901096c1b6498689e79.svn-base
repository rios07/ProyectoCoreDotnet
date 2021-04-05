using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore
{
    public interface ILogEnviosDeCorreosServicio : IBaseServicios<LogEnviosDeCorreos, LogEnviosDeCorreosExt>
    {

    }
    public class LogEnviosDeCorreosServicio : BaseServicios<LogEnviosDeCorreos, LogEnviosDeCorreosExt>, ILogEnviosDeCorreosServicio
    {
        private ILogEnviosDeCorreosRepositorio _LogEnviosDeCorreosRepositorio;

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
