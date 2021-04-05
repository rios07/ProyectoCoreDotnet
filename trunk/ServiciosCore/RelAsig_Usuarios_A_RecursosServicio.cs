using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface
        IRelAsig_Usuarios_A_RecursosServicio : IBaseServicios<RelAsig_Usuarios_A_Recursos,
            RelAsig_Usuarios_A_RecursosExt>
    {
        int InsertByUsuarioIdsString(int pRecursoId, string pUsuarioIdsString, ref ControllerBag pControllerBag);
        int UpdateByUsuarioIdsString(int pRecursoId, string pUsuarioIdsString, ref ControllerBag pControllerBag);
        List<RelAsig_Usuarios_A_RecursosExt> ResponsablesDeRecurso(int pRecursoId, ref ControllerBag pControllerBag);
    }

    public class RelAsig_Usuarios_A_RecursosServicio :
        BaseServicios<RelAsig_Usuarios_A_Recursos, RelAsig_Usuarios_A_RecursosExt>, IRelAsig_Usuarios_A_RecursosServicio
    {
        private readonly IRelAsig_Usuarios_A_RecursosRepositorio _RelAsig_Usuarios_A_RecursosRepositorio;

        public RelAsig_Usuarios_A_RecursosServicio(
            IRelAsig_Usuarios_A_RecursosRepositorio pRelAsig_Usuarios_A_RecursosRepositorio)
        {
            _RelAsig_Usuarios_A_RecursosRepositorio = pRelAsig_Usuarios_A_RecursosRepositorio;
        }

        public int InsertByUsuarioIdsString(int pRecursoId, string pUsuarioIdsString, ref ControllerBag pControllerBag)
        {
            return _RelAsig_Usuarios_A_RecursosRepositorio.InsertByUsuarioIdsString(pRecursoId, pUsuarioIdsString,
                ref pControllerBag);
        }

        public int UpdateByUsuarioIdsString(int pRecursoId, string pUsuarioIdsString, ref ControllerBag pControllerBag)
        {
            return _RelAsig_Usuarios_A_RecursosRepositorio.UpdateByUsuarioIdsString(pRecursoId, pUsuarioIdsString,
                ref pControllerBag);
        }

        public List<RelAsig_Usuarios_A_RecursosExt> ResponsablesDeRecurso(int pRecursoId,
            ref ControllerBag pControllerBag)
        {
            return _RelAsig_Usuarios_A_RecursosRepositorio.ResponsablesDelRecurso(pRecursoId, ref pControllerBag);
        }

        public override IRepositorio<RelAsig_Usuarios_A_Recursos, RelAsig_Usuarios_A_RecursosExt> GetRepositorio()
        {
            return _RelAsig_Usuarios_A_RecursosRepositorio;
        }
    }
}