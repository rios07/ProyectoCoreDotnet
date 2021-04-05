using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class FValidacionesPruebas
    {
        
        [TestMethod]
        public void TestValidacionEmailValido()
        {
            Assert.IsTrue(FValidaciones.EMail.Valido("Hyrulewar@gmail.com"));
            Assert.IsFalse(FValidaciones.EMail.Valido("DEFNOTAMAIL"));
        }

        [TestMethod]
        public void TestEsMayorQXYMenorQY()
        {
            Assert.IsTrue(FValidaciones.EsMayorQXYMenorQY(4,2,20));
            Assert.IsFalse(FValidaciones.EsMayorQXYMenorQY(1, 2, 3));
            //si rompe
            Assert.IsTrue(FValidaciones.EsMayorQXYMenorQY(8888888, -3, 99999999.2));
        }

        [TestMethod]
        public void TestfechasMesAnioDesdeHastaCorrectas()
        {
            Assert.AreEqual("", FValidaciones.FechasMesAnioDesdeHastaCorrectas("11", "2018", "12", "2018"));
        }

        [TestMethod]
        public void TestFechaDesdeHastaCorrectasBool()
        {
            Assert.IsTrue(FValidaciones.FechaDesdeHastaCorrectasBool("10/1/2018", "10/12/2018"));
        }

    }
}
