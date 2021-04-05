using RepositoriosCore;
using RepositoriosCore.Base;
using ModelosCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IPlanesDe_TrabajoRepositorio : IRepositorio<PlanesDe_Trabajo,PlanesDe_TrabajoEx>
    {

    }
    class PlanesDe_TrabajoRepositorio : BaseRepositorios<PlanesDe_Trabajo, PlanesDe_TrabajoEx> ,IPlanesDe_TrabajoRepositorio
    {
        public PlanesDe_TrabajoRepositorio(IConexion MiConexion) : base(MiConexion)
        {

        }
    }
}
