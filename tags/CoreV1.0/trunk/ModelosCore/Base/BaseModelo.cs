using System;
using System.Collections.Generic;
using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    public abstract class BaseModelo
    {
        public int Id { get; set; }
        [Ignorar(Operacion.insert)]
        [Ignorar(Operacion.update)]
        [Ignorar(Operacion.custom)]
        public int ContextoId { get; set; }

        [Ignorar(Operacion.insert)]
        [Ignorar(Operacion.update)]
        [Ignorar(Operacion.custom)]
        public string Historia { get; set; }

        /// <summary>
        /// Fcion para validar el modelo. Se debe pisar en cada modelo.
        /// </summary>
        /// <param name="pControllerBag">Contendrá el listado de mensajes respecto a valores inválidos</param>
        /// <returns></returns>
        public abstract bool Valido(ref ControllerBag pControllerBag);

        /// <summary>
        /// Fcion que indica para cada modelo si permite eliminarlo, anularlo o ninguno de los 2.
        /// </summary>
        /// <returns></returns>
        public abstract AnularEliminar PermiteAnularEliminarValido();

        public enum AnularEliminar
        {
            anular,
            eliminar,
            ninguno
        }

        
        
    }
}
