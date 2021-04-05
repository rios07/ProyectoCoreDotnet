using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface IGruposDeContactosServicio : IBaseServicios<GruposDeContactos, GruposDeContactosExt>
    {
    }

    public class GruposDeContactosServicio : BaseServicios<GruposDeContactos, GruposDeContactosExt>,
        IGruposDeContactosServicio
    {
        private readonly IContactosRepositorio _contactosRepositorio;
        private readonly IGruposDeContactosRepositorio _GruposDeContactosRepositorio;

        public GruposDeContactosServicio(IGruposDeContactosRepositorio pGruposDeContactosRepositorio,
            IContactosRepositorio pContactosRepositorio)
        {
            _GruposDeContactosRepositorio = pGruposDeContactosRepositorio;
            _contactosRepositorio = pContactosRepositorio;
        }

        public override IRepositorio<GruposDeContactos, GruposDeContactosExt> GetRepositorio()
        {
            return _GruposDeContactosRepositorio;
        }


        [ListadoDDL]
        public List<ContactosExt> ContactosDd(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _contactosRepositorio.SetDatosDeLogin(_GruposDeContactosRepositorio.GetDatosDeLogin());
            return (List<ContactosExt>) _contactosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }
    }
}