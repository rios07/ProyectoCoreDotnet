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
    public interface IProvinciasServicio : IBaseServicios<Provincias, ProvinciasExt>
    {

    }
    public class ProvinciasServicio : BaseServicios<Provincias, ProvinciasExt>, IProvinciasServicio
    {
        private IProvinciasRepositorio _ProvinciasRepositorio;

        public ProvinciasServicio(IProvinciasRepositorio pProvinciasRepositorio)
        {
            _ProvinciasRepositorio = pProvinciasRepositorio;
        }

        public override IRepositorio<Provincias, ProvinciasExt> GetRepositorio()
        {
            return _ProvinciasRepositorio;
        }
    }

}
