/* Ordenar por nombre los ussing */

using System;
using System.Web.Mvc;
using System.Web.Security;
using ControladoresCore.ViewModels;
using FuncionesCore;
using RepositoriosCore;
using ServiciosCore; /*using RepositoriosCore;*/

namespace ControladoresCore
{
    public class HomeController : Controller
    {
        private readonly INotificacionesServicio _notificacionesServicio;
        private readonly IUsuariosServicio _usuariosServicio;

        public HomeController(IUsuariosServicio pUsuariosServicio, INotificacionesServicio pNotificacionesServicio)
        {
            _usuariosServicio = pUsuariosServicio;
            _notificacionesServicio = pNotificacionesServicio;
        }

        protected override void OnActionExecuting(ActionExecutingContext pFilterContext)
        {
            if (pFilterContext.RouteData.Values["pSeccion"] != null)
                ViewBag.Seccion = pFilterContext.RouteData.Values["pSeccion"].ToString().ToLower();
        }

        public ActionResult Index(string returnUrl)
        {
            var controllerBag = new ControllerBag();
            ViewBag.DatosDeUnaPagina = new DatosDeUnaPagina {Notas = "", Tips = "", Titulo = "Home"};
            if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl)) ViewBag.ReturnURL = returnUrl;

            if ((Request.Cookies[".ASPXAUTH"] != null || Request.Cookies["AuthCookie_Intra"] != null) &&
                (Session["DatosDeLogin"] == null || ((DatosDeLogin) Session["DatosDeLogin"]).UsuarioId == 1))
            {
                DatosDeLogin datosDeLogin = null;
                var flagSitioExterno = false;

                if (Request.Cookies["AuthCookie_Intra"] != null) //si usa cookie propia
                {
                    datosDeLogin =
                        _usuariosServicio.ConfirmarCookie(Server.HtmlEncode(Request.Cookies["AuthCookie_Intra"].Value),
                            ref controllerBag);
                    flagSitioExterno = true;
                }
                else //si usa cookie de la intra
                {
                    datosDeLogin =
                        _usuariosServicio.ConfirmarCookie(Server.HtmlEncode(Request.Cookies[".ASPXAUTH"].Value),
                            ref controllerBag);
                }

                if (datosDeLogin.UsuarioId > 1)
                {
                    Session.Add("DatosDeLogin", datosDeLogin);
                    TempData["EsMasterAdmin"] = datosDeLogin.EsMasterAdmin;
                    if (datosDeLogin != null)
                        TempData["EsMasterAdmin"] = datosDeLogin.EsMasterAdmin;

                    if (Request.Cookies[".ASPXAUTH"] == null)
                    {
                        FormsAuthentication.SetAuthCookie(datosDeLogin.NombreCompleto, false);
                        _usuariosServicio.SetDatosDeLogin(datosDeLogin);
                        var cookieData = new CookieData
                        {
                            AuthCookie = Response.Cookies[".ASPXAUTH"].Value
                        }; // Estaba DateTime.Now.AddMinutes(30), revisar si el un tiempo correcto q sea "Now.AddMinutes(30) };
                        if (!flagSitioExterno) _usuariosServicio.ActualizarCookie(cookieData, ref controllerBag);

                        return RedirectToAction("Index");
                    }
                }

                //else //si no trajo datos válidos, reseteo la cookie, la sesión y redirijo al login
                //{
                //    Response.Cookies[".ASPXAUTH"].Expires = FechasYHoras.FechaYTiempoExpiraCookie();
                //    Session.Abandon();
                //    pFilterContext.Result = RedirectToAction("Index", "Home");
                //    return;
                //}
            }

            if (Session["DatosDeLogin"] != null)
            {
                var datosDeLogin = (DatosDeLogin) Session["DatosDeLogin"];
                TempData["Nombre"] = datosDeLogin.NombreCompleto;
                ViewBag.Roles = datosDeLogin.RolesDeUsuario;
            }

