using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class FMatematicasPruebas
    {
        /// <summary>
        ///     Utilizo las diferencias, porque la representación de doubles no es igual al valor que devuelve.
        /// </summary>
        [TestMethod]
        public void TestAreaCirculo()
        {
            //TODO: FMatematicas.AreaCirculo(double radio) -> probar
            var _dif = 31.0062766803 - FMatematicas.AreaCirculo(3.14159265359);
            Assert.IsTrue(_dif >= -0.001);
            Assert.IsTrue(_dif <= 0.001);
        }

        /// <summary>
        ///     Utilizo las diferencias, porque la representación de doubles no es igual al valor que devuelve.
        /// </summary>
        [TestMethod]
        public void TestAreaRectangulo()
        {
            var _valor = 9.083025;
            var _dif = _valor - FMatematicas.AreaRectangulo(2.555, 3.555);
            Assert.IsTrue(_dif < 0.001);
            Assert.IsTrue(_dif > -0.001);
        }

        /// <summary>
        ///     Utilizo las diferencias, porque la representación de doubles no es igual al valor que devuelve.
        /// </summary>
        [TestMethod]
        public void TestAreaTriangulo()
        {
            var _valor = 4.5415125;
            var _dif = _valor - FMatematicas.AreaTriangulo(2.555, 3.555);
            Assert.IsTrue(_dif < 0.001);
            Assert.IsTrue(_dif > -0.001);
        }

        [TestMethod]
        public void TestEnteroMayorQue()
        {
            Assert.IsTrue(FMatematicas.EnteroMayorQue(2, 1));
            Assert.IsFalse(FMatematicas.EnteroMayorQue(1, 1));
            Assert.IsFalse(FMatematicas.EnteroMayorQue(-1, 1));
        }

        [TestMethod]
        public void TestEnteroMayorIgualQue()
        {
            Assert.IsTrue(FMatematicas.EnteroMayorIgualque(2, 1));
            Assert.IsTrue(FMatematicas.EnteroMayorIgualque(1, 1));
            Assert.IsFalse(FMatematicas.EnteroMayorIgualque(-1, 1));
        }
    }
}