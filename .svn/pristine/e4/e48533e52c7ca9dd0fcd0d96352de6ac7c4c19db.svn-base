using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface ITiposDeContactosServicio : IBaseServicios<TiposDeContactos, TiposDeContactosExt>
    {
        int InsertRelaciones(int pContactoId, string IdString, ref ControllerBag pControllerBag);
        int UpdateRelaciones(int pContactoId, string pIdString, ref ControllerBag pControllerBag);
    }

    public class TiposDeContactosServicio : BaseServicios<TiposDeContactos, TiposDeContactosExt>,
        ITiposDeContactosServicio
    {
        private readonly IRelAsig_Contactos_A_TiposDeContactosRepositorio _relAsigContactosATiposDeContactosRepositorio;
        private readonly ITiposDeContactosRepositorio _TiposDeContactosRepositorio;

        public TiposDeContactosServicio(ITiposDeContactosRepositorio pTiposDeContactosRepositorio,
            IRelAsig_Contactos_A_TiposDeContactosRepositorio pRelAsigContactosATiposDeContactosRepositorio)
        {
            _TiposDeContactosRepositorio = pTiposDeContactosRepositorio;
            _relAsigContactosATiposDeContactosRepositorio = pRelAsigContactosATiposDeContactosRepositorio;
        }

        public int InsertRelaciones(int pContactoId, string pIdString, ref ControllerBag pControllerBag)
        {
            var obj = new RelAsig_Contactos_A_TiposDeContactos
            {
                ContactoId = pContactoId,
                TipoDeContactoIdsString = pIdString
            };
            _relAsigContactosATiposDeContactosRepositorio.SetDatosDeLogin(
                _TiposDeContactosRepositorio.GetDatosDeLogin());
            return _relAsigContactosATiposDeContactosRepositorio.InsertIdstrings(obj, ref pControllerBag);
        }

        public int UpdateRelaciones(int pContactoId, string pIdString, ref ControllerBag pControllerBag)
        {
            var obj = new RelAsig_Contactos_A_TiposDeContactos
            {
                ContactoId = pContactoId,
                TipoDeContactoIdsString = pIdString
            };
            _relAsigContactosATiposDeContactosRepositorio.SetDatosDeLogin(
                _TiposDeContactosRepositorio.GetDatosDeLogin());
            return _relAsigContactosATiposDeContactosRepositorio.UpdateIdstrings(obj, ref pControllerBag);
        }

        public override IRepositorio<TiposDeContactos, TiposDeContactosExt> GetRepositorio()
        {
            return _TiposDeContactosRepositorio;
        }
    }
}