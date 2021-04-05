using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore;

namespace ModelosCore
{
    public class LogErroresApp : BaseModelo
    {
        public string DispositivoMachineName { get; set; }
        public string Metodo { get; set; }
        public string Clase { get; set; }
        public int Linea { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set; } = -2;


        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }


    public class LogErroresAppExt : LogErroresApp
    {

    }
}