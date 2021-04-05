using FuncionesCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ModelosCore.CustomAnnotations;
//using System.Web.Mvc;

namespace ModelosCore
{
    /// <summary>
    /// Aquí van los campos exclusivos de la tabla.
    /// </summary>
    // Escribir los Annotations de un mismo Campo por orden alfabético
    public class Informes : BaseModelo
    {
        //[Display(Name = "id del usuario")]
        //public string Usuario_Id { get; set; }
        [Ignorar(Operacion.update)]
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Observaciones { get; set; }
        [Ignorar(Operacion.update)]
        public DateTime FechaDeInforme { get; set; }
        
        public int CategoriaDeInformeId { get; set; }


        public override string ToString()
        {
            return "id: " + Id + " Título: " + Titulo;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            

            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }

    /// <summary>
    /// Ext: Extension de campos, ya sea por datos correspondientes a las FK u otro motivo.
    /// </summary>
    public class InformesExt : Informes
    {
        public bool Activo { get; set; }
        public string Usuario { get; set; }
        public string CategoriaDeInforme { get; set; }
        public string FechaDeInformeParaListado { get; set; }
        public int CantidadDeAdjuntos { get; set; }


    }
}
