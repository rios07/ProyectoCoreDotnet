using System;
using FuncionesCore;

namespace ModelosCore
{
    public class LogRegistros : BaseModelo
    {
        public string Tabla { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaDeEjecucion { get; set; }
        public int RegistroId { get; set; }
        public string TipoDeOperacion { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class LogRegistrosExt : LogRegistros
    {
    }
}