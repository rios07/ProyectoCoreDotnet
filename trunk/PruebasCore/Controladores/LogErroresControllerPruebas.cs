using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoriosCore;

namespace PruebasCore
{
    [TestClass]
    public class LogErroresControllerPruebas
    {
        //[TestMethod]
        //public void testIndex()
        //{
        //    BaseGlobal.InitAutomapper<MockProfile>();

        //    var controller = new LogErroresController(new LogErroresServicio(
        //                                                new LogErroresRepositorio(
        //                                                    new miConexion()
        //                                                )
        //                                             ));

        //    ViewResult result = (ViewResult) controller.Index();
        //    List<LogErroresVM> listaDeErrores = (List<LogErroresVM>) result.Model;
        //    listaDeErrores.ForEach(x => Console.WriteLine(x.ToString()));
        //    Mapper.Reset();
        //}

        [TestMethod]
        public void testCreate()
        {
            //TODO: FContrasenias.CumpleMinimosRequerimientos(string) -> probar una que cumpla y una que no
        }

        private class miConexion : IConexion
        {
            public SqlConnection GetConexion()
            {
                var PC = "";
                var DataSource = ""; //"pc204\\SQLEXPRESS";
                var Database = "DB_ATI_PERMER";
                var User_ID = "User_Login_DB_ATI_PERMER";
                var Password = "l4PwdD3P3rm3r";

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
        }
    }
}