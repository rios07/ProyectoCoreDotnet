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
    public class ReservasDeRecursos : BaseModelo
    {
        [Ignorar(Operacion.insert)]
        [Ignorar(Operacion.update)]
        public int UsuarioOriginanteId { get; set; }
        public int UsuarioDestinatarioId { get; set; }
        [Ignorar(Operacion.update)]
        public int RecursoId { get; set; }
        [Ignorar(Operacion.insert)]
        [Ignorar(Operacion.update)]
        public DateTime FechaDePedido { get; set; }
        [Ignorar(Operacion.insert)]
        [Ignorar(Operacion.update)]
        public DateTime FechaDeAprobacion { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public string ObservacionesDelOriginante { get; set; }
        public string ObservacionesDelAprobador { get; set; }
        [Ignorar(Operacion.update)]
        public bool ReservaAprobada { get; set; }
        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }

    }

    public class ReservasDeRecursosExt : ReservasDeRecursos
    {
        public string Recurso { get; set; }
        public string UsuarioOriginante { get; set; }
        public string UsuarioDestinatario { get; set; }
        public int Numero { get; set; }
        public bool EsResponsable { get; set; }
        public string FechaDeInicioParaListado { get; set; }
        public string FechaLimiteParaListado { get; set; }

    }
}
//id INT   IDENTITY(1,1) NOT NULL
//, ContextoId                        INT NOT NULL -- Depende del contexto.
//,UsuarioOriginanteId INT                NOT NULL -- El que "pide" la reserva.

//, UsuarioDestinatarioId INT                NOT NULL -- Para el destinatario de la reserva.
//, RecursoId INT                NOT NULL -- Recurso que se reserva.
//, FechaDePedido DATETIME        NOT NULL -- Fecha en que se pide la reserva.

//, FechaDeAprobación DATETIME        NULL     -- = NULL --> NO APROBADA. Fecha en que se aprueba la reserva.

//, FechaDeInicio DATETIME        NOT NULL -- Es la fecha desde la cual cominza la reserva.

//, FechaLimite DATETIME        NULL     -- = NULL --> Reservada indefinidamente. Es la fecha en la que espera que finalice la reserva.

//, Numero INT                NOT NULL -- De referencia
//, Observaciones VARCHAR(1000)
//,CONSTRAINT PK_ReservasDeRecursos_Id        PRIMARY KEY CLUSTERED(id)
//,CONSTRAINT UQ_ReservasDeRecursos            UNIQUE NONCLUSTERED(ContextoId, FechaDeInicio, RecursoId)
//,CONSTRAINT UQ_ReservasDeRecursos_Numero    UNIQUE NONCLUSTERED(ContextoId, Numero)