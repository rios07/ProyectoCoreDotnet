using System;
using System.Threading;
using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class FCodificacionesPruebas
    {
        [TestMethod]
        public void TestGetSHA1()
        {
            //probar con http://www.sha1-online.com/
            Assert.AreEqual("6139bdc23a06bc12f1fa866f5297385bbda6354e", FCodificaciones.GetSHA1("perro"));
        }

        [TestMethod]
        public void TestStringAleatorio()
        {
            var _aleatorio = "";
            _aleatorio = FCodificaciones.StringAleatorio(8);
            Thread.Sleep(1000);
            Assert.AreEqual(8, _aleatorio.Length);
        }

        [TestMethod]
        public void TestMultiplesStringsAleatorios()
        {
            var _strings = FCodificaciones.MultiplesStringsAleatorio(8, 20);
            foreach (var item in _strings)
            {
                Console.WriteLine(item);
                Assert.AreEqual(8, item.Length);
            }
        }
    }
}