using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class FMatematicasPruebas
    {
        /// <summary>
        /// Utilizo las diferencias, porque la representación de doubles no es igual al valor que devuelve.
        /// </summary>
        [TestMethod]
        public void TestAreaCirculo()
        {
            //TODO: FMatematicas.AreaCirculo(double radio) -> probar
            var _dif = 31.0062766803 - FuncionesCore.FMatematicas.AreaCirculo(3.14159265359);
            Assert.IsTrue(_dif >= -0.001);
            Assert.IsTrue(_dif <= 0.001);

        }

        /// <summary>
        /// Utilizo las diferencias, porque la representación de doubles no es igual al valor que devuelve.
        /// </summary>
        [TestMethod]
        public void TestAreaRectangulo()
        {
            double _valor = 9.083025;
            double _dif = _valor - FuncionesCore.FMatematicas.AreaRectangulo(2.555, 3.555);
            Assert.IsTrue(_dif < 0.001);
            Assert.IsTrue(_dif > -0.001);
        }

        /// <summary>
        /// Utilizo las diferencias, porque la representación de doubles no es igual al valor que devuelve.
        /// </summary>
        [TestMethod]
        public void TestAreaTriangulo()
        {
            double _valor = 4.5415125;
            double _dif = _valor - FuncionesCore.FMatematicas.AreaTriangulo(2.555, 3.555);
            Assert.IsTrue(_dif < 0.001);
            Assert.IsTrue(_dif > -0.001);
        }

        [TestMethod]
        public void TestEnteroMayorQue()
        {
            Assert.IsTrue(FuncionesCore.FMatematicas.EnteroMayorQue(2 , 1));
            Assert.IsFalse(FuncionesCore.FMatematicas.EnteroMayorQue(1, 1));
            Assert.IsFalse(FuncionesCore.FMatematicas.EnteroMayorQue(-1 , 1));
        }

        [TestMethod]
        public void TestEnteroMayorIgualQue()
        {
            Assert.IsTrue(FuncionesCore.FMatematicas.EnteroMayorIgualque(2, 1));
            Assert.IsTrue(FuncionesCore.FMatematicas.EnteroMayorIgualque(1, 1));
            Assert.IsFalse(FuncionesCore.FMatematicas.EnteroMayorIgualque(-1, 1));
        }

    }
}
