/* Ordenar por nombre los ussing */
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using FuncionesCore;
using ModelosCore;
using ServiciosCore;
using System.Web.Mvc;
using AutoMapper;

namespace ControladoresCore
{
    public class UsuariosController : BaseControladores<Usuarios, UsuariosExt, UsuariosVM>
    {
        private IUsuariosServicio _usuariosServicio;

        // Constructor
        public UsuariosController(IUsuariosServicio pUsuariosServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuarioServicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuarioServicio, pNotificacionesServicio)
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
            PassVM pass = new PassVM();
            return View(pass);
        }

        [HttpPost]
        public ActionResult CambiarPassword(PassVM pPass)
        {
            Pass pass = Mapper.Map<Pass>(pPass);
            _usuariosServicio.CambiarPass(pass, ref _controllerBag);
            _controllerBag.Add("Contraseña actualizada con exito!");
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            PassVM retDummy = new PassVM();
            return View(retDummy);
        }
        [HttpGet]
        public ActionResult ResetPassword(int pParam)
        {
            ResetPassVM ResetP = new ResetPassVM{ UsuarioId = pParam };
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            return View(ResetP);
        }
        [HttpPost]
        public ActionResult ResetPassword(ResetPassVM Datos)
        {
            _usuariosServicio.ResetPass(Datos.Pass, Datos.UsuarioId, ref _controllerBag);
            int pParam = Datos.UsuarioId;
            return RedirectToAction("Registro", new{ pParam });
        }
        
    }
}