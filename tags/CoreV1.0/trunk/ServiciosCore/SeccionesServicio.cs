using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore
{
    public interface ISeccionesServicio : IBaseServicios<Secciones, SeccionesExt>
    {

    }
    public class SeccionesServicio : BaseServicios<Secciones, SeccionesExt>, ISeccionesServicio
    {
        private ISeccionesRepositorio _SeccionesRepositorio;

        public SeccionesServicio(ISeccionesRepositorio pSeccionesRepositorio)
        {
            _SeccionesRepositorio = pSeccionesRepositorio;
        }

        public override IRepositorio<Secciones, SeccionesExt> GetRepositorio()
        {
            return _SeccionesRepositorio;
        }

    }

}
