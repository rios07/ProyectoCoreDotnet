using FuncionesCore;

namespace ModelosCore
{
    /// <summary>
    ///     Aquí van los campos exclusivos de la tabla.
    /// </summary>
    // Escribir los Annotations de un mismo Campo por orden alfabético
    public class CategoriasDeInformes : BaseModelo
    {
        public string Nombre { get; set; }
        public string Observaciones { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true; //TODO: Hacer validacion
        }
    }


    /// <summary>
    ///     Ext: Extension de campos, ya sea por datos correspondientes a las FK u otro motivo.
    /// </summary>
    public class CategoriasDeInformesExt : CategoriasDeInformes
    {
        public bool Activo { get; set; }
    }
}