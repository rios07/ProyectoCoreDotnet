using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class FContraseniasPruebas
    {
        [TestMethod]
        public void TestCumpleMinimosCaracteres()
        {
            Assert.AreEqual("", FContrasenias.CumpleMinimosCaracteres("asdasdasd"));
        }

        [TestMethod]
        public void TestCumpleMinimosRequerimientos()
        {
            //Si
            Assert.AreEqual("R3negados", FContrasenias.CumpleMinimosRequerimientos("R3negados"));
            ////No, por requerimientos
            Assert.AreEqual("La contraseña no cumple los requisitos minimos de seguridad",
                FContrasenias.CumpleMinimosRequerimientos("renegados"));
            //No, por largo.
            Assert.AreEqual("La contraseña no contiene el minimo numero de caracteres",
                FContrasenias.CumpleMinimosRequerimientos("asd"));
        }
    }
}