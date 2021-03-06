/* Ordenar por nombre los ussing */

namespace ControladoresCore.ViewModels
{
    /// <summary>
    ///     ViewModel de base.
    ///     Escribir los Annotations de un mismo Campo por orden alfabético
    /// </summary>
    public abstract class BaseVM
    {
        public int Id { get; set; }
        public int ContextoId { get; set; }

        public string Historia { get; set; }
    }
}