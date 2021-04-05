using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface ICategoriasDeInformesServicio : IBaseServicios<CategoriasDeInformes, CategoriasDeInformesExt>
    {
    }

    public class CategoriasDeInformesServicio : BaseServicios<CategoriasDeInformes, CategoriasDeInformesExt>,
        ICategoriasDeInformesServicio
    {
        private readonly ICategoriasDeInformesRepositorio _CategoriasDeInformesRepositorio;

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