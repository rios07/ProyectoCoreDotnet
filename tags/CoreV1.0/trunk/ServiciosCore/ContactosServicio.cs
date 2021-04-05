using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ServiciosCore;

namespace ServiciosCore
{
    public interface IContactosServicio : IBaseServicios<Contactos, ContactosExt>
    {

    }

    public class ContactosServicio : BaseServicios<Contactos, ContactosExt>, IContactosServicio
    {
        private IContactosRepositorio _ContactosRepositorio;
        private ITiposDeContactosRepositorio _tiposDeContactosRepositorio;
        private IGruposDeContactosRepositorio _gruposDeContactosRepositorio;
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
            return (List<TiposDeContactosExt>)_tiposDeContactosRepositorio.ListadoDDLFiltrado(ref pControllerBag);
        }

        [ListadoDDL]
        public List<GruposDeContactosExt> GruposDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _gruposDeContactosRepositorio.SetDatosDeLogin(_ContactosRepositorio.GetDatosDeLogin());
            return (List<GruposDeContactosExt>) _gruposDeContactosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }
    }
    
}



