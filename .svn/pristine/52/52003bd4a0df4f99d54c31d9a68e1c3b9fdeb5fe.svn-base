using ModelosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;

namespace RepositoriosCore
{
    public interface IPaginasRepositorio : IRepositorio<Paginas, PaginasExt>
    {

    }
    public class PaginasRepositorio : BaseRepositorios<Paginas, PaginasExt>, IPaginasRepositorio
    {
        public PaginasRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }

        public override int Insert(Paginas pObj, ref ControllerBag pControllerBag)
        {
            return CustomExecute(pObj, "usp_Paginas__InsertSegunRoles", ref pControllerBag);
        }
    }
}
