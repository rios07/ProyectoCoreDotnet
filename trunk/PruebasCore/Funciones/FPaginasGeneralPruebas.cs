using System;
using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class FPaginasGeneralPruebas
    {
        [TestMethod]
        public void TestLinksConcatenadosSoloListados()
        {
            Console.WriteLine(FPaginasGeneral.LinksConcatenadosSoloListados("URLLISTADO sinopcional"));
            Console.WriteLine(FPaginasGeneral.LinksConcatenadosSoloListados("URLLISTADO opcional", "ListadoAvanzado"));
        }

        [TestMethod]
        public void TestLinksConcatenadosTodos()
        {
            Console.WriteLine(FPaginasGeneral.LinksConcatenadosTodos("SelectedID", "Urllistado"));
            Console.WriteLine(FPaginasGeneral.LinksConcatenadosTodos("SelectedID", "urlistado", "add", "avanzado"));
        }
    }
}