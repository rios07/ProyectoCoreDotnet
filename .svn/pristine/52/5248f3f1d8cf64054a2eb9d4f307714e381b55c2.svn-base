using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface
        IRelAsig_Usuarios_A_RecursosRepositorio : IRepositorio<RelAsig_Usuarios_A_Recursos,
            RelAsig_Usuarios_A_RecursosExt>
    {
        int InsertByUsuarioIdsString(int pRecursoId, string pUsuarioIdsString, ref ControllerBag pControllerBag);
        int UpdateByUsuarioIdsString(int pRecursoId, string pUsuarioIdsString, ref ControllerBag pControllerBag);
        List<RelAsig_Usuarios_A_RecursosExt> ResponsablesDelRecurso(int pRecursoId, ref ControllerBag pControllerBag);
    }

    public class RelAsig_Usuarios_A_RecursosRepositorio :
        BaseRepositorios<RelAsig_Usuarios_A_Recursos, RelAsig_Usuarios_A_RecursosExt>,
        IRelAsig_Usuarios_A_RecursosRepositorio
    {
        public RelAsig_Usuarios_A_RecursosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }

        public int InsertByUsuarioIdsString(int pRecursoId, string pUsuarioIdsString, ref ControllerBag pControllerBag)
        {
            object obj = new {RecursoId = pRecursoId, UsuarioIdsString = pUsuarioIdsString, id = 0};
            return CustomExecute(obj, "usp_RelAsig_Usuarios_A_Recursos__Insert_by_@UsuarioIdsString",
                ref pControllerBag);
        }

        public int UpdateByUsuarioIdsString(int pRecursoId, string pUsuarioIdsString, ref ControllerBag pControllerBag)
        {
            object obj = new {RecursoId = pRecursoId, UsuarioIdsString = pUsuarioIdsString, id = 0};
            return CustomExecute(obj, "usp_RelAsig_Usuarios_A_Recursos__Update_by_@UsuarioIdsString",
                ref pControllerBag);
        }

        public List<RelAsig_Usuarios_A_RecursosExt> ResponsablesDelRecurso(int pRecursoId,
            ref ControllerBag pControllerBag)
        {
            object obj = new {RecursoId = pRecursoId};
            return (List<RelAsig_Usuarios_A_RecursosExt>) CustomMultipleQuery<object, RelAsig_Usuarios_A_RecursosExt>(
                obj, "usp_RelAsig_Usuarios_A_Recursos__Listado_by_@RecursoId", ref pControllerBag);
        }
    }
}