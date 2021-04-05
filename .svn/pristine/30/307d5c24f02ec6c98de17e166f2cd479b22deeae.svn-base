using System;

namespace _DatosDelSistema
{
    public class FechasYHoras
    {
        /// <summary>
        ///     Aunque esto parece una tontería, nos permite en ocaciones necesarias,
        ///     manejar la fecha o el tiempo que se impacta en todo el sistema, cambiando esta fcion.
        /// </summary>
        /// <returns>Devuelve Fecha y Tiempo actual como DateTime</returns>
        public static DateTime FechaYTiempoAhora()
        {
            return DateTime.Now;
            // return DateTime.Now.AddHours(-24);
        }

        /// <summary>
        ///     Devuelve el tiempo como string, respecto a FechaYTiempoAhora().
        /// </summary>
        /// <returns>DateTime como String</returns>
        public static string FechaYTiempoAhoraComoTexto()
        {
            var anio = Convert.ToString(FechaYTiempoAhora());
            var mes = Convert.ToString(FechaYTiempoAhora());
            var dia = Convert.ToString(FechaYTiempoAhora());

            return anio + "-" + mes + "-" + dia + "_" + FechaYTiempoAhora().ToShortTimeString().Replace(":", "-") +
                   "hs";
        }

        /// <summary>
        ///     Devuelve un DateTime de expiraciónb de la cookie, respecto a FechaYTiempoAhora().
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime FechaYTiempoExpiraCookie()
        {
            return FechaYTiempoAhora().AddHours(9);
        }

        /// <summary>
        ///     Devuelve un DateTime de hace 10 segundos respecto a FechaYTiempoAhora().
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime FechaYTiempoHace10Segundos()
        {
            return FechaYTiempoAhora().AddSeconds(-10);
        }

        /// <summary>
        ///     Devuelve un DateTime de hace 1 minuto, respecto a FechaYTiempoAhora().
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime FechaYTiempoHace1Minuto()
        {
            return FechaYTiempoAhora().AddMinutes(-1);
        }

        /// <summary>
        ///     Devuelve un DateTime de hace 5 minutos respecto a FechaYTiempoAhora().
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime FechaYTiempoHace5Minutos()
        {
            return FechaYTiempoAhora().AddMinutes(-5);
        }

        /// <summary>
        ///     Devuelve un DateTime máximo desde el ultimo logueo, respecto a FechaYTiempoAhora().
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime FechaYTiempoMaximoDesdeUltimoLoggin()
        {
            return FechaYTiempoAhora().AddHours(-5);
        }
    }
}