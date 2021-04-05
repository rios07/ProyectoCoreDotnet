using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface IActoresServicio : IBaseServicios<Actores, ActoresExt>
    {
    }

    public class ActoresServicio : BaseServicios<Actores, ActoresExt>, IActoresServicio
    {
        private readonly IActoresRepositorio _actoresRepositorio;
        private readonly ITiposDeActoresRepositorio _tipoDeActoresRepositorio;

        public ActoresServicio(IActoresRepositorio pActoresRepositorio,
            ITiposDeActoresRepositorio pTiposDeActoresRepositorio)
        {
            _actoresRepositorio = pActoresRepositorio;
            _tipoDeActoresRepositorio = pTiposDeActoresRepositorio;
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _tipoDeActoresRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }

        [ListadoDDL]
        public List<TiposDeActores> GetActores(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<TiposDeActores>) _tipoDeActoresRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        public override IRepositorio<Actores, ActoresExt> GetRepositorio()
        {
            return _actoresRepositorio;
        }
    }
}