using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IEnviosDeCorreosRepositorio : IRepositorio<EnviosDeCorreos, EnviosDeCorreosExt>
    {
        List<EnviosDeCorreosExt> ObtenerPendientes(ref ControllerBag pControllerBag);
    }

    public class EnviosDeCorreosRepositorio : BaseRepositorios<EnviosDeCorreos, EnviosDeCorreosExt>,
        IEnviosDeCorreosRepositorio
    {
        public EnviosDeCorreosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }

        public List<EnviosDeCorreosExt> ObtenerPendientes(ref ControllerBag pControllerBag)
        {
            var dummy = new object();
            return (List<EnviosDeCorreosExt>) CustomMultipleQuery<object, EnviosDeCorreosExt>(dummy,
                "usp_EnviosDeCorreos__Pendientes", ref pControllerBag);
        }
    }
}