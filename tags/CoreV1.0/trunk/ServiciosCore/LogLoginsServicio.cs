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
    public interface ILogLoginsServicio : IBaseServicios<LogLogins, LogLoginsExt>
    {

    }

    public class LogLoginsServicio : BaseServicios<LogLogins, LogLoginsExt>, ILogLoginsServicio
    {
        private ILogLoginsRepositorio _LogLoginsRepositorio;

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