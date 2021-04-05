using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;

namespace ModelosCore
{
    public class LogLoginsDeDispositivos : BaseModelo
    {
        public int DispositivoId { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; }
        public DateTime FechaDeEjecucion { get; set; }
        public DateTime InicioValides { get; set; }
        public DateTime FinValidez { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.eliminar;
        }
    }
    public class LogLoginsDeDispositivosExt : LogLoginsDeDispositivos
    {
        public string Dispositivo { get; set; }
        public string Usuario { get; set; }
        public string FechaDeEjecucionFormateado { get; set; }
        public string InicioValidesFormateado { get; set; }
        public string FinValidezFormateado { get; set; }
    }
}
