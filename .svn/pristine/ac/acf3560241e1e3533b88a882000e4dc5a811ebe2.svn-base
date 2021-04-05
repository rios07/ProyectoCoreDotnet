using System.Collections.Generic;

namespace FuncionesCore
{
    public class Operaciones
    {
        public static Operacion ActionName(string pActionName)
        {
            var op = new Operacion();
            pActionName = pActionName.ToLower();

            if (pActionName == Operacion.anular.ToString().ToLower())
                op = Operacion.anular;
            else if (pActionName == Operacion.custom.ToString().ToLower())
                op = Operacion.custom;
            else if (pActionName == Operacion.delete.ToString().ToLower())
                op = Operacion.delete;
            else if (pActionName == Operacion.insert.ToString().ToLower())
                op = Operacion.insert;
            else if (pActionName == Operacion.listado.ToString().ToLower())
                op = Operacion.listado;
            else if (pActionName == Operacion.registro.ToString().ToLower())
                op = Operacion.registro;
            else if (pActionName == Operacion.update.ToString().ToLower())
                op = Operacion.update;
            else if (pActionName == Operacion.tablero.ToString().ToLower())
                op = Operacion.tablero;
            else if (pActionName == Operacion.tablerogeneral.ToString().ToLower())
                op = Operacion.tablerogeneral;
            else if (pActionName == Operacion.cambiarpassword.ToString().ToLower())
                op = Operacion.cambiarpassword;
            else if (pActionName == Operacion.inicio.ToString().ToLower())
                op = Operacion.inicio;
            else if (pActionName == Operacion.listadoAvanzado.ToString().ToLower())
                op = Operacion.listadoAvanzado;
            else if (pActionName == Operacion.listadoDeControl.ToString().ToLower())
                op = Operacion.listadoDeControl;
            else if (pActionName == Operacion.cambiarPassword.ToString().ToLower())
                op = Operacion.cambiarPassword;
            else if (pActionName == Operacion.resetPassword.ToString().ToLower())
                op = Operacion.resetPassword;
            else if (pActionName == Operacion.grafico.ToString().ToLower())
                op = Operacion.grafico;
            else if (pActionName == Operacion.mapa.ToString().ToLower())
                op = Operacion.mapa;
            else if (pActionName == Operacion.listadoDDL.ToString().ToLower())
                op = Operacion.listadoDDL;
            else if (pActionName == Operacion.login.ToString().ToLower())
                op = Operacion.login;
            else if (pActionName == Operacion.pendientes.ToString().ToLower())
                op = Operacion.pendientes;
            else if (pActionName == Operacion.tableroGeneral.ToString().ToLower())
                op = Operacion.tableroGeneral;
            else if (pActionName == Operacion.enviar.ToString().ToLower())
                op = Operacion.enviar;
            else if (pActionName == Operacion.exportar.ToString().ToLower())
                op = Operacion.exportar;
            else if (pActionName == Operacion.diagrama.ToString().ToLower())
                op = Operacion.diagrama;
            else if (pActionName == Operacion.selectedAvanzado.ToString().ToLower())
                op = Operacion.selectedAvanzado;
            else if (pActionName == Operacion.mapaAvanzado.ToString().ToLower())
                op = Operacion.mapaAvanzado;
            else if (pActionName == Operacion.listadoDeCostos.ToString().ToLower())
                op = Operacion.listadoDeCostos;
            else if (pActionName == Operacion.reporte.ToString().ToLower())
                op = Operacion.reporte;
            else if (pActionName == Operacion.reporteSSRS.ToString().ToLower())
                op = Operacion.reporteSSRS;
            else if (pActionName == Operacion.import.ToString().ToLower())
                op = Operacion.import;
            else if (pActionName == Operacion.activar.ToString().ToLower())
                op = Operacion.activar;
            else if (pActionName == Operacion.cargarHistoria.ToString().ToLower())
                op = Operacion.cargarHistoria;
            else if (pActionName == Operacion.listadoReporte.ToString().ToLower())
                op = Operacion.listadoReporte;
            else if (pActionName == Operacion.registroReporte.ToString().ToLower())
                op = Operacion.registroReporte;
            else
                op = Operacion.otro;

            return op;
        }
    }

    public enum Operacion
    {
        anular,
        custom,
        delete,
        otro,
        insert,
        listado,
        registro,
        cambiarpassword,
        update,
        tablero,
        tablerogeneral,
        inicio,
        listadoAvanzado,
        listadoDeControl,
        cambiarPassword,
        resetPassword,
        grafico,
        mapa,
        listadoDDL,
        login,
        pendientes,
        tableroGeneral,
        enviar,
        exportar,
        diagrama,
        selectedAvanzado,
        mapaAvanzado,
        listadoDeCostos,
        reporte,
        listadoReporte,
        registroReporte,
        reporteSSRS,
        import,
        activar,
        cargarHistoria
    }

    public class Mensaje
    {
        public string Contenido { get; set; }
        public bool EsError { get; set; }
    }

    public class DatosDeUnaPagina
    {
        public string Titulo { get; set; } = "";
        public string Notas { get; set; } = "";
        public string Tips { get; set; } = "";
        public bool AutorizadoACargarLaPagina { get; set; }
        public bool AutorizadoAOperarLaPagina { get; set; }
        public bool AutorizadoAVerRegAnulados { get; set; }
        public bool AutorizadoAAccionesEspeciales { get; set; }
    }

    ///Clase que utilizamos para comunicar todas las partes de la arquitecturaMVC
    ///
    /// Ademas de sus propiedades, hereda de una lista de Mensaje que es la que utilizamos para la comunicacion de exepciones o de errores de SQL
    public class ControllerBag : List<Mensaje>
    {
        public ControllerBag()
        {
            DatosDeUnaPagina = new DatosDeUnaPagina();
        }

        public DatosDeUnaPagina DatosDeUnaPagina { get; set; }
        public Operacion Operacion { get; set; }
        public string RutaFisica { get; set; }
        public string Seccion { get; set; }
        public bool EsAnonima { get; set; }
        public string CodigoDeContexto { get; set; }
        public string Redir { get; set; } = "";
        public string Token { get; set; }

        /// <summary>
        ///     Para poder agregar mensajes directamente llamando a Add(contenido) sin tener que instanciar el Mensaje.
        /// </summary>
        /// <param name="pContenido"></param>
        public void Add(string pContenido, bool pEsError = false)
        {
            if (pContenido != "")
            {
                var mensaje = new Mensaje();
                mensaje.Contenido = pContenido;
                mensaje.EsError = pEsError;
                Add(mensaje);
            }
        }

        public bool TieneErrores()
        {
            var i = 0;
            while (i < Count)
            {
                var m = this[i];
                if (m.EsError) return true;
                i++;
            }

            return false;
        }
    }
}