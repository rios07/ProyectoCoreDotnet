using System;
using System.Security.Cryptography;
using System.Text;

namespace FuncionesCore
{
    public class FCodificaciones
    {
        public static string GetSHA1(string pStr)
        {
            SHA1 sha1 = SHA1.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(pStr));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string StringAleatorio(int pCantidadDeCaracteres)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] result = new char[pCantidadDeCaracteres];

            Random random = new Random();
            for (int i = 0; i < pCantidadDeCaracteres; i++)
            {
                result[i] = chars[random.Next(0, 35)];
            }
            string returning = new string(result);
            return returning;

        }

        public static string[] MultiplesStringsAleatorio(int pCantidadDeCaracteres, int pCantidadDeStrings)
        {

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] result = new char[pCantidadDeCaracteres];
            string[] returning = new string[pCantidadDeStrings];
            Random seed = new Random();
            for (int i = 0; i < pCantidadDeStrings; i++)
            {
                Random rnd = new Random(seed.Next(0,10000));
                for (int p = 0; p < pCantidadDeCaracteres; p++)
                {
                    result[p] = chars[rnd.Next(0, 35)];
                }
                returning[i]= new string(result);
            }
            
            
            return returning;

        }
    }
}
