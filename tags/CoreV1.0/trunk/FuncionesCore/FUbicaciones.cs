namespace FuncionesCore
{
    public class FUbicaciones
    {
        #region Archivos

        public static string Downloads(string pDir)
        {
            string ruta = "E:\\InetPub\\WebIntraIatasa_Downloads\\" + pDir.Replace("/", "\\") + "\\";
            return ruta.Replace("//", "/");
        }

        public static string Previews(string pDir)
        {
            string ruta = "~/___Previews/" + pDir.Replace("/", "\\") + "\\";
            return ruta.Replace("//", "/");
        }

        public static string Instructivos()
        {
            return "~/Downloads/Instructivos/Downloads/";
        }

        public static string Folletos()
        {
            return Downloads("Folletos/Downloads");
        }

        public static string FolletosPreviews()
        {
            return Previews("Folletos/Previews");
        }

        public static string Publicaciones()
        {
            return Downloads("Publicaciones/Downloads");
        }

        public static string PublicacionesPreviews()
        {
            return Previews("Publicaciones/Previews");
        }

        public static string NotasDePrensa()
        {
            return Downloads("NotasDePrensa/Downloads");
        }

        public static string NotasDePrensaPreviews()
        {
            return Previews("NotasDePrensa/Previews");
        }

        public static string ArticulosTecnicos()
        {
            return Downloads("ArticulosTecnicos/Downloads");
        }

        public static string ArticulosTenicosPreviews()
        {
            return Previews("ArticulosTecnicos/Previews");
        }
        #endregion
        #region Autenticadores
        public static string Externo()
        {
            return "http://ae-iatasa/_ae/ae.aspx";
        }

        public static string Externo(string pDirDeRespuesta, string pParametrosURLstring)
        {
            return "http://ae-iatasa/_ae/ae.aspx" + "?" + pParametrosURLstring + "=" + pDirDeRespuesta;
        }
        #endregion
        #region Carpeta
        public static string DeAdjuntosDeComunicaciones(string pNombreCarpetaContrato, string pNombreCarpetaComunicacion)
        {
            return DeContextos + pNombreCarpetaContrato + "/" + pNombreCarpetaComunicacion + "/";
        }

        public static string DeCuerpoDeComunicacion(string pNombreCarpetaContrato, string pNombreCarpetaComunicacion)
        {
            return DeAdjuntosDeComunicaciones(pNombreCarpetaContrato, pNombreCarpetaComunicacion) + "_Cuerpo/";
        }

        public static string DeRecepcionDeComunicacion(string pNombreCarpetaContrato, string pNombreCarpetaComunicacion)
        {
            return DeAdjuntosDeComunicaciones(pNombreCarpetaContrato, pNombreCarpetaComunicacion) + "_Recepcion/";
        }
        
        public static string DeLogin = "~/";
        public static string DePaginas = "~/Intranet/";
        public static string DePaginasParaJS = "Intranet/";
        public static string DeLogErrores = DePaginas + "__LogErrores/";
        public static string DeImagenes = DePaginas + "images/";
        public static string DeImagenesAdmin = DePaginas + "images/";
        public static string DeIconos = DePaginas + "images/Iconos/";
        public static string DeIconosExt = DePaginas + "images/Iconos/ext/";
        public static string DeContenidos = DePaginas + "__Contenidos/";
        public static string DeContextos = DeContenidos + "Contratos/";
        public static string DeLogosDeContratos = DeContenidos + "LogosDe_Contratos/";
        public static string DeTemplatesDeContratos = DeContenidos + "TemplatesDe_Contratos/";
        public static string DeAdjuntosDeInformes = DeContenidos + "AdjuntosDeInformes/";
        public static string DeAdjuntosDeContratos = DeContenidos + "AdjuntosDeContratos/";
        public static string DeImagenesDeContratos = "~/___Previews/Contratos/Previews/";
        
        #region Iconos

        public static string IconoDirectorio = DeIconos + "ico_dir.png";
        public static string IconoCalendario = DeIconos + "Calendar.gif";

        public static string IconoExtDefault = DeIconosExt + "default.png";
        public static string IconoExtDoc = DeIconosExt + "doc.png";
        public static string IconoExtPdf = DeIconosExt + "pdf.png";
        public static string IconoExtXls = DeIconosExt + "xls.png";
        #endregion

        #endregion
    }
}
