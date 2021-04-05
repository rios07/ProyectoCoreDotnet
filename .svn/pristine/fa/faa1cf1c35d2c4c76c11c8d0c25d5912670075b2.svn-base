using ControladoresCore.ViewModels;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using ServiciosCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ControladoresCore.Base
{
    public class LoginController : ApiController
    {
        private IUsuariosServicio _IUsuariosServicio;
        public LoginController(IUsuariosServicio pIUsuarioServicio) {
            _IUsuariosServicio = pIUsuarioServicio;
        }

        // GET: api/Login
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody] LoginVM pLoginData)
        {
            try
            {
                DatosDeLogin datosDeLogin = new DatosDeLogin();
                
                var controllerBag = new ControllerBag();
                controllerBag.CodigoDeContexto = pLoginData.Contexto;
                LoginData loginData = new LoginData{Pass = pLoginData.Contraseña,UserName = pLoginData.Usuario};
                if (_IUsuariosServicio.ValidarUsuario(loginData, ref datosDeLogin, ref controllerBag))
                    return Request.CreateResponse(HttpStatusCode.OK, TokenGenerator.GenerateTokenJwt(datosDeLogin.NombreCompleto, datosDeLogin.UsuarioId.ToString()));
                else
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, controllerBag[0].Contenido);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,e.Message);
            }
           
        }

    }
}
