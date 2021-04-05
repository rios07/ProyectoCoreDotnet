using System;
using System.IO;
using System.Web;

namespace FuncionesCore
{
    public class FCarpetas
    {
        public static string CarpetaPadreDelArchivo(string pPath_Archivo)
        {
            DirectoryInfo dir;
            try
            {
                string sPath = HttpContext.Current.Server.MapPath(pPath_Archivo);
                dir = System.IO.Directory.CreateDirectory(Path.GetDirectoryName(sPath));
            }
            catch (Exception)
            {
                dir = null;
            }
            finally {
            }
            return dir.Name;
        }

        public static string CrearCarpeta(string pPath_Carpeta)
        {

            DirectoryInfo dir;
            string sFolderPath;
            string sRespuesta = "";
            try
            {
                sFolderPath = HttpContext.Current.Server.MapPath(pPath_Carpeta);
                //DirectoryInfo dir = System.IO.Directory.CreateDirectory(Path.GetDirectoryName(filepath));       
                dir = System.IO.Directory.CreateDirectory(sFolderPath);
                dir.Create();
                if (!FuncionesCore.FCarpetas.Existe(sFolderPath))
                {
                    sRespuesta =  FTextos.ErrorCrearCarpeta();
                }
            }
            catch (Exception ex)
            {
                sRespuesta = ex.Message.ToString();
            }
            return sRespuesta;
        }

        public static string EliminarCarpeta(string pPath_Carpeta)
        {
            string sRespuesta = "";
            string sFolderPath;
            DirectoryInfo dir;
            try
            {
                sFolderPath = HttpContext.Current.Server.MapPath(pPath_Carpeta);
                dir = System.IO.Directory.CreateDirectory(sFolderPath);
                dir.Delete();
                if (FuncionesCore.FCarpetas.Existe(pPath_Carpeta))
                {
                    sRespuesta = FTextos.ErrorEliminarCarpeta();
                }
            }
            catch (Exception ex)
            {
                sRespuesta = ex.Message.ToString();
            }
            return sRespuesta;
        }

        public static Boolean Existe(string sPath_Carpeta)
        {
            bool existe = false;
            try
            {
                string sFolderPath = HttpContext.Current.Server.MapPath(sPath_Carpeta);
                if (System.IO.Directory.Exists(sFolderPath))
                {
                    existe = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }
    }
}
