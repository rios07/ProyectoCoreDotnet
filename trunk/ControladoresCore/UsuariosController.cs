/* Ordenar por nombre los ussing */

using System.Web.Mvc;
using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

namespace ControladoresCore
{
    public class UsuariosController : BaseControladores<Usuarios, UsuariosExt, UsuariosVM>
    {
        private readonly IUsuariosServicio _usuariosServicio;

        // Constructor
        public UsuariosController(IUsuariosServicio pUsuariosServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuarioServicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuarioServicio, pNotificacionesServicio)
        {
            _usuariosServicio = pUsuariosServicio;
        }

        public override IBaseServicios<Usuarios, UsuariosExt> GetServicio()
        {
            return _usuariosServicio;
        }

        public ActionResult CambiarPassword()
        {
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            var pass = new PassVM();
            return View(pass);
        }

        [HttpPost]
        public ActionResult CambiarPassword(PassVM pPass)
        {
            var pass = Mapper.Map<Pass>(pPass);
            _usuariosServicio.CambiarPass(pass, ref _controllerBag);
            if (!(_controllerBag.TieneErrores()))
            {
                _controllerBag.Add("Contraseña actualizada con exito!");
            }

            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            var retDummy = new PassVM();
            return View(retDummy);
        }

        [HttpGet]
        public ActionResult ResetPassword(int pParam)
        {
            var ResetP = new ResetPassVM {UsuarioId = pParam};
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            _controllerBag.DatosDeUnaPagina.Titulo = "Administración > Usuarios - reseteo de contraseña";
            return View(ResetP);
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPassVM Datos)
        {
            _usuariosServicio.ResetPass(Datos.Pass, Datos.UsuarioId, ref _controllerBag);
            var pParam = Datos.UsuarioId;
            return RedirectToAction("Registro", new {pParam});
        }
    }
}