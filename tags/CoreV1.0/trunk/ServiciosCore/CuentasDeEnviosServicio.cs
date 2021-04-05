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
    public interface ICuentasDeEnviosServicio : IBaseServicios<CuentasDeEnvios, CuentasDeEnviosExt>
    {

    }
    public class CuentasDeEnviosServicio : BaseServicios<CuentasDeEnvios, CuentasDeEnviosExt>, ICuentasDeEnviosServicio
    {
        private ICuentasDeEnviosRepositorio _CuentasDeEnviosRepositorio;

        public CuentasDeEnviosServicio(ICuentasDeEnviosRepositorio pCuentasDeEnviosRepositorio)
        {
            _CuentasDeEnviosRepositorio = pCuentasDeEnviosRepositorio;
        }

        public override IRepositorio<CuentasDeEnvios, CuentasDeEnviosExt> GetRepositorio()
        {
            return _CuentasDeEnviosRepositorio;
        }

    }

}
