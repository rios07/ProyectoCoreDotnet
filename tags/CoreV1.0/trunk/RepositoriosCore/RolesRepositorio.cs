using ModelosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosCore
{
    public interface IRolesRepositorio : IRepositorio<RolesDeUsuarios, RolesDeUsuarios>
    {

    }
    public class RolesRepositorio : BaseRepositorios<RolesDeUsuarios, RolesDeUsuarios>, IRolesRepositorio
    {
        public RolesRepositorio(IConexion miConexion) : base(miConexion)
        {

        }
    }
}
