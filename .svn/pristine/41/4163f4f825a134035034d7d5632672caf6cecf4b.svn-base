using FuncionesCore;

namespace ModelosCore
{
    public class RelAsig_CuentasDeEnvios_A_Tablas : BaseModelo
    {
        public int CuentaDeEnvioId { get; set; }
        public int TablaId { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.eliminar;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class RelAsig_CuentasDeEnvios_A_TablasExt : RelAsig_CuentasDeEnvios_A_Tablas
    {
        public string Tabla { get; set; }
        public string CuentaDeEnvio { get; set; }
        public string CuentaDeEmail { get; set; }
        public string Puerto { get; set; }
        public string Smtp { get; set; }
    }
}