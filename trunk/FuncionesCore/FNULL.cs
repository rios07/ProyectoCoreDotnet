using System;

namespace FuncionesCore
{
    public class FNULL
    {
        public static int idEquivalanteDeNULL = -3;

        public static object Sustituye_x_NULL_Si_Es_Id_Equivalente(int pValue)
        {
            if (pValue == idEquivalanteDeNULL)
                return DBNull.Value;
            return pValue;
        }

        public static string SustituyeXIdEquivalenteSiEsNULL(DBNull pValue)
        {
            return idEquivalanteDeNULL.ToString();
        }

        public static int SustituyeXIdEquivalanteSiEsNULL(int pValue)
        {
            return pValue;
        }

        public static string SustituyeXIdEquivalanteSiEsNUELL(string pValue)
        {
            return pValue;
        }

        public static bool? BitABooleanNULL(int pBit)
        {
            if (pBit == -1)
                return null;
            return !(pBit == 0);
        }

        public static int BooleanNullABit(bool? pBoolian)
        {
            if (pBoolian == null) return -1;

            if (pBoolian == true)
                return 1;
            return 0;
        }
    }
}