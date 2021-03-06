using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface IRelAsig_TiposDeContactos_A_ContextosServicio : IBaseServicios<RelAsig_TiposDeContactos_A_Contextos
        , RelAsig_TiposDeContactos_A_ContextosExt>
    {
        int SwapAsignacion(int pTipoDeContactoId, ref ControllerBag pControllerBag);
    }

    public class RelAsig_TiposDeContactos_A_ContextosServicio :
        BaseServicios<RelAsig_TiposDeContactos_A_Contextos, RelAsig_TiposDeContactos_A_ContextosExt>,
        IRelAsig_TiposDeContactos_A_ContextosServicio
    {
        private readonly IRelAsig_TiposDeContactos_A_ContextosRepositorio
            _RelAsig_TiposDeContactos_A_ContextosRepositorio;

        public RelAsig_TiposDeContactos_A_ContextosServicio(
            IRelAsig_TiposDeContactos_A_ContextosRepositorio pRelAsig_TiposDeContactos_A_ContextosRepositorio)
        {
            _RelAsig_TiposDeContactos_A_ContextosRepositorio = pRelAsig_TiposDeContactos_A_ContextosRepositorio;
        }

        public int SwapAsignacion(int pTipoDeContactoId, ref ControllerBag pControllerBag)
        {
            return _RelAsig_TiposDeContactos_A_ContextosRepositorio.SwapAsignacion(pTipoDeContactoId,
                ref pControllerBag);
        }

        public override IRepositorio<RelAsig_TiposDeContactos_A_Contextos, RelAsig_TiposDeContactos_A_ContextosExt>
            GetRepositorio()
        {
            return _RelAsig_TiposDeContactos_A_ContextosRepositorio;
        }
    }
}