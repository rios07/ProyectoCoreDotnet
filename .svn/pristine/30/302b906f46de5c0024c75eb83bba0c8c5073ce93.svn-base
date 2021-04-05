using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    public class Tareas : BaseModelo
    {
        
        public int UsuarioOriginanteId { get; set; }
        public int UsuarioDestinatarioId { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public int TipoDeTareaId { get; set; }
        public int EstadoDeTareaId { get; set; }
        public int ImportanciaDeTareaId { get; set; }
        public int RegistroId { get; set; }
        public string Titulo { get; set; }
        public string Observaciones { get; set; }
        [Ignorar(Operacion.update)]
        public bool EnviarCorreo { get; set; }
        [Ignorar(Operacion.update)]
        public string TablaDeReferencia { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }
    }

    public class TareasExt : Tareas
    {
        public string EstadoDeTarea { get; set; }
        public string TipoDeTarea { get; set; }
        public string ImportanciaDeTarea { get; set; }
        public string UsuarioDestinatario { get; set; }
        public string UsuarioOriginante { get; set; }
        public string RegistroDeReferencia { get; set; }
        public bool Activo { get; set; }
        public int Numero { get; set; }

        public string FechaDeInicioParaListado { get; set; }
        public string FechaLimiteParaListado { get; set; }

    }
}
