using System.Text.RegularExpressions;

namespace FuncionesCore
{
    public class FContrasenias
    {
        /// <summary>
        ///     Recibe un string. Si cumple con el largo devuelve ""
        /// </summary>
        public static string CumpleMinimosCaracteres(string pContrasenia)
        {
            if (pContrasenia.Length < 7)
                return FTextos.ContraseñaCorta();
            return "";
        }

        /// <summary>
        ///     Recibe un string. Si cumple con los requisitos devuelve la misma contraseña
        /// </summary>
        /// <param name="pContrasenia"></param>
        /// <returns></returns>
        public static string CumpleMinimosRequerimientos(string pContrasenia)
        {
            var respuesta = CumpleMinimosCaracteres(pContrasenia);
            if (respuesta == "")
            {
                var numero = new Regex(@"[0-9]+");
                var upper = new Regex(@"[A-Z]+");
                var lower = new Regex(@"[a-z]+");
                if (numero.IsMatch(pContrasenia) && upper.IsMatch(pContrasenia) && lower.IsMatch(pContrasenia))
                    return pContrasenia;
                return FTextos.ContraseñaNoCumpleRequisitos();
            }

            return FTextos.ContraseñaCorta();
        }
    }
}