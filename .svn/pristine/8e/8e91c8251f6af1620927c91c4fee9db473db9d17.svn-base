using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface ISeccionesServicio : IBaseServicios<Secciones, SeccionesExt>
    {
    }

    public class SeccionesServicio : BaseServicios<Secciones, SeccionesExt>, ISeccionesServicio
    {
        private readonly ISeccionesRepositorio _SeccionesRepositorio;

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