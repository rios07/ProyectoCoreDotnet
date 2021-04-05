using FuncionesCore;

namespace ModelosCore
{
    public class CuentasDeEnvios : BaseModelo
    {
        public string Nombre { get; set; }
        public string CuentaDeEmail { get; set; }
        public string PwdDeEmail { get; set; }
        public string Smtp { get; set; }
        public int Puerto { get; set; }
        public string Observaciones { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class CuentasDeEnviosExt : CuentasDeEnvios
    {
    }
}