using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    public class Paginas : BaseModelo
    {
        [Ignorar(Operacion.update)] public int TablaId { get; set; }

        [Ignorar(Operacion.update)] public int FuncionDePaginaId { get; set; }

        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Observaciones { get; set; }
        public string Tips { get; set; }

        public bool SeMuestraEnAsignacionDePermisos { get; set; }

        [Ignorar(Operacion.update)] public string RolesIdsString_CargarLaPagina { get; set; }

        [Ignorar(Operacion.update)] public string RolesIdsString_OperarLaPagina { get; set; }

        [Ignorar(Operacion.update)] public string RolesIdsString_VerRegAnulados { get; set; }

        [Ignorar(Operacion.update)] public string RolesIdsString_AccionesEspeciales { get; set; }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.ninguno;
        }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true; //TODO: Hacer validacion
        }
    }

    public class PaginasExt : Paginas
    {
        public string Tabla { get; set; }
        public string FuncionDePagina { get; set; }
    }
}