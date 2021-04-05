using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ControladoresCore.ViewModels;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using ServiciosCore;
namespace ControladoresCore.Base
{
    public class LoginController : ApiController
    {
        private readonly IUsuariosServicio _IUsuariosServicio;
        private readonly IDispositivosServicio _IDispositivoServicio;
        private readonly ILogLoginsDeDispositivosServicio _logLoginsDeDispositivosServicio;


        public LoginController(IUsuariosServicio pIUsuarioServicio, IDispositivosServicio pIDispositivoServicio, ILogLoginsDeDispositivosServicio pLogLoginsDeDispositivosServicio)
        {
            _IUsuariosServicio = pIUsuarioServicio;
            _IDispositivoServicio= pIDispositivoServicio;
            _logLoginsDeDispositivosServicio = pLogLoginsDeDispositivosServicio;
        }

        // GET: api/Login
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody] LoginVM pLoginData)
        {
            try
            {
                bool activeLog = bool.Parse(ConfigurationManager.AppSettings["activeLog"]);
                if (activeLog)
                {
                    NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

                    string jsonToLog = "Intento de login API User:" + pLoginData.Usuario + "@" + pLoginData.Contexto;
                    Logger.Info(jsonToLog);
                }
               

                var datosDeLogin = new DatosDeLogin();
                if (string.IsNullOrEmpty(pLoginData.Imei))
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Faltan datos criticos para el login");
                }
                var controllerBag = new ControllerBag();
                controllerBag.CodigoDeContexto = pLoginData.Contexto;
                var loginData = new LoginData {Pass = pLoginData.Contraseña, UserName = pLoginData.Usuario};
                if (_IUsuariosServicio.ValidarUsuario(loginData, ref datosDeLogin, ref controllerBag))
                {
                    var validarDispositivo =
                        _IDispositivoServicio.validarDispositivo(ref controllerBag, pLoginData.AndroidId);
                    if (validarDispositivo.valido)
                    {
                        controllerBag.Seccion = "Administracion";
                        var token = TokenGenerator.GenerateTokenJwt(datosDeLogin.NombreCompleto,
                            datosDeLogin.UsuarioId.ToString());
                        controllerBag.Token = token;
                        controllerBag.Operacion = Operacion.insert;
                     LogLoginsDeDispositivos logLoginsDeDispositivos =new LogLoginsDeDispositivos();
                        logLoginsDeDispositivos.Token = token;
                        logLoginsDeDispositivos.UsuarioId = datosDeLogin.UsuarioId;
                        logLoginsDeDispositivos.InicioValides=DateTime.Now;
                        logLoginsDeDispositivos.FechaDeEjecucion=DateTime.Now;
                        logLoginsDeDispositivos.FinValidez=DateTime.Now.AddHours(2);
                        logLoginsDeDispositivos.DispositivoId = validarDispositivo.DispositivoId;
                        _logLoginsDeDispositivosServicio.SetDatosDeLogin(datosDeLogin);
                        _logLoginsDeDispositivosServicio.Insert(logLoginsDeDispositivos,ref controllerBag);
                        return Request.CreateResponse(HttpStatusCode.OK, token);
                    }
                    
                }

                return Request.CreateResponse(HttpStatusCode.Unauthorized, controllerBag[0].Contenido);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}