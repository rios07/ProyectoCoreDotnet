namespace FuncionesCore
{
    public class FDocumentos
    {
        /// <summary>
        /// Recibe (excel/pdf/word)
        /// Si no reconoce el tipo de documento devuelve un string vacio ("")
        /// </summary>
        /// <param name="pTipoDeDocumento"></param>
        /// <param name="pExtensionConPunto"></param>
        /// <param name="pTipoDeContenido"></param>
        public static void CargarTipoDeDocumento(string pTipoDeDocumento, 
                                            ref string pExtensionConPunto, 
                                            ref string pTipoDeContenido)
        {
            pExtensionConPunto = "";
            pTipoDeContenido = "";
            if ("excel" == pTipoDeDocumento)
            {
                pExtensionConPunto = ".xls";
                pTipoDeContenido = "application/vnd.xls";
            }
            if ("pdf" == pTipoDeDocumento)
            {
                pExtensionConPunto = ".pdf";
                pTipoDeContenido = "application/acrobat";
            }
            if ("word" == pTipoDeDocumento)
            {
                pExtensionConPunto = ".doc";
                pTipoDeContenido = "application/vnd.word";
            }

        }

        
    }
    #region
    /*public class eDocs
    {

        public enum Formato
        {
            Excel = 1,
            ExcelX = 2,
            Html = 3,
            Pdf = 4,
            Word = 5,
            WordX = 6,
            
        };
        public enum Extension
        {
            xls = 1,
            xlsx = 2,
            htm = 3,
            Pdf = 4,
            doc = 5,
            docx = 6,
        }
    }*/
    #endregion
}
