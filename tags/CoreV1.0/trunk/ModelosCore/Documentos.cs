using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;

namespace ModelosCore
{
    public class Documentos : BaseModelo
    {
        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }
}
