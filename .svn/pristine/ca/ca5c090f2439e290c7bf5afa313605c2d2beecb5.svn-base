using System;
using FuncionesCore;

namespace ModelosCore
{
    public class Notificaciones : BaseModelo
    {
        public int RegistroId { get; set; }
        public DateTime Fecha { get; set; }
        public string Cuerpo { get; set; }
        public string Tabla { get; set; }
        public int IconoCSSId { get; set; }
        public int Numero { get; set; }
        public int UsuarioDestinatarioId { get; set; }
        public bool Leida { get; set; }
        public string Antiguedad { get; set; }


        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true; //TODO: Validacion
        }
    }

    public class NotificacionesExt : Notificaciones
    {
        public int Numero { get; set; }
        public string Usuario { get; set; }
        public string Cuerpo { get; set; }
        public string Antiguedad { get; set; }
        public string Icono { get; set; }
        public string IconoCSS { get; set; }
        public string FechaFormateado { get; set; }
        public string Seccion { get; set; }
        public bool Leida { get; set; }
    }
}