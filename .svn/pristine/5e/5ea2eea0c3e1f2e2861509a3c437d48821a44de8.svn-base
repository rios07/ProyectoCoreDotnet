using FuncionesCore;
using ModelosCore;

using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IRecursosRepositorio : IRepositorio<Recursos, RecursosExt>
    {
        bool EsResponsableDelRecurso(int pRecursoId, ref ControllerBag pControllerBag);
    }

    public class RecursosRepositorio : BaseRepositorios<Recursos, RecursosExt>, IRecursosRepositorio
    {
        public RecursosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }


        public bool EsResponsableDelRecurso(int pRecursoId, ref ControllerBag pControllerBag)
        {
            object obj = new {RecursoId = pRecursoId};
            CustomExecute(obj, "usp_Recursos__EsResponsableDelRecurso", ref pControllerBag);
            if (pControllerBag.TieneErrores())
            {
                pControllerBag.Clear();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}