using System.Collections.Generic;

namespace FuncionesCore
{
    public class Operaciones
    {
        public static Operacion ActionName(string pActionName)
        {
            Operacion op = new Operacion();
            pActionName = pActionName.ToLower();
            
            if (pActionName == Operacion.anular.ToString())
            {
                op = Operacion.anular;
            }
            else if (pActionName == Operacion.custom.ToString())
            {
                op = Operacion.custom;
            }
            else if (pActionName == Operacion.delete.ToString())
            {
                op = Operacion.delete;
            }
            else if (pActionName == Operacion.insert.ToString())
            {
                op = Operacion.insert;
            }
            else if (pActionName.Contains(Operacion.listado.ToString()))
            {
                op = Operacion.listado;
            }
            else if (pActionName == Operacion.registro.ToString())
            {
                op = Operacion.registro;
            }
            else if (pActionName == Operacion.update.ToString())
            {
                op = Operacion.update;
            }
            else if (pActionName == Operacion.tablero.ToString())
            {
                op = Operacion.tablero;
            }
            else if (pActionName == Operacion.tablerogeneral.ToString())
            {
                op = Operacion.tablerogeneral;
            }
            else if (pActionName == Operacion.cambiarpassword.ToString())
            {
                op = Operacion.cambiarpassword;
            }
            else
            {
                op = Operacion.otro;
            }

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
        tablerogeneral
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

    public class ControllerBag : List<Mensaje>
    {
        public DatosDeUnaPagina DatosDeUnaPagina { get; set; }
        public Operacion Operacion { get; set; }
        public string RutaFisica { get; set; }
        public string Seccion { get; set; }
        public bool EsAnonima { get; set; }
        public string CodigoDeContexto { get; set; }
        public string Redir { get; set; } = "";
        public string Token { get; set; }
        public ControllerBag()
        {
            DatosDeUnaPagina = new DatosDeUnaPagina();
        }

        /// <summary>
        /// Para poder agregar mensajes directamente llamando a Add(contenido) sin tener que instanciar el Mensaje.
        /// </summary>
        /// <param name="pContenido"></param>
        public void Add(string pContenido, bool pEsError = false)
        {
            if (pContenido != "")
            {
                Mensaje mensaje = new Mensaje();
                mensaje.Contenido = pContenido;
                mensaje.EsError = pEsError;
                Add(mensaje);
            }
        }

        public bool TieneErrores()
        {
            int i = 0;
            while (i < Count)
            {
                Mensaje m = this[i];
                if (m.EsError)
                {
                    return true;
                }
                i++;
            }
            return false;
        }
    }
}
