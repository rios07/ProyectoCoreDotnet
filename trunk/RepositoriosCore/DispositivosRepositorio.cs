using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IDispositivosRepositorio : IRepositorio<Dispositivos, DispositivosExt>
    {
        ResultadoValidacionDispositivo ValidarDispositivo(ref ControllerBag pControllerBag , string pAndroidId);
    }

    public class DispositivosRepositorio : BaseRepositorios<Dispositivos, DispositivosExt>, IDispositivosRepositorio
    {
        public DispositivosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }

        public ResultadoValidacionDispositivo ValidarDispositivo(ref ControllerBag pControllerBag, string pAndroidId)
        {
            ParametrosValidacionDispositivo obj = new ParametrosValidacionDispositivo(){AndroidId= pAndroidId };
 
            var retorno= CustomQuery<ParametrosValidacionDispositivo, ResultadoValidacionDispositivo>(obj, "usp_Dispositivos__Validar", ref pControllerBag);

            return retorno;
        }
    }

    public class ResultadoValidacionDispositivo
    {
        public bool valido { get; set; }
        public int DispositivoId { get; set; }

    }

    public class ParametrosValidacionDispositivo
    {
        public string AndroidId { get; set; }
    }
}

