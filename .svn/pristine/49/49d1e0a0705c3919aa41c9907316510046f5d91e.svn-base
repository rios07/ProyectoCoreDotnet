using System;
using FuncionesCore;

namespace ModelosCore
{
    public class Notas : BaseModelo
    {
        public int IconoCSSId { get; set; }
        // public DateTime? Fecha { get; set; }
        // public DateTime FechaFormateado { get; set; }
       
        public DateTime? FechaDeVencimiento { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public bool CompartirConTodos { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }

    public class NotasExt : Notas
    {
        public string Usuario { get; set; }
        public int UsuarioId { get; set; } = -2;
        public DateTime? Fecha { get; set; }
        public string IconoCSS { get; set; }
        public string FechaFormateado { get; set; }
        public string FechaDeVencimientoFormateado { get; set; }

    }
}