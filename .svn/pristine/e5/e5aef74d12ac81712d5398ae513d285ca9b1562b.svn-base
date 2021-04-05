using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuncionesCore;

namespace PruebasCore
{
    [TestClass]
    public class FuncionesPruebas
    {
        [TestMethod]
        public void testGetSHA1()
        {
            //probar con http://www.sha1-online.com/
            Assert.AreEqual("6139bdc23a06bc12f1fa866f5297385bbda6354e", FCodificaciones.GetSHA1("perro"));
        }

        [TestMethod]
        public void testCumpleMinimosRequerimientos()
        {
            //TODO: FContrasenias.CumpleMinimosRequerimientos(string) -> probar una que cumpla y una que no
            string sRespuesta = FuncionesCore.FTextos.ContraseñaCorta();
            Assert.AreEqual(sRespuesta , FuncionesCore.FContrasenias.CumpleMinimosCaracteres(" "));
            Assert.AreEqual(sRespuesta, FuncionesCore.FContrasenias.CumpleMinimosCaracteres("123456"));
            Assert.AreEqual("Pr1eb@s2", FuncionesCore.FContrasenias.CumpleMinimosRequerimientos("Pr1eb@s2"));

        }

        [TestMethod]
        public void testAreaCirculo()
        {
            //TODO: FMatematicas.AreaCirculo(double radio) -> probar
            var dif = 31.0062766803 - FuncionesCore.FMatematicas.AreaCirculo(3.14159265359);
            Console.WriteLine("diff: " + dif);
            Assert.IsTrue(dif >= -0.001);// & dif <= 0.001);
            Assert.IsTrue(dif <= 0.001);
           
        }

    }
}
