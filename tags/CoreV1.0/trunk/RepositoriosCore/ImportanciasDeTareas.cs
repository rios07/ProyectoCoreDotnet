using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IImportanciasDeTareasRepositorio : IRepositorio<ImportanciasDeTareas, ImportanciasDeTareasExt>
    {

    }

    public class ImportanciasDeTareasRepositorio : BaseRepositorios<ImportanciasDeTareas, ImportanciasDeTareasExt>, IImportanciasDeTareasRepositorio
    {
        public ImportanciasDeTareasRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }
    }
}
