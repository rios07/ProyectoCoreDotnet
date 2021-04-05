using System.ComponentModel.DataAnnotations;
using FuncionesCore;

namespace ModelosCore
{
    /// <summary>
    /// Aquí van los campos exclusivos de la tabla.
    /// </summary>
    // Escribir los Annotations de un mismo Campo por orden alfabético
    public class Contratos : BaseModelo
    {

        [Display(Name ="N° de contrato")]
        public string NumeroDeContrato { get; set; }
        //como que no?
        [Display(Name = "N° de orden")]
        public string NumeroDeOrden { get; set; }

        [Display(Name = "Nombre corto")]
        public string NombreCorto { get; set; }
        public string PaisId { get; set; }

        public override string ToString()
        {
            return "id: " + Id + " NumeroDeContrato: " + NumeroDeContrato + " NumeroDeOrden: " + NumeroDeOrden + " NombreCorto: " + NombreCorto + " Pais: " + PaisId;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;//TODO: Hacer validacion
        }
    }

    /// <summary>
    /// Ext: Extension de campos, ya sea por datos correspondientes a las FK u otro motivo.
    /// </summary>
    public class ContratosExt : Contratos
    {
        public string Pais { get; set; }

        public override string ToString()
        {
            return base.ToString() + " Pais: " + Pais;
        }
    }
}
