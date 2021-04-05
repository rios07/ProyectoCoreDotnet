using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PruebasCore.Funciones
{

    [TestClass]
    public class FBoxesPruebas
    {
        [TestMethod]
        public void TestStringShowAlert()
        {
            Assert.AreEqual("alert(\"hola\");\r\n", FuncionesCore.FBoxes.ShowAlert("hola"));
        }

    }
}
