using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;

namespace ServiciosCore
{
    public interface ITiposDeContactosServicio : IBaseServicios<TiposDeContactos, TiposDeContactosExt>
    {
        int InsertRelaciones(int pContactoId, string IdString, ref ControllerBag pControllerBag);
        int UpdateRelaciones(int pContactoId, string pIdString, ref ControllerBag pControllerBag);
    }

    public class TiposDeContactosServicio : BaseServicios<TiposDeContactos, TiposDeContactosExt>, ITiposDeContactosServicio
    {
        private ITiposDeContactosRepositorio _TiposDeContactosRepositorio;
        private IRelAsig_Contactos_A_TiposDeContactosRepositorio _relAsigContactosATiposDeContactosRepositorio;
        public TiposDeContactosServicio(ITiposDeContactosRepositorio pTiposDeContactosRepositorio,
                                        IRelAsig_Contactos_A_TiposDeContactosRepositorio pRelAsigContactosATiposDeContactosRepositorio)
        {
            _TiposDeContactosRepositorio = pTiposDeContactosRepositorio;
            _relAsigContactosATiposDeContactosRepositorio = pRelAsigContactosATiposDeContactosRepositorio;
        }

        public override IRepositorio<TiposDeContactos, TiposDeContactosExt> GetRepositorio()
        {
            return _TiposDeContactosRepositorio;
        }

        public int InsertRelaciones(int pContactoId, string pIdString, ref ControllerBag pControllerBag)
        {
            RelAsig_Contactos_A_TiposDeContactos obj = new RelAsig_Contactos_A_TiposDeContactos
            {
                ContactoId = pContactoId,
                TipoDeContactoIdsString = pIdString
            };
            _relAsigContactosATiposDeContactosRepositorio.SetDatosDeLogin(_TiposDeContactosRepositorio.GetDatosDeLogin());
            return _relAsigContactosATiposDeContactosRepositorio.InsertIdstrings(obj, ref pControllerBag);
        }

        public int UpdateRelaciones(int pContactoId, string pIdString, ref ControllerBag pControllerBag)
        {
            RelAsig_Contactos_A_TiposDeContactos obj = new RelAsig_Contactos_A_TiposDeContactos
            {
                ContactoId = pContactoId,
                TipoDeContactoIdsString = pIdString
            };
            _relAsigContactosATiposDeContactosRepositorio.SetDatosDeLogin(_TiposDeContactosRepositorio.GetDatosDeLogin());
            return _relAsigContactosATiposDeContactosRepositorio.UpdateIdstrings(obj, ref pControllerBag);
        }
    }

}