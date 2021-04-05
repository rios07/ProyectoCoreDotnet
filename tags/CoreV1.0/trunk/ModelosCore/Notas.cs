using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore;

namespace ModelosCore
{
    public class Notas : BaseModelo
    {

        public int IconoCSSId { get; set; }
       // public DateTime FechaParaListado { get; set; }
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
        public int UsuarioId { get; set; }
        public string IconoCSS { get; set; }
        public string FechaParaListado { get; set; }
        public string FechaDeVencimientoParaListado { get; set; }
        public string Fecha { get; set; }

    }
}
