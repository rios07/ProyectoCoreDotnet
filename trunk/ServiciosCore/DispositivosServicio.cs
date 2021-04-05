using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface IDispositivosServicio : IBaseServicios<Dispositivos, DispositivosExt>
    {
        ResultadoValidacionDispositivo validarDispositivo(ref ControllerBag pControllerBag, string pAndroidId);
    }

    public class DispositivosServicio : BaseServicios<Dispositivos, DispositivosExt>, IDispositivosServicio
    {
        private readonly IDispositivosRepositorio _DispositivosRepositorio;
        private readonly IUsuariosRepositorio _usuariosRepositorio;

        public DispositivosServicio(IDispositivosRepositorio pDispositivosRepositorio,
            IUsuariosRepositorio pUsuariosRepositorio)
        {
            _DispositivosRepositorio = pDispositivosRepositorio;
            _usuariosRepositorio = pUsuariosRepositorio;
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _usuariosRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }

        public override IRepositorio<Dispositivos, DispositivosExt> GetRepositorio()
        {
            return _DispositivosRepositorio;
        }


        [ListadoDDL]
        public List<UsuariosExt> UsuariosDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<UsuariosExt>) _usuariosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        public ResultadoValidacionDispositivo validarDispositivo(ref ControllerBag pControllerBag, string pAndroidId)
        {
            return _DispositivosRepositorio.ValidarDispositivo(ref pControllerBag, pAndroidId);
        }
    }
}