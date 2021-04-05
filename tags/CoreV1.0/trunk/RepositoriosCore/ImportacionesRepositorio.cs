using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IImportacionesRepositorio : IRepositorio<Importaciones, ImportacionesExt>
    {

    }

    public class ImportacionesRepositorio : BaseRepositorios<Importaciones, ImportacionesExt>, IImportacionesRepositorio
    {
        public ImportacionesRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }
    }
}
