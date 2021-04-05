using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IContactosRepositorio : IRepositorio<Contactos, ContactosExt>
    {
    }

    public class ContactosRepositorio : BaseRepositorios<Contactos, ContactosExt>, IContactosRepositorio
    {
        public ContactosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}