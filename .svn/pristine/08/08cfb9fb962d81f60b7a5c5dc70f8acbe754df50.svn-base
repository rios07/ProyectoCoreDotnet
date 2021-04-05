using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    public class Dispositivos : BaseModelo
    {
        public int AsignadoAUsuarioId { get; set; }
        public string MachineName { get; set; }
        public string OSVersion { get; set; }
        public string UserMachineName { get; set; }
        public string Observaciones { get; set; }
        public bool ClavePrivadaEntregada { get; set; }
        public string ClavePrivada { get; set; }
        public DateTime ClavePrivadaFechaEntrega { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class DispositivosExt : Dispositivos
    {
        public bool Activo { get; set; }
        public string AsignadoAUsuario { get; set; }
        //public DateTime ClavePrivadaFechaEntrega { get; set; }
        //public bool ClavePrivadaEntregada { get; set; }
    }
}
