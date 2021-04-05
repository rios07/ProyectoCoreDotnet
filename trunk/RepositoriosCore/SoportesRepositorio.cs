using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface ISoportesRepositorio : IRepositorio<Soportes, SoportesExt>
    {
    }

    public class SoportesRepositorio : BaseRepositorios<Soportes, SoportesExt>, ISoportesRepositorio
    {
        //acá se pueden agregar nuevas funcionalidades de repositorio particulares o sobreescribir las existentes
        public SoportesRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}