namespace FuncionesCore
{
    public class FTextos
    {
        public static string ContraseñaCorta()
        {
            return "La contraseña no contiene el minimo numero de caracteres";
        }

        public static string ContraseñaNoCumpleRequisitos()
        {
            return "La contraseña no cumple los requisitos minimos de seguridad";
        }

        public static string ErrorCrearCarpeta()
        {
            return "No se pudo crear la carpeta";
        }

        public static string ErrorEliminarCarpeta()
        {
            return "No se pudo eliminar la carpeta";
        }

        public static string FechaDesdeError(string pFechaErronea)
        {
            return "La fecha (" + pFechaErronea + ") no es valida.\n";
        } 

        public static string FechaHastaError(string pFechaErronea)
        {
            return "La fecha(" + pFechaErronea + ") no es valida.\n";
        }

        public static string FechaHastaDesdeError()
        {
            return "La fecha \"Desde\" no puede ser mayor a la fecha \"Hasta\". ";
        }

        public static string FechaDesdeImposible()
        {
            return "Corregir la fecha \"desde\", no puede ser posterior a la fecha actual. ";
        }

        public static string FechaHastaImposible()
        {
            return "Corregir la fecha \"hasta\", no puede ser anterior a la fecha actual. ";
        }

        public static string FechaMesErrorDesde()
        {
            return " Corregir el mes \"desde\" para continuar. El numero debe ser entre 1 y 12.\n";
        }

        public static string FechaAnioErrorRangoDesde()
        {
            return "Corregir el año \"desde\" para continuar. Años a partir de 1970 hasta 2050.\n";
        }

        public static string FechaAnioErrorLargoDesde()
        {
            return "Corregir año \"desde\" para continuar. Formato de 4 digitos.";
        }

        public static string FechaMesErrorHasta()
        {
            return " Corregir el mes \"hasta\" para continuar. El numero debe ser entre 1 y 12.\n";
        }

        public static string FechaAnioErrorRangoHasta()
        {
            return "Corregir el año \"hasta\" para continuar. Años a partir de 1970 hasta 2050.\n";
        }

        public static string FechaAnioErrorLargoHasta()
        {
            return "Corregir año \"hasta\" para continuar. Formato de 4 digitos.";
        }

    }
}