            return View();
        }

        [HttpPost]
        //Esta acción se llama cuando se especifica que el método es POST desde la view (ver Home/index.cshtml)
        public ActionResult Index(LoginVM pLoginDataVM, string returnUrl = "")
        {
            var datosDeLogin = new DatosDeLogin();

            var loginData = new LoginData();

            loginData.UserName = pLoginDataVM.Usuario;
            //loginData.Contexto = pLoginDataVM.Contexto;
            loginData.Pass = pLoginDataVM.Contraseña;

            var controllerBag = new ControllerBag();
            controllerBag.CodigoDeContexto = pLoginDataVM.Contexto;
            var usuarioValido = _usuariosServicio.ValidarUsuario(loginData, ref datosDeLogin, ref controllerBag);
            var decodedUrl = "";
            if (!string.IsNullOrEmpty(returnUrl))
                decodedUrl = Server.UrlDecode(returnUrl);
            //hardcodeo un usuario y contraseña para probar, ver cómo se usan los campos directamente
            if (usuarioValido)
            {
                FormsAuthentication.SetAuthCookie(loginData.UserName, false);
                Session.Add("DatosDeLogin", datosDeLogin);
                _usuariosServicio.SetDatosDeLogin(datosDeLogin);
                TempData["EsMasterAdmin"] = datosDeLogin.EsMasterAdmin;
                var cookieData = new CookieData
                {
                    AuthCookie = Response.Cookies[".ASPXAUTH"].Value
                }; // Estaba DateTime.Now.AddMinutes(30), revisar si el un tiempo correcto q sea "Now.AddMinutes(30) };
                _usuariosServicio.ActualizarCookie(cookieData, ref controllerBag);


                if (Url.IsLocalUrl(decodedUrl))
                    return Redirect(decodedUrl);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.User = pLoginDataVM.Usuario;
            ViewBag.Contexto = pLoginDataVM.Contexto;
            ViewBag.loginMensaje = controllerBag[0].Contenido;
            ViewBag.loginMensajeOK = false;
            //Hardcodeo para que no explote si hay error, porque no pasa por OnActionExecuting
            ViewBag.DatosDeUnaPagina = new DatosDeUnaPagina {Titulo = "Home"};
            if (Url.IsLocalUrl(decodedUrl))
                return Redirect(decodedUrl);
            return View();
        }

        public ActionResult Logout()
        {
            if (Response.Cookies[".ASPXAUTH"] != null)
            {
                Response.Cookies[".ASPXAUTH"].Expires = DateTime.Now.AddDays(-1);
            }
            if (Response.Cookies["AuthCookie_Intra"] != null)
            {
                Response.Cookies["AuthCookie_Intra"].Expires = DateTime.Now.AddDays(-1);
            }

            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.message = "ABAKO Develop";

            return View();
        }

        public ActionResult contact()
        {
            ViewBag.message = "Your contact page.";

            return View();
        }


        public virtual JsonResult CargarNotificaciones()
        {
            var _controllerBag = new ControllerBag();
            var datosDeLogin = (DatosDeLogin) Session["DatosDeLogin"];
            if (datosDeLogin != null)
            {
                _notificacionesServicio.SetDatosDeLogin(datosDeLogin);
                return Json(_notificacionesServicio.CargarNotificaciones(ref _controllerBag),
                    JsonRequestBehavior.AllowGet);
            }

            return Json("");
        }

        public virtual JsonResult NotificacionVista(int pId)
        {
            var _controllerBag = new ControllerBag();
            var datosDeLogin = (DatosDeLogin) Session["DatosDeLogin"];
            _notificacionesServicio.SetDatosDeLogin(datosDeLogin);
            return Json(_notificacionesServicio.NotificacionVista(pId, ref _controllerBag),
                JsonRequestBehavior.AllowGet);
        }
    }
}