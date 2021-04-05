using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface IContactosServicio : IBaseServicios<Contactos, ContactosExt>
    {
    }

    public class ContactosServicio : BaseServicios<Contactos, ContactosExt>, IContactosServicio
    {
        private readonly IContactosRepositorio _ContactosRepositorio;
        private readonly IGruposDeContactosRepositorio _gruposDeContactosRepositorio;
        private readonly ITiposDeContactosRepositorio _tiposDeContactosRepositorio;

        public ContactosServicio(IContactosRepositorio pContactosRepositorio,
            ITiposDeContactosRepositorio pTiposDeContactosServicio,
            IGruposDeContactosRepositorio pGruposDeContactosRepositorio)
        {
            _ContactosRepositorio = pContactosRepositorio;
            _tiposDeContactosRepositorio = pTiposDeContactosServicio;
            _gruposDeContactosRepositorio = pGruposDeContactosRepositorio;
        }

        public override IRepositorio<Contactos, ContactosExt> GetRepositorio()
        {
            return _ContactosRepositorio;
        }

        [ListadoDDL]
        public List<TiposDeContactosExt> TiposDeContactos(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _tiposDeContactosRepositorio.SetDatosDeLogin(_ContactosRepositorio.GetDatosDeLogin());
            return _tiposDeContactosRepositorio.ListadoDDLFiltrado(ref pControllerBag);
        }

        [ListadoDDL]
        public List<GruposDeContactosExt> GruposDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _gruposDeContactosRepositorio.SetDatosDeLogin(_ContactosRepositorio.GetDatosDeLogin());
            return (List<GruposDeContactosExt>) _gruposDeContactosRepositorio.ListadoDDL(ref pControllerBag, pActivo,
                pId);
        }
    }
}