using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IRelAsig_Contactos_A_GruposDeContactosRepositorio : IRepositorio<RelAsig_Contactos_A_GruposDeContactos, RelAsig_Contactos_A_GruposDeContactosExt>
    {
        int InsertByContactosIdsString(string pIdsString,int pGrupoDeContactosId, ref ControllerBag pControllerBag);
        int InsertByGrupoDeContactoId(string pGrupoDeContactosId, int pContacoId, ref ControllerBag pControllerBag);
        int UpdateByContactosIdsString(string pIdsString,int pGrupoDeContactosId, ref ControllerBag pControllerBag);
        int UpdateByGrupoDeContactoId(string pGrupoDeContactosId, int pContacoId, ref ControllerBag pControllerBag);
    }

    public class RelAsig_Contactos_A_GruposDeContactosRepositorio : BaseRepositorios<RelAsig_Contactos_A_GruposDeContactos, RelAsig_Contactos_A_GruposDeContactosExt>, IRelAsig_Contactos_A_GruposDeContactosRepositorio
    {
        public RelAsig_Contactos_A_GruposDeContactosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }

        public int InsertByContactosIdsString(string pIdsString, int pGrupoDeContactosId, ref ControllerBag pControllerBag)
        {
            object IdsObject = new
            {
                Id = 0,
                ContactoIdsString = pIdsString,
                GrupoDeContactoId = pGrupoDeContactosId
            };
            return CustomExecute(IdsObject, "usp_RelAsig_Contactos_A_GruposDeContactos__Insert_by_@ContactoIdsString",ref pControllerBag);
        }
        public int InsertByGrupoDeContactoId(string pGrupoDeContactosId, int pContacoId , ref ControllerBag pControllerBag)
        {
            object IdsObject = new
            {
                Id = 0,
                ContactoId = pContacoId,
                GrupoDeContactoIdsString = pGrupoDeContactosId
            };
            return CustomExecute(IdsObject, "usp_RelAsig_Contactos_A_GruposDeContactos__Insert_by_@GrupoDeContactoIdsString", ref pControllerBag);
        }

        public int UpdateByContactosIdsString(string pIdsString, int pGrupoDeContactosId, ref ControllerBag pControllerBag)
        {
            object IdsObject = new
            {
                Id = 0,
                ContactoIdsString = pIdsString,
                GrupoDeContactoId = pGrupoDeContactosId
            };
            return CustomExecute(IdsObject, "usp_RelAsig_Contactos_A_GruposDeContactos__Update_by_@ContactoIdsString",ref pControllerBag);
        }
        public int UpdateByGrupoDeContactoId(string pGrupoDeContactosId, int pContacoId , ref ControllerBag pControllerBag)
        {
            object IdsObject = new
            {
                Id = 0,
                ContactoId = pContacoId,
                GrupoDeContactoIdsString = pGrupoDeContactosId
            };
            return CustomExecute(IdsObject, "usp_RelAsig_Contactos_A_GruposDeContactos__Update_by_@GrupoDeContactoIdsString", ref pControllerBag);
        }
    }
}