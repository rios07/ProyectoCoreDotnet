using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;

namespace ServiciosCore
{
    public interface IInformesServicio : IBaseServicios<Informes, InformesExt>
    {
        IEnumerable<CategoriasDeInformes> ListadoCategorias(ref ControllerBag pControllerBag, bool? pActivo, int pId);
    }

    public class InformesServicio : BaseServicios<Informes, InformesExt>, IInformesServicio
    {
        private IInformesRepositorio _informesRepositorio;
        private ICategoriasDeInformesRepositorio _categoriasDeInformesRepositorio;

        public InformesServicio(IInformesRepositorio pInformesRepositorio, ICategoriasDeInformesRepositorio pCategoriasDeInformesRepositorio)
        {
            _informesRepositorio = pInformesRepositorio;
            _categoriasDeInformesRepositorio = pCategoriasDeInformesRepositorio;
        }

        [ListadoDDL]
        public IEnumerable<CategoriasDeInformes> ListadoCategorias(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return _categoriasDeInformesRepositorio.ListadoDDL(ref pControllerBag,pActivo, pId);
        }

        /// <summary>
        /// Devuelve InformesRepositorio para que lo use el Servicio base.
        /// </summary>
        /// <returns></returns>
        public override IRepositorio<Informes, InformesExt> GetRepositorio()
        {
            return _informesRepositorio;
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _categoriasDeInformesRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }





    }
}
