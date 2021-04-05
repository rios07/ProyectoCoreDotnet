using FuncionesCore;

namespace ModelosCore
{
    /// <summary>
    ///     Aquí van los campos exclusivos de la tabla.
    /// </summary>
    // Escribir los Annotations de un mismo Campo por orden alfabético
    //[SinSeccion]
    public class LogErrores : BaseModelo
    {
        public string Pagina { get; set; }
        public string Capa { get; set; }
        public string Metodo { get; set; }
        public string Mensaje { get; set; }
        public string MachineName { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }
        public string LineaDeError { get; set; }
        public int NumeroDeError { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override string ToString()
        {
            return "id: " + Id + " Modulo: " + Capa + " Metodo: " + Metodo + " Mensaje: " + Mensaje;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true; //TODO: Hacer validacion
        }
    }

    /// <summary>
    ///     Ext: Extension de campos, ya sea por datos correspondientes a las FK u otro motivo.
    /// </summary>
    public class LogErroresExt : LogErrores
    {
        public string FechaDeEjecucion { get; set; }
        public string FechaDeEjecucionFormateado { get; set; }
        public string UsuarioQueEjecuta { get; set; }
        public string TipoDeLogError { get; set; }
        public string EstadoDeLogError { get; set; }
    }
}