using AutoMapper;
using ControladoresCore;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoriosCore;
using ServiciosCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

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

                return new SqlConnection("Data Source=" + DataSource + "; Database=" + Database + ";User ID=" + User_ID + ";Password=" + Password);
            }
        }
    }

}
