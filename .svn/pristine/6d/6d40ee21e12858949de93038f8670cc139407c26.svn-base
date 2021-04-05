using System;
using FuncionesCore;

namespace ModelosCore
{
    public class LogLogins : BaseModelo
    {
        public string UsuarioIngresado { get; set; }
        public int TipoDeLoginId { get; set; }
        public string TipoDeLogin { get; set; }
        public int DispositivoId { get; set; }
        public DateTime FechaDeEjecucion { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.eliminar;
        }
    }

    public class LogLoginsExt : LogLogins
    {
        public string FechaDeEjecucionFormateado { get; set; }
    }
}