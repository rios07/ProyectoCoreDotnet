using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    public class Importaciones : BaseModelo
    {
        [Ignorar(Operacion.insert)]
        public int TablaId { get; set; }
        public string Observaciones { get; set; }
        public string TablaDestino { get; set; }
        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class ImportacionesExt : Importaciones
    {

    }
}
