using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class FStringsPruebas
    {
        [TestMethod]
        public void TestStringRecortar()
        {
            Assert.AreEqual("Fo", FStrings.RecortarA("Foucault", 2));
        }

        [TestMethod]
        public void TestStringReemplazarCaracteresNoValidos()
        {
            Assert.AreEqual("Schopenhauer", FStrings.ReemplazarCaracteresNoValidos("Scho^pen@hauer"));
        }

        [TestMethod]
        public void TestStringReemplazarComillas()
        {
            Assert.AreEqual("''Socrates''", FStrings.ReemplazarComillas("'Socrates'"));
        }


    }
}
