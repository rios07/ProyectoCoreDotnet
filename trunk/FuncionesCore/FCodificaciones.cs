using System;
using System.Security.Cryptography;
using System.Text;

namespace FuncionesCore
{
    public class FCodificaciones
    {
        public static string GetSHA1(string pStr)
        {
            var sha1 = SHA1.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            var sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(pStr));
            for (var i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string StringAleatorio(int pCantidadDeCaracteres)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new char[pCantidadDeCaracteres];

            var random = new Random();
            for (var i = 0; i < pCantidadDeCaracteres; i++) result[i] = chars[random.Next(0, 35)];
            var returning = new string(result);
            return returning;
        }

        public static string[] MultiplesStringsAleatorio(int pCantidadDeCaracteres, int pCantidadDeStrings)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new char[pCantidadDeCaracteres];
            var returning = new string[pCantidadDeStrings];
            var seed = new Random();
            for (var i = 0; i < pCantidadDeStrings; i++)
            {
                var rnd = new Random(seed.Next(0, 10000));
                for (var p = 0; p < pCantidadDeCaracteres; p++) result[p] = chars[rnd.Next(0, 35)];
                returning[i] = new string(result);
            }


            return returning;
        }
    }
}