using System;

namespace FuncionesCore
{
    public class FFechas
    {
        /// <summary>
        ///     Recibe fecha como string en formato dd/mm/yyyy y devuelve un DateTime
        /// </summary>
        /// <param name="pFecha"></param>
        /// <returns></returns>
        public static DateTime FechaComoDate(string pFecha)
        {
            var check = true;
            if (string.IsNullOrEmpty(pFecha)) return default(DateTime);

            var partes = pFecha.Split('/');
            if (int.Parse(partes[0]) < 1 || int.Parse(partes[0]) > 31) check = false;
            if (int.Parse(partes[1]) < 1 || int.Parse(partes[1]) > 12) check = false;
            if (int.Parse(partes[2]) < 1900 || int.Parse(partes[2]) > 2100) check = false;
            if (check)
                return DateTime.Parse(pFecha);
            return default(DateTime);
        }

        public static string FechaAhoraHTML5()
        {
            var Fechajs = DateTime.Now;
            var Fechajs_dia = Fechajs.Day.ToString();
            if (Fechajs_dia.Length < 2) Fechajs_dia = '0' + Fechajs_dia;
            var Fechajs_mes = Fechajs.Month.ToString(); //Months are zero based
            if (Fechajs_mes.Length < 2) Fechajs_mes = '0' + Fechajs_mes;
            var Fechajs_anio = Fechajs.Year.ToString();
            var retorno = Fechajs_dia + '/' + Fechajs_mes + '/' + Fechajs_anio;
            return retorno;
        }

        /// <summary>
        ///     Recibe (dia/mes/año) Devuelve DateTime (año,mes,dia)
        /// </summary>
        /// <param name="pDia"></param>
        /// <param name="pMes"></param>
        /// <param name="pAnio"></param>
        /// <returns></returns>
        public static DateTime ArmarFecha(int pDia, int pMes, int pAnio)
        {
            var fecha = new DateTime(pAnio, pMes, pDia);
            return fecha;
        }

        public static DateTime FechaAhora()
        {
            return DateTime.Now;
        }
    }
}