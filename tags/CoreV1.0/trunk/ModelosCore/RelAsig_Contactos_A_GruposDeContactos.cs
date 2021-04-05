using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore;

namespace ModelosCore
{
    public class RelAsig_Contactos_A_GruposDeContactos : BaseModelo
    {
        public int ContactoId { get; set; }
        public int GrupoDeContactoId { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }

    }

    public class RelAsig_Contactos_A_GruposDeContactosExt : RelAsig_Contactos_A_GruposDeContactos
    {

    }
}
