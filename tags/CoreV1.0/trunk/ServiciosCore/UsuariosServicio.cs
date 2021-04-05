using _DatosDelSistema;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ServiciosCore
{
    public interface IUsuariosServicio : IBaseServicios<Usuarios, UsuariosExt>
    {
        bool ValidarUsuario(LoginData pUsuario, ref DatosDeLogin pDatosDeLogin, ref ControllerBag pControllerBag);
        DatosDeLogin ConfirmarCookie(string pCookie, ref ControllerBag pControllerBag);
        int ActualizarCookie(CookieData pCookieData, ref ControllerBag pControllerBag);
        IEnumerable<Actores> ListadoActores(ref ControllerBag msg, bool? pActivo, int pId);
        IEnumerable<RolesDeUsuarios> ListadoRolesDe_Usuarios(ref ControllerBag msg, bool? pActivo, int pId);
        void CambiarPass(Pass pContraseña, ref ControllerBag pControllerBag);
        void ResetPass(string pPass, int pUsuarioId, ref ControllerBag pControllerBag);
    }

    public class UsuariosServicio : BaseServicios<Usuarios, UsuariosExt>, IUsuariosServicio
    {
        private IUsuariosRepositorio _usuariosRepositorio;
        private IActoresRepositorio _actoresRepositorio;
        private IRolesRepositorio _rolesRepositorio;

        public UsuariosServicio(IUsuariosRepositorio pUsuariosRepositorio, IActoresRepositorio actoresRepositorio, IRolesRepositorio rolesRepositorio)
        {
            _usuariosRepositorio = pUsuariosRepositorio;
            _actoresRepositorio = actoresRepositorio;
            _rolesRepositorio = rolesRepositorio;
        }

        public DatosDeLogin ConfirmarCookie(string pCookie, ref ControllerBag pControllerBag)
        {
            DatosDeLogin datosDeLogin = new DatosDeLogin();
            CookieData cookieData = new CookieData() { AuthCookie = pCookie }; 
            List<RetornoLogin> retornoLogin = _usuariosRepositorio.ConfirmarCookie(cookieData, ref pControllerBag).ToList();
            if (retornoLogin.Count > 0)
            {
                datosDeLogin.NombreCompleto = retornoLogin.First().NombreCompleto;
                datosDeLogin.EsMasterAdmin = retornoLogin.First().EsMasterAdmin;
                datosDeLogin.Contexto = retornoLogin.First().Contexto_Nombre;
                datosDeLogin.UsuarioId = retornoLogin.First().Id;
                datosDeLogin.ContextoId = retornoLogin.First().ContextoId;
                datosDeLogin.RolesDeUsuario = new List<int>();
                foreach (RetornoLogin obj in retornoLogin)
                {
                    datosDeLogin.RolesDeUsuario.Add(obj.RolDeUsuarioId);
                }
            }

            return datosDeLogin;
            
        }


        public int ActualizarCookie(CookieData pCookiedata, ref ControllerBag pControllerBag)
        {
            return _usuariosRepositorio.CargarCookie(pCookiedata, ref pControllerBag);
        }

        /// <summary>
        /// Devuelve InformesRepositorio para que lo use el Servicio base.
        /// </summary>
        /// <returns></returns>
        public override IRepositorio<Usuarios, UsuariosExt> GetRepositorio()
        {
            return _usuariosRepositorio;
        }


        public bool ValidarUsuario(LoginData pLoginData, ref DatosDeLogin pDatosDeLogin, ref ControllerBag pControllerBag)
        {
            List<RetornoLogin> retornoLogin = _usuariosRepositorio.Login(pLoginData, ref pControllerBag).ToList();
            if (retornoLogin.Count > 0)
            {
                pDatosDeLogin.UsuarioId = retornoLogin.First().Id;
                pDatosDeLogin.ContextoId = retornoLogin.First().ContextoId;
                pDatosDeLogin.NombreCompleto = retornoLogin.First().NombreCompleto;
                pDatosDeLogin.Contexto = retornoLogin.First().Contexto_Nombre;
                pDatosDeLogin.EsMasterAdmin = retornoLogin.First().EsMasterAdmin;
                pDatosDeLogin.RolesDeUsuario = new List<int>();
                foreach (RetornoLogin login in retornoLogin)
                {
                    pDatosDeLogin.RolesDeUsuario.Add(login.RolDeUsuarioId);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        [ListadoDDL]
        public IEnumerable<Actores> ListadoActores(ref ControllerBag msg, bool? pActivo, int pId)
        {
            return _actoresRepositorio.ListadoDDL(ref msg, pActivo, pId);
        }

        [ListadoDDL]
        public IEnumerable<RolesDeUsuarios> ListadoRolesDe_Usuarios(ref ControllerBag msg, bool? pActivo, int pId)
        {
            return _rolesRepositorio.ListadoDDL(ref msg, pActivo, pId);
        }

        public override int Insert(Usuarios pUsuarios, ref ControllerBag pControllerBag)
        {
            pUsuarios.Pass = FCodificaciones.GetSHA1(pUsuarios.Pass);
            return base.Insert(pUsuarios, ref pControllerBag);
        }

        public void CambiarPass(Pass pPass, ref ControllerBag pControllerBag)
        {
            pPass.PassActual = FCodificaciones.GetSHA1(pPass.PassActual);
            pPass.PassNuevo = FCodificaciones.GetSHA1(pPass.PassNuevo);
            _usuariosRepositorio.CambiarPass(pPass, ref pControllerBag);
        }

        public void ResetPass(string pPass, int pUsuarioId, ref ControllerBag pControllerBag)
        {
            pPass = FCodificaciones.GetSHA1(pPass);
            _usuariosRepositorio.ResetPass(pPass, pUsuarioId, ref pControllerBag);
        }
        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _actoresRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _rolesRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }
    }
}
