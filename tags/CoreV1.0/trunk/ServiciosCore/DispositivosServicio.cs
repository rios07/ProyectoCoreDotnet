using FuncionesCore;
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
    public interface IDispositivosServicio : IBaseServicios<Dispositivos, DispositivosExt>
    {

    }
    public class DispositivosServicio : BaseServicios<Dispositivos, DispositivosExt>, IDispositivosServicio
    {
        private IDispositivosRepositorio _DispositivosRepositorio;
        private IUsuariosRepositorio _usuariosRepositorio;
        public DispositivosServicio(IDispositivosRepositorio pDispositivosRepositorio,IUsuariosRepositorio pUsuariosRepositorio)
        {
            _DispositivosRepositorio = pDispositivosRepositorio;
            _usuariosRepositorio = pUsuariosRepositorio;
        }

        public override IRepositorio<Dispositivos, DispositivosExt> GetRepositorio()
        {
            return _DispositivosRepositorio;
        }


        [ListadoDDL]
        public List<UsuariosExt> UsuariosDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<UsuariosExt>)_usuariosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _usuariosRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }
    }

}
