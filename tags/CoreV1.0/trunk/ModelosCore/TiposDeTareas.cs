using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;

namespace ModelosCore
{
    public class TiposDeTareas : BaseModelo
    {
        public string Nombre { get; set; }
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

    public class TiposDeTareasExt : TiposDeTareas
    {
        public bool Activo { get; set; }
    }
}
