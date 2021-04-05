using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;

namespace ServiciosCore
{
    public interface IRelAsig_Contactos_A_GruposDeContactosServicio : IBaseServicios<RelAsig_Contactos_A_GruposDeContactos, RelAsig_Contactos_A_GruposDeContactosExt>
    {
        int InsertByContactosIdsString(string pIdsString, int pGrupoDeContactosId, ref ControllerBag pControllerBag);
        int InsertByGrupoDeContactoId(string pGrupoDeContactoId, int pContactoId, ref ControllerBag pControllerBag);
        int UpdateByContactosIdsString(string pIdsString, int pGrupoDeContactosId, ref ControllerBag pControllerBag);
        int UpdateByGrupoDeContactoId(string pGrupoDeContactoId, int pContactoId, ref ControllerBag pControllerBag);
    }

    public class RelAsig_Contactos_A_GruposDeContactosServicio : BaseServicios<RelAsig_Contactos_A_GruposDeContactos, RelAsig_Contactos_A_GruposDeContactosExt>, IRelAsig_Contactos_A_GruposDeContactosServicio
    {
        private IRelAsig_Contactos_A_GruposDeContactosRepositorio _RelAsig_Contactos_A_GruposDeContactosRepositorio;

        public RelAsig_Contactos_A_GruposDeContactosServicio(IRelAsig_Contactos_A_GruposDeContactosRepositorio pRelAsig_Contactos_A_GruposDeContactosRepositorio)
        {
            _RelAsig_Contactos_A_GruposDeContactosRepositorio = pRelAsig_Contactos_A_GruposDeContactosRepositorio;
        }

        public override IRepositorio<RelAsig_Contactos_A_GruposDeContactos, RelAsig_Contactos_A_GruposDeContactosExt> GetRepositorio()
        {
            return _RelAsig_Contactos_A_GruposDeContactosRepositorio;
        }

        public int InsertByContactosIdsString(string pIdsString, int pGrupoDeContactosId, ref ControllerBag pControllerBag)
        {
            return _RelAsig_Contactos_A_GruposDeContactosRepositorio.InsertByContactosIdsString(pIdsString,pGrupoDeContactosId,ref pControllerBag);
        }

        public int InsertByGrupoDeContactoId(string pGrupoDeContactoId, int pContactoId, ref ControllerBag pControllerBag)
        {
            return _RelAsig_Contactos_A_GruposDeContactosRepositorio.InsertByGrupoDeContactoId(pGrupoDeContactoId, pContactoId, ref pControllerBag);
        }

        public int UpdateByContactosIdsString(string pIdsString, int pGrupoDeContactosId, ref ControllerBag pControllerBag)
        {
            return _RelAsig_Contactos_A_GruposDeContactosRepositorio.UpdateByContactosIdsString(pIdsString, pGrupoDeContactosId, ref pControllerBag);
        }

        public int UpdateByGrupoDeContactoId(string pGrupoDeContactoId, int pContactoId, ref ControllerBag pControllerBag)
        {
            return _RelAsig_Contactos_A_GruposDeContactosRepositorio.UpdateByGrupoDeContactoId(pGrupoDeContactoId, pContactoId, ref pControllerBag);
        }

        
    }

}