using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepositoriosCore
{
    public interface IUsuariosRepositorio : IRepositorio<Usuarios, UsuariosExt>
    {
        IEnumerable<RetornoLogin> Login(LoginData pLoginData, ref ControllerBag pControllerBag);
        IEnumerable<RetornoLogin> ConfirmarCookie(CookieData pCookie, ref ControllerBag pControllerBag);
        int CargarCookie(CookieData pCookieData, ref ControllerBag pControllerBag);
        int CambiarPass(Pass pPass, ref ControllerBag pControllerBag);
        void ResetPass(string pPass, int pUsuarioId, ref ControllerBag pControllerBag);
    }

    public class UsuariosRepositorio : BaseRepositorios<Usuarios, UsuariosExt>, IUsuariosRepositorio
    {
        public UsuariosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }

        public IEnumerable<RetornoLogin> Login(LoginData pLoginData, ref ControllerBag pControllerBag)
        {
            pLoginData.Pass = FCodificaciones.GetSHA1(pLoginData.Pass).ToUpper();
            return CustomMultipleQuery<LoginData, RetornoLogin>(pLoginData, "usp_Usuarios__login", ref pControllerBag);
        }

        public IEnumerable<RetornoLogin> ConfirmarCookie(CookieData AuthCookie, ref ControllerBag pControllerBag)
        {
           return CustomMultipleQuery<CookieData,RetornoLogin>(AuthCookie, "usp_Usuarios__login", ref pControllerBag);
        }

        public int CambiarPass(Pass pPass, ref ControllerBag pControllerBag)
        {
            pPass.Id = _datosDeLogin.UsuarioId;
            return CustomExecute(pPass, "usp_Usuarios__update_Campos_Cambiar_Pass", ref pControllerBag);
        }

        public int CargarCookie(CookieData pCookieData, ref ControllerBag pControllerBag)
        {
            return CustomExecute(pCookieData, "usp_Usuarios__update_Cookie", ref pControllerBag);
        }

        public void ResetPass(string pPass, int pUsuarioId, ref ControllerBag pControllerBag)
        {
            object pass = new {passNuevo = pPass,id=pUsuarioId};
            base.CustomExecute(pass, "usp_Usuarios__Update_Campos_Reset_Pass", ref pControllerBag);
        }
    }



    public class LoginData
    {
        [Display(Name = "Nombre de Usuario(*)"), Required(ErrorMessage = "El título es requerido"), StringLength(150)]
        public string UserName { get; set; }
        public string Pass { get; set; }
    }

    public class RetornoLogin
    {
        public string NombreCompleto { get; set; }
        public string Contexto_Nombre { get; set; }
        public int RolDeUsuarioId { get; set; }
        public int ContextoId { get; set; }
        public int Id { get; set; }
        public bool EsMasterAdmin { get; set; }
    }

    public class DatosDeLogin
    {
        public string NombreCompleto { get; set; } = "";
        public string Contexto { get; set; } = "";
        public List<int> RolesDeUsuario = new List<int>();
        public int UsuarioId { get; set; } = 1;
        public int ContextoId { get; set; } = 1;
        public bool EsMasterAdmin { get; set; } = false;
    }

    public class CookieData
    {
        public string AuthCookie { get; set; }
       
    }

}
