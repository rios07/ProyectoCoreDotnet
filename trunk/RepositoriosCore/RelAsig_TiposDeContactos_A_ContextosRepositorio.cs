using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IRelAsig_TiposDeContactos_A_ContextosRepositorio : IRepositorio<
        RelAsig_TiposDeContactos_A_Contextos, RelAsig_TiposDeContactos_A_ContextosExt>
    {
        int SwapAsignacion(int pTipoDeContactoId, ref ControllerBag pControllerBag);
    }

    public class RelAsig_TiposDeContactos_A_ContextosRepositorio :
        BaseRepositorios<RelAsig_TiposDeContactos_A_Contextos, RelAsig_TiposDeContactos_A_ContextosExt>,
        IRelAsig_TiposDeContactos_A_ContextosRepositorio
    {
        public RelAsig_TiposDeContactos_A_ContextosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }

        public int SwapAsignacion(int pTipoDeContactoId, ref ControllerBag pControllerBag)
        {
            object tipoDeContactoId = new {TipoDeContactoId = pTipoDeContactoId};
            return CustomExecute(tipoDeContactoId, "usp_RelAsig_TiposDeContactos_A_Contextos__Swap@TipoDeContactoId",
                ref pControllerBag);
        }
    }
}