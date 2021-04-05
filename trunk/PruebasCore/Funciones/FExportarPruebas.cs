using System.Collections.Generic;
using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class FExportarPruebas
    {
        [TestMethod]
        public void TestExportarExcel()
        {
            var datos = new List<MiTipo>();
            datos.Add(new MiTipo(1, "pepe", "perez", "iatasa", "supervisor"));
            datos.Add(new MiTipo(2, "jose", "perez", "iatasa", "supervisor"));
            datos.Add(new MiTipo(3, "roberto", "perez", "iatasa", "supervisor"));
            datos.Add(new MiTipo(4, "juan", "perez", "iatasa", "supervisor"));
            datos.Add(new MiTipo(5, "eustaquio", "perez", "iatasa", "supervisor"));
            FExportar.ExportarExcel(datos);
        }

        public class MiTipo
        {
            public MiTipo()
            {
            }

            public MiTipo(int pId, string pNombre, string pApellido, string pActor, string pRol)
            {
                Id = pId;
                Nombre = pNombre;
                Apellido = pApellido;
                Actor = pActor;
                Rol = pRol;
            }

            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Actor { get; set; }
            public string Rol { get; set; }
        }
    }
}