using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    public class LogEnviosDeCorreos : BaseModelo
    {
        public int EnvioDeCorreoId { get; set; }
        public bool Satisfactorio { get; set; }
        [Ignorar(Operacion.insert)]
        public string ObservacionesDeRevision { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class LogEnviosDeCorreosExt : LogEnviosDeCorreos
    {
        public string FechaParaListado { get; set; }
        public string UsuarioOriginante { get; set; }
        public string UsuarioDestinatario { get; set; }
        public string Asunto { get; set; }

    }
}
