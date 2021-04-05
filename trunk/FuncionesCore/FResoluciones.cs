using System.Windows.Forms;

namespace FuncionesCore
{
    public class FResoluciones
    {
        public enum Ancho
        {
            s = 800,
            m = 960,
            l = 1024,
            xl = 1280,
            xxl = 1366
        }

        public static int AnchoPantalla()
        {
            var screenWith = Screen.PrimaryScreen.Bounds.Width;
            var left = 0;

            if (screenWith < 939) left = (int) Ancho.s;
            if (screenWith < 999) left = (int) Ancho.m;
            if (screenWith < 1259) left = (int) Ancho.l;
            if (screenWith < 1339) left = (int) Ancho.xl;
            if (screenWith > 1339) left = (int) Ancho.xxl;

            return left;
        }

        public static string AnchoPantallaEnPX()
        {
            return AnchoPantalla() + "px";
        }
    }
}