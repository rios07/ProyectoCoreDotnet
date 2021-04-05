using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface ICuentasDeEnviosServicio : IBaseServicios<CuentasDeEnvios, CuentasDeEnviosExt>
    {
    }

    public class CuentasDeEnviosServicio : BaseServicios<CuentasDeEnvios, CuentasDeEnviosExt>, ICuentasDeEnviosServicio
    {
        private readonly ICuentasDeEnviosRepositorio _CuentasDeEnviosRepositorio;

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