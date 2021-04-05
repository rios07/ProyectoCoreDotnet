using AutoMapper;
using ControladoresCore;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelosCore;
using RepositoriosCore;
using ServiciosCore;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RepositoriosCore.Base;

namespace PruebasCore
{ 
    /*
    [TestClass]
    public class InformesControllerPruebas
    {
        [TestMethod]
        public void testExportar()
        {
            BaseGlobal.InitAutomapper<MockProfile>();
            var controller = new InformesController(new InformesServicio(new InformesRepositorio(new miConexion()), new CategoriasDeInformesRepositorio(new miConexion()))
                                                    , new LogErroresServicio(new LogErroresRepositorio(new miConexion()))
                                                    , new UsuariosServicio(new UsuariosRepositorio(new miConexion()), new ActoresRepositorio(new miConexion()), new RolesRepositorio(new miConexion())));
            var result = (FileStreamResult) controller.Exportar();
            Console.WriteLine(result.FileStream.Length);
        }

        [TestMethod]
        public void testListado()
        {
            BaseGlobal.InitAutomapper<MockProfile>();
            var controller = new InformesController(new InformesServicio(new InformesRepositorio(new miConexion()), new CategoriasDeInformesRepositorio(new miConexion()))
                                                    , new LogErroresServicio(new LogErroresRepositorio(new miConexion()))
                                                    , new UsuariosServicio(new UsuariosRepositorio(new miConexion()), new ActoresRepositorio(new miConexion()), new RolesRepositorio(new miConexion())));
            var result = (ViewResult)controller.Listado();
        }

        [TestMethod]
        public void testIndex()
        {
            BaseGlobal.InitAutomapper<MockProfile>();

            var controller = new InformesController(new MockServicio()
                                                    , new MockLogErroresServicio()
                                                    , new MockUsuariosServicio());

            ViewResult result = (ViewResult)controller.Listado();
            List<InformesVM> listaDeInformes = (List<InformesVM>)result.Model;
            listaDeInformes.ForEach(x => Console.WriteLine(x.ToString()));
            Mapper.Reset();
        }
    }


    #region
    internal class MockUsuariosServicio : IUsuariosServicio
    {
        public MockUsuariosServicio()
        {
        }

        public Exception Agregar(Usuarios pObj)
        {
            throw new NotImplementedException();
        }

        public int ActualizarCookie(CookieData pCookieData)
        {
            throw new NotImplementedException();
        }

        public DatosDeLogin ConfirmarCookie(string pCookie)
        {
            throw new NotImplementedException();
        }

        public int Create(Usuarios pObj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int pId)
        {
            throw new NotImplementedException();
        }

        public Usuarios Get(int pId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuariosExt> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            throw new NotImplementedException();
        }

        public int Update(Usuarios pObj)
        {
            throw new NotImplementedException();
        }

        public bool ValidarUsuario(LoginData pUsuario, ref DatosDeLogin pDatosDeLogin)
        {
            throw new NotImplementedException();
        }

        public int Insert(Usuarios pObj, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int pId, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public Usuarios Registro(int pId, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuariosExt> Listado(ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public int Update(Usuarios pObj, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public bool ValidarUsuario(LoginData pUsuario, ref DatosDeLogin pDatosDeLogin, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public DatosDeLogin ConfirmarCookie(string pCookie, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public int ActualizarCookie(CookieData pCookieData, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuariosExt> GetAll(ListParams pListParams, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuariosExt> Listado(ref ListParams pListParams, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actores> ListadoActores(ref ControllerBag msg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RolesDe_Usuarios> ListadoRolesDe_Usuarios(ref ControllerBag msg)
        {
            throw new NotImplementedException();
        }

        public bool PrecargaInicialDeUnaPagina(Operacion pOp, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuariosExt> Listado(Dictionary<string, string> filtros, ref ListParams pListParams, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        UsuariosExt IBaseServicios<Usuarios, UsuariosExt>.Registro(int pId, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }
    }
    #endregion


    public class MockServicio : IInformesServicio
    {
        public Exception Agregar(Informes pObj)
        {
            throw new NotImplementedException();
        }

        public DatosDeLogin ConfirmarCookie(string pCookie)
        {
            throw new NotImplementedException();
        }

        public int Create(Informes obj)
        {
            throw new NotImplementedException();
        }

        public int Insert(Informes pObj, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int pId, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public Informes Get(int id)
        {
            throw new NotImplementedException();
        }

        public Informes Registro(int pId, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<InformesExt> GetAll()
        {
            return new List<InformesExt>()
            {
                new InformesExt() { Categoria = "Cat A", FechaDeInforme = DateTime.Now, Texto = "Texto", Titulo = "Titulo" }
                , new InformesExt() { Categoria = "Cat B", FechaDeInforme = DateTime.Now, Texto = "Texto 1", Titulo = "Titulo I" }
                , new InformesExt() { Categoria = "Cat C", FechaDeInforme = DateTime.Now, Texto = "Texto 2", Titulo = "Titulo J" }
                , new InformesExt() { Categoria = "Cat D", FechaDeInforme = DateTime.Now, Texto = "Texto 3", Titulo = "Titulo K" }
            };
        }

        public IEnumerable<InformesExt> Listado(ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InformesExt> GetAll(ListParams pListParams, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InformesExt> Listado(ref ListParams pListParams, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriasDe_Informes> GetCategorias(ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public void SetDatosDeLogin(DatosDeLogin DatosDeLogin)
        {
            throw new NotImplementedException();
        }

        public int Update(Informes obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Informes pObj, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CategoriasDe_Informes> IInformesServicio.ListadoCategorias(ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public bool PrecargaInicialDeUnaPagina(Operacion pOp, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InformesExt> Listado(Dictionary<string, string> filtros, ref ListParams pListParams, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        InformesExt IBaseServicios<Informes, InformesExt>.Registro(int pId, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }
    }

    public class MockLogErroresServicio : ILogErroresServicio
    {
        public Exception Agregar(LogErrores pObj)
        {
            throw new NotImplementedException();
        }

        public DatosDeLogin ConfirmarCookie(string pCookie)
        {
            throw new NotImplementedException();
        }

        public int Create(LogErrores obj)
        {
            Console.WriteLine("error de prueba:" + obj.MensajeDeError);
            return 0;
        }

        public int Insert(LogErrores pObj, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int pId, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public LogErrores Registro(int pId, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogErroresExt> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogErroresExt> Listado(ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogErroresExt> GetAll(ListParams pListParams, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogErroresExt> Listado(ref ListParams pListParams, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public void SetDatosDeLogin(DatosDeLogin DatosDeLogin)
        {
            throw new NotImplementedException();
        }

        public int Update(LogErrores obj)
        {
            throw new NotImplementedException();
        }

        public int Update(LogErrores pObj, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public bool PrecargaInicialDeUnaPagina(Operacion pOp, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogErroresExt> Listado(Dictionary<string, string> filtros, ref ListParams pListParams, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }

        LogErroresExt IBaseServicios<LogErrores, LogErroresExt>.Registro(int pId, ref ControllerBag pControllerBag)
        {
            throw new NotImplementedException();
        }
    }

    public class MockProfile : Profile
    {

    }

    public class miConexion : IConexion
    {
        public System.Data.SqlClient.SqlConnection GetConexion()
        {
            if (true)
            {
                string PC = "";
                string DataSource = ""; //"pc204\\SQLEXPRESS";
                string Database = "DB_ATI_PERMER";
                string User_ID = "User_Login_DB_ATI_PERMER";
                string Password = "l4PwdD3P3rm3r";

                PC = Environment.MachineName.ToUpper();

                switch (PC)
                {
                    case "PC204":
                        PC = "PC204";
                        break;
                    case "PC080":
                        PC = "PC204";
                        break;
                    case "PC208":
                        PC = "PC204";
                        break;
                    case "PC225":
                        PC = "PC204";
                        break;
                    default:
                        PC = "inválida";
                        break;
                }

                DataSource = PC + "\\SQLEXPRESS";

                return new System.Data.SqlClient.SqlConnection("Data Source=" + DataSource + "; Database=" + Database + ";User ID=" + User_ID + ";Password=" + Password);
            }
            else
            {
                return null; // No se puede utilizar el sitio, está seteado como NO ACTIVO.
            }
        }
    }
    */
}
