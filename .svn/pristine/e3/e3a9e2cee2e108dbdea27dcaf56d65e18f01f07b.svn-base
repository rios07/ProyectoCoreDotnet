using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PruebasCore.Funciones
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class FFechasPruebas
    {
        [TestMethod]
        public void TestFechaComoDate()
        {
            //FuncionesCore.FFechas.Fecha_Como_Date
            DateTime _def = new DateTime(01,01,0001,00,00,00);
            //Test para string vacio
            Assert.AreEqual(_def, FuncionesCore.FFechas.FechaComoDate(""));
            //Dia menor
            Assert.AreEqual(_def, FuncionesCore.FFechas.FechaComoDate("00/12/1999"));
            //Dia mayor
            Assert.AreEqual(_def, FuncionesCore.FFechas.FechaComoDate("32/12/1999"));
            //Mes mayor
            Assert.AreEqual(_def, FuncionesCore.FFechas.FechaComoDate("01/13/1999"));
            //Mes menor
            Assert.AreEqual(_def, FuncionesCore.FFechas.FechaComoDate("01/00/1999"));
            //Año mayor
            Assert.AreEqual(_def, FuncionesCore.FFechas.FechaComoDate("01/12/1800"));
            //Año menor
            Assert.AreEqual(_def, FuncionesCore.FFechas.FechaComoDate("01/12/2999"));
            //Fecha ok
            Assert.AreNotEqual(_def, FuncionesCore.FFechas.FechaComoDate("12/12/1999"));
        }

        [TestMethod]
        public void TestArmarFecha()
        {
            DateTime _dateTime = new DateTime(1999, 01,01);
            Assert.AreEqual(_dateTime, FuncionesCore.FFechas.ArmarFecha(01, 01,1999));
        }

    }
}
