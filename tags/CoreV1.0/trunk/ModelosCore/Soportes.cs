using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    /// <summary>
    /// Aquí van los campos exclusivos de la tabla.
    /// </summary>
    public class Soportes : BaseModelo
    {
        public int UsuarioQueSolicitaId { get; set; }
        public string Texto { get; set; }
        //[Ignorar(Operacion.insert)]
        public int UsuarioQueCerroId { get; set; }
        //[Ignorar(Operacion.insert)]
        public DateTime? FechaDeCierre { get; set; }
        //[Ignorar(Operacion.insert)]
        public int EstadoDeSoporteId { get; set; } = 1;
        //[Ignorar(Operacion.insert)]
        public int PrioridadDeSoporteId { get; set; } = 0;
        //[Ignorar(Operacion.insert)]
        public string Observaciones { get; set; }
        //[Ignorar(Operacion.insert)]
        public bool Cerrado { get; set; }
        //[Ignorar(Operacion.insert)]
        public string ObservacionesPrivadas { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return !(pControllerBag.TieneElementos());
        }
        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }

    /// <summary>
    /// Ext: Extension de campos, ya sea por datos correspondientes a las FK u otro motivo.
    /// </summary>
    public class SoportesExt : Soportes
    {
        public string UsuarioQueCerro { get; set; }
        public string UsuarioQueSolicita { get; set; }
        public string PrioridadDeSoporte { get; set; }
        public string UsuarioQueEjecuta { get; set; }
        public string EmailUsuarioQueCreo { get; set; }
        public string EmailUsuarioQueSolicito { get; set; }
        public DateTime FechaDeEjecucion { get; set; }
        public string FechaDeEjecucionParaListado { get; set; }
        public string FechaDeCierreParaListado { get; set; }

        public int Numero { get; set; }
        
        public string EstadoDeSoporte { get; set; }
        public string ObservacionesDeEstadoDeSoportes { get; set; }
        public string Prioridad { get; set; }
        
        public string Activo { get; set; }
    }
}
