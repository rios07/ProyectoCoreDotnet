using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FuncionesCore
{
    public class FStrings
    {
        //Falta los "Formato" que utilizan Drawing.color
        /// <summary>
        /// Recibe (string, int). Devuelve los int caracteres del string.
        /// </summary>
        /// <param name="pTexto"></param>
        /// <param name="pCaracteres"></param>
        /// <returns></returns>
        public static string RecortarA(string pTexto, int pCaracteres)
        {
            if (pTexto.Length > pCaracteres)
            {
                return pTexto.Substring(0, pCaracteres);
            }
            else
            {
                return pTexto;
            }
        }
        
        /// <summary>
        /// Recibe un string y reemplaza "^.@áéíóú" por "".
        /// </summary>
        /// <param name="pTexto"></param>
        /// <returns></returns>
        public static string ReemplazarCaracteresNoValidos(string pTexto)
        {
            StringBuilder reemplazo = new StringBuilder(pTexto);
            reemplazo.Replace("@", "");
            reemplazo.Replace("^", "");
            reemplazo.Replace(".", "");
            reemplazo.Replace("á", "");
            reemplazo.Replace("é", "");
            reemplazo.Replace("í", "");
            reemplazo.Replace("ó", "");
            reemplazo.Replace("ú", "");
            return reemplazo.ToString();
        }

        public static string PaddingDoubleToString(double pNumero, int pTamaño, char pChar='0',int pDecimal=2)
        {
            string result = "";
            if (pDecimal == 0)
            {
                result = pNumero.ToString();
            }
            else
            {
                result = (pNumero * (Math.Pow(10, pDecimal ))).ToString();
            }
            
            result = result.PadLeft(pTamaño, pChar);
            return result;
        }

        public static string PaddingFloatToString(float pNumero, int pTamaño, char pChar='0',int pDecimal=2)
        {
            string result = "";
            if (pDecimal == 0)
            {
                result = pNumero.ToString();
            }
            else
            {
                result = (pNumero * (Math.Pow(10, pDecimal - 1))).ToString();
            }

            result = result.PadLeft(pTamaño, pChar);
            return result;
        }

       
        public static string ReemplazarComillas(string pTexto)
        {
            return pTexto.Replace("'", "''");
        }

        public static string ReemplazarComillasJs(string pTexto)
        {
            return pTexto.Replace("'", "\'");
        }

        public static string ReemplazarEnters(string pTexto)
        {
            return pTexto.Replace(Environment.NewLine, "<br>");
        }

        public static string ReemplazarPuntoPorComa(string pTexto)
        {
            if (string.IsNullOrEmpty(pTexto))
            {
                return "";
            }
            else
            {
                return pTexto.Replace(".",",");
            }
        }

        public static string SafeJavascript(string pTexto)
        {
            pTexto = pTexto.Replace(Environment.NewLine, "\n");
            return pTexto.Replace("'", "\'");
        }

        public static string AgregarSufijo(string pNombreArchivo, string pSufijo)
        {
            string fDir = Path.GetDirectoryName(pNombreArchivo);
            string fName = Path.GetFileNameWithoutExtension(pNombreArchivo);
            string fExt = Path.GetExtension(pNombreArchivo);
            return Path.Combine(fDir, String.Concat(fName, pSufijo, fExt));
        }

        public static string ToIdString(int[] pArray)
        {
            if (pArray == null)
            {
                return "";
            }
            return string.Join(",", pArray);
        }
    }
}
