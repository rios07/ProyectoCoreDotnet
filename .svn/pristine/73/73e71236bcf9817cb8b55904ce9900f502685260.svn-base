using FuncionesCore;
using ModelosCore;

using RepositoriosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IRelAsig_Contactos_A_TiposDeContactosRepositorio : IRepositorio<RelAsig_Contactos_A_TiposDeContactos, RelAsig_Contactos_A_TiposDeContactosExt>
    {
        int InsertIdstrings(RelAsig_Contactos_A_TiposDeContactos pObj, ref ControllerBag pControllerBag);
        int UpdateIdstrings(RelAsig_Contactos_A_TiposDeContactos pObj, ref ControllerBag pControllerBag);
    }

    public class RelAsig_Contactos_A_TiposDeContactosRepositorio : BaseRepositorios<RelAsig_Contactos_A_TiposDeContactos, RelAsig_Contactos_A_TiposDeContactosExt>, IRelAsig_Contactos_A_TiposDeContactosRepositorio
    {
        public RelAsig_Contactos_A_TiposDeContactosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }

        public int InsertIdstrings(RelAsig_Contactos_A_TiposDeContactos pObj, ref ControllerBag pControllerBag)
        {
            return CustomExecute(pObj, "usp_RelAsig_Contactos_A_TiposDeContactos__Insert_by_@TipoDeContactoIdsString", ref pControllerBag);
        }

        public int UpdateIdstrings(RelAsig_Contactos_A_TiposDeContactos pObj, ref ControllerBag pControllerBag)
        {
            return CustomExecute(pObj, "usp_RelAsig_Contactos_A_TiposDeContactos__Update_by_@TipoDeContactoIdsString", ref pControllerBag);
        }
    }
}