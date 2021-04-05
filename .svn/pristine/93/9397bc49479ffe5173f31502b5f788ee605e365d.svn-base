using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface IIconosCSSServicio : IBaseServicios<IconosCSS, IconosCSSExt>
    {
    }

    public class IconosCSSServicio : BaseServicios<IconosCSS, IconosCSSExt>, IIconosCSSServicio
    {
        private readonly IIconosCSSRepositorio _IconosCSSRepositorio;

        public IconosCSSServicio(IIconosCSSRepositorio pIconosCSSRepositorio)
        {
            _IconosCSSRepositorio = pIconosCSSRepositorio;
        }

        public override IRepositorio<IconosCSS, IconosCSSExt> GetRepositorio()
        {
            return _IconosCSSRepositorio;
        }
    }
}