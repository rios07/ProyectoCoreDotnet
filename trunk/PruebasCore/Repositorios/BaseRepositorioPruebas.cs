using System;
using System.Data.SqlClient;
using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class BaseRepositorioPruebas
    {
        [TestMethod]
        public void TestDelete()
        {
            var myRepo = new MockRepo(new miConexion());
            var bag = new ControllerBag();
            myRepo.Delete(3, ref bag);
            bag.ForEach(x => Console.WriteLine(x.Contenido));
        }
    }

    public class MockRepo : BaseRepositorios<Usuarios, UsuariosExt>
    {
        public MockRepo(IConexion pMiConexion) : base(pMiConexion)
        {
            _datosDeLogin = new DatosDeLogin();
            _datosDeLogin.UsuarioId = 2;
        }
    }

    public class miConexion : IConexion
    {
        public SqlConnection GetConexion()
        {
            if (true)
            {
                var PC = "";
                var DataSource = ""; //"pc204\\SQLEXPRESS";
                var Database = "DB_MVC_P1";
                var User_ID = "User_Login_DB_MVC_P1";
                var Password = "M4hU6k4S71aoU35V";

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

                return new SqlConnection("Data Source=" + DataSource + "; Database=" + Database + ";User ID=" +
                                         User_ID + ";Password=" + Password);
            }

            return null; // No se puede utilizar el sitio, está seteado como NO ACTIVO.
        }
    }
}