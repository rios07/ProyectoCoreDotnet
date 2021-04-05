using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class FBoxesPruebas
    {
        [TestMethod]
        public void TestStringShowAlert()
        {
            Assert.AreEqual("alert(\"hola\");\r\n", FBoxes.ShowAlert("hola"));
        }
    }
}