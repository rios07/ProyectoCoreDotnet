using System;
using System.IO;
using System.Text;

namespace FuncionesCore
{
    public class FStrings
    {
        //Falta los "Formato" que utilizan Drawing.color
        /// <summary>
        ///     Recibe (string, int). Devuelve los int caracteres del string.
        /// </summary>
        /// <param name="pTexto"></param>
        /// <param name="pCaracteres"></param>
        /// <returns></returns>
        public static string RecortarA(string pTexto, int pCaracteres)
        {
            if (pTexto.Length > pCaracteres)
                return pTexto.Substring(0, pCaracteres);
            return pTexto;
        }

        /// <summary>
        ///     Recibe un string y reemplaza "^.@áéíóú" por "".
        /// </summary>
        /// <param name="pTexto"></param>
        /// <returns></returns>
        public static string ReemplazarCaracteresNoValidos(string pTexto)
        {
            var reemplazo = new StringBuilder(pTexto);
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

        public static string PaddingDoubleToString(double pNumero, int pTamaño, char pChar = '0', int pDecimal = 2)
        {
            var result = "";
            if (pDecimal == 0)
                result = pNumero.ToString();
            else
                result = (pNumero * Math.Pow(10, pDecimal)).ToString();

            result = result.PadLeft(pTamaño, pChar);
            return result;
        }

        public static string PaddingFloatToString(float pNumero, int pTamaño, char pChar = '0', int pDecimal = 2)
        {
            var result = "";
            if (pDecimal == 0)
                result = pNumero.ToString();
            else
                result = (pNumero * Math.Pow(10, pDecimal - 1)).ToString();

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
                return "";
            return pTexto.Replace(".", ",");
        }

        public static string SafeJavascript(string pTexto)
        {
            pTexto = pTexto.Replace(Environment.NewLine, "\n");
            return pTexto.Replace("'", "\'");
        }

        public static string AgregarSufijo(string pNombreArchivo, string pSufijo)
        {
            var fDir = Path.GetDirectoryName(pNombreArchivo);
            var fName = Path.GetFileNameWithoutExtension(pNombreArchivo);
            var fExt = Path.GetExtension(pNombreArchivo);
            return Path.Combine(fDir, string.Concat(fName, pSufijo, fExt));
        }

        public static string ToIdString(int[] pArray)
        {
            if (pArray == null) return "";
            return string.Join(",", pArray);
        }

        public static string IncrementString(string input)
        {
            string rtn = "A";
            if (!string.IsNullOrWhiteSpace(input))
            {
                bool prependNew = false;
                var sb = new StringBuilder(input.ToUpper());
                for (int i = (sb.Length - 1); i >= 0; i--)
                {
                    if (i == sb.Length - 1)
                    {
                        var nextChar = Convert.ToUInt16(sb[i]) + 1;
                        if (nextChar > 90)
                        {
                            sb[i] = 'A';
                            if ((i - 1) >= 0)
                            {
                                sb[i - 1] = (char)(Convert.ToUInt16(sb[i - 1]) + 1);
                            }
                            else
                            {
                                prependNew = true;
                            }
                        }
                        else
                        {
                            sb[i] = (char)(nextChar);
                            break;
                        }
                    }
                    else
                    {
                        if (Convert.ToUInt16(sb[i]) > 90)
                        {
                            sb[i] = 'A';
                            if ((i - 1) >= 0)
                            {
                                sb[i - 1] = (char)(Convert.ToUInt16(sb[i - 1]) + 1);
                            }
                            else
                            {
                                prependNew = true;
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                }
                rtn = sb.ToString();
                if (prependNew)
                {
                    rtn = "A" + rtn;
                }
            }

            return rtn.ToUpper();
        }
    }
}