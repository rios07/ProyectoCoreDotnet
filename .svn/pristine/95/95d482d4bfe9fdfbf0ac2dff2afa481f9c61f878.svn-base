using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore;

namespace ModelosCore
{
    public class TiposDeContactos : BaseModelo
    {
        public string Nombre { get; set; }
        public string Observaciones { get; set; }
        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

    }

    public class TiposDeContactosExt : TiposDeContactos
    {

    }
}
