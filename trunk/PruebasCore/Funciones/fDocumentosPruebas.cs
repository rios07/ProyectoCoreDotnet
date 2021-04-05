using FuncionesCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasCore.Funciones
{
    [TestClass]
    public class fDocumentosPruebas
    {
        [TestMethod]
        public void TestCargarTipoDeDocumento()
        {
            string _extencsionConPunto = "";
            string _tipoDeContenido = "";
            FDocumentos.CargarTipoDeDocumento("excel",ref _extencsionConPunto,ref _tipoDeContenido);
            Assert.AreEqual(".xls", _extencsionConPunto);
            Assert.AreEqual("application/vnd.xls", _tipoDeContenido);

            FDocumentos.CargarTipoDeDocumento("pdf", ref _extencsionConPunto, ref _tipoDeContenido);
            Assert.AreEqual(".pdf", _extencsionConPunto);
            Assert.AreEqual("application/acrobat", _tipoDeContenido);

            FDocumentos.CargarTipoDeDocumento("word", ref _extencsionConPunto, ref _tipoDeContenido);
            Assert.AreEqual(".doc", _extencsionConPunto);
            Assert.AreEqual("application/vnd.word", _tipoDeContenido);
        }
    }
}
