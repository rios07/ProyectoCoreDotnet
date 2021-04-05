using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;

namespace ModelosCore
{
    public class EstadosDeTareas : BaseModelo
    {
        public string Nombre { get; set; }
        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class EstadosDeTareasExt : EstadosDeTareas
    {

    }
}
