using System;

namespace FuncionesCore
{
    public class FValores
    {
        private const string _ERRORMESSAGE = "How to return multiple variables in a single method call!";
        private const int _ERRORWARNINGLEVEL = 3;
        //BUSCAR ASI:
        //Dim errorDetails = GetErrorMessage(555)
        //Dim errorMessage = errorDetails.Item2 'Item2 holds Error message in Tuple
        //Dim errorWarningLevel = errorDetails.Item3 'Item2 holds Error WarningLevel in Tuple
        public Tuple<int, String, int> GetErrorMessage(int pErrorCode)
        {
            /*
            Commented old code for reference
            Return errorMessage
            Return errorWarningLevel
            */
            //Option 1: using TUPLE helper method 
            Tuple<int, String, int> errorDetails = Tuple.Create(pErrorCode, _ERRORMESSAGE, _ERRORWARNINGLEVEL);
            return errorDetails;
            /*
            Option 2: Using TUPLE constructor
            Dim errorDetails As New Tuple(Of Integer, String, Integer)(errorCode, errorMessage, errorWarningLevel)
            */
        }
    }
}
