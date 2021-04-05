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
    public interface ICategoriasDeInformesServicio : IBaseServicios<CategoriasDeInformes, CategoriasDeInformesExt>
    {

    }
    public class CategoriasDeInformesServicio : BaseServicios<CategoriasDeInformes, CategoriasDeInformesExt>, ICategoriasDeInformesServicio
    {
        private ICategoriasDeInformesRepositorio _CategoriasDeInformesRepositorio;

        public CategoriasDeInformesServicio(ICategoriasDeInformesRepositorio pCategoriasDeInformesRepositorio)
        {
            _CategoriasDeInformesRepositorio = pCategoriasDeInformesRepositorio;
        }

        public override IRepositorio<CategoriasDeInformes, CategoriasDeInformesExt> GetRepositorio()
        {
            return _CategoriasDeInformesRepositorio;
        }
    }

}
