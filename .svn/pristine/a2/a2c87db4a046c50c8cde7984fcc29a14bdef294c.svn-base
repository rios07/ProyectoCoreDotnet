using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    public class Recursos : BaseModelo
    {
        public string Nombre { get; set; }
        public string Observaciones { get; set; }
        [Ignorar(Operacion.insert)]
        [Ignorar(Operacion.update)]
        public int UsuarioResponsableId { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }

    }

    public class RecursosExt : Recursos
    {
        public string UsuariosResponsables { get; set; }
        public bool Activo { get; set; }
    }
}
