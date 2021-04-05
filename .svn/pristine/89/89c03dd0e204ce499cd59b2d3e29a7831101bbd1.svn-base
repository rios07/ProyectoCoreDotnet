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
    public interface IIconosCSSServicio : IBaseServicios<IconosCSS, IconosCSSExt>
    {

    }

    public class IconosCSSServicio : BaseServicios<IconosCSS, IconosCSSExt>, IIconosCSSServicio
    {
        private IIconosCSSRepositorio _IconosCSSRepositorio;

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