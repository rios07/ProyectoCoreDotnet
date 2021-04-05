using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace FuncionesCore
{
    public class FValidaciones
    {
        public const string ValidateString = "^[0-9a-zA-Z ñÑ]+$";

        public static bool EsPorcentajeEntero(string pStr)
        {
            int num;
            var result = int.TryParse(pStr, out num);
            return num <= 100 && num >= 0;
        }

        public static bool EsMayorQXYMenorQY(double pValor, double pX, double pY)
        {
            return pValor > pX && pValor < pY;
        }

        public static bool EsMayorIgualQXYMenorIgualQY(double pValor, double pX, double pY)
        {
            return pValor >= pX && pValor <= pY;
        }

        //public static bool Es_Registro_NO_Default(string sCodigo_o_Id)
        //{
        //    bool bRegistro_NO_Default = false;
        //    int num;
        //    bool result = Int32.TryParse(sCodigo_o_Id, out num);
        //    return num > 0;
        //}

        /// <summary>
        ///     Devuelve lo incorrecto en string. Si Todo es valido devuelve un string vacio ("")
        /// </summary>
        /// <param name="pFechaDesde"></param>
        /// <param name="pFechaHasta"></param>
        /// <returns></returns>
        public static string FechaDesdeHastaCorrectas(string pFechaDesde, string pFechaHasta)
        {
            var respuesta = "";
            if (FFechas.FechaComoDate(pFechaDesde) == default(DateTime))
                respuesta += FTextos.FechaDesdeError(pFechaDesde);
            if (FFechas.FechaComoDate(pFechaHasta) == default(DateTime))
                respuesta += FTextos.FechaHastaError(pFechaHasta);
            if (FFechas.FechaComoDate(pFechaDesde) > FFechas.FechaComoDate(pFechaHasta))
                respuesta += FTextos.FechaHastaDesdeError();
            if (FFechas.FechaComoDate(pFechaDesde) > DateTime.Now.Date) respuesta += FTextos.FechaDesdeImposible();
            if (FFechas.FechaComoDate(pFechaHasta) < DateTime.Now.Date) respuesta += FTextos.FechaHastaImposible();
            return respuesta;
        }

        public static bool FechaDesdeHastaCorrectasBool(string pFechaDesde, string pFechaHasta)
        {
            if (FechaDesdeHastaCorrectas(pFechaDesde, pFechaHasta) == "")
                return true;
            return false;
        }

        public static string FechasMesAnioDesdeHastaCorrectas(string pDesdeMes, string pDesdeAnio,
            string pHastaMes, string pHastaAnio)
        {
            var respuesta = "";
            var iDesdeMes = int.Parse(pDesdeMes);
            if (iDesdeMes < 1 || iDesdeMes > 12) respuesta += FTextos.FechaMesErrorDesde();
            if (pDesdeAnio.Length == 4)
            {
                var iDesdeAnio = int.Parse(pDesdeAnio);
                if (iDesdeAnio < 1970)
                {
                    respuesta += FTextos.FechaAnioErrorRangoDesde();
                }
                else
                {
                    if (iDesdeAnio > 2700) respuesta += FTextos.FechaAnioErrorRangoDesde();
                }
            }
            else
            {
                respuesta += FTextos.FechaAnioErrorLargoDesde();
            }

            var iHastaMes = int.Parse(pHastaMes);
            if (iHastaMes < 1 || iHastaMes > 12) respuesta += FTextos.FechaMesErrorHasta();
            if (pHastaAnio.Length == 4)
            {
                var iHastaAnio = int.Parse(pHastaAnio);
                if (iHastaAnio < 1970)
                {
                    respuesta += FTextos.FechaAnioErrorRangoHasta();
                }
                else
                {
                    if (iHastaAnio > 2700) respuesta += FTextos.FechaAnioErrorRangoHasta();
                }
            }
            else
            {
                respuesta += FTextos.FechaAnioErrorLargoHasta();
            }

            return respuesta;
        }

        public class EMail
        {
            public static string Verificar(string pEmailAddress)
            {
                var respuesta = "";
                MailAddress addr;
                try
                {
                    addr = new MailAddress(pEmailAddress);
                }
                catch (Exception)
                {
                    respuesta = pEmailAddress;
                }

                return respuesta;
            }

            public static bool Valido(string pEmailAddress)
            {
                /*Legacy
                  'Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
                    'Es es el usado por el validador automatico:    \w+([-+.']\w +)*@\w + ([-.]\w +)*\.\w + ([-.]\w +)*
                */
                var pattern =
                    "^[_a-zA-Z0-9-]+(\\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9-]+)*\\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$";
                var emailAddressMatch = Regex.Match(pEmailAddress.Trim(), pattern, RegexOptions.IgnoreCase);
                return emailAddressMatch.Success;
            }

            #region Comentado

            /*
                (1)-------Validation Expressions for Strong Password --------
                (?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$	
                Validates a strong password. 
                It must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters.

                (2)-------Validation Expressions for valid URL ---------
                ^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$	

                (3)-------Validation Expressions for valid E-mail -------
                ^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$	

                (4) ------- Validation Expressions for Non- negative integer --------
                ^\d+$
                Validates that the field contains an integer greater than zero.

                (5)-------Validation Expressions for Currency (non- negative)-------
                ^\d+(\.\d\d)?$	
                Validates a positive currency amount. If there is a decimal point, it requires 2 numeric characters after the decimal point. For example, 3.00 is valid but 3.1 is not.

                (6)-------validation Expressions for Currency ------
                ^(-)?\d+(\.\d\d)?$	
                Validates for a positive or negative currency amount. If there is a decimal point, it requires 2 numeric characters after the decimal point.

                (7)-------Validation Expressions for Charactors [a-z][A-Z] only ------
                ^[a-zA-Z'.\s]{1,40}$

                (8)-------Validation Expressions for Number Only ------
                ^\d*([.]\d*)?|[.]\d+$

                        Email validation
                <asp:TextBox ID="txtEmail" runat="Server" Columns="40"/>
                <asp:RegularExpressionValidator ID="revemail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Eg:abcde@abc.ad" validationexpression="^.+\@.+\..+$"  Display="static" SetFocusOnError="true"></asp:RegularExpressionValidator>


                Pincode validation
                <asp:TextBox ID="txtPincode" runat="Server" Columns="40"/>
                <asp:RegularExpressionValidator ID="revPincode" runat="server" ControlToValidate="txtPincode" ErrorMessage="enter correct pincode" validationexpression="^.+\@.+\..+$"  Display="static" SetFocusOnError="true"></asp:RegularExpressionValidator>


                validating password and confirm password
                <asp:TextBox ID="TextBox3" runat="Server" TextMode="Password" Columns="40"/>
                <asp:TextBox ID="textbox2" runat="Server" TextMode="Password" Columns="40"/>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords don't match!" ControlToValidate="TextBox3" 
                        ControlToCompare="textbox2" ></asp:CompareValidator>


                Validating year
                <asp:TextBox ID="txtValidityDate" runat="server"/>
                 <asp:RegularExpressionValidator ID="revvaliditydate" runat="server" ControlToValidate="txtValidityDate" ErrorMessage="Date Format(dd/mm/yyyy)" 
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" Display="static" SetFocusOnError="true"></asp:RegularExpressionValidator> 


                Validation For 999-99-9999 Format
                ValidationExpression="(^\d{3}\-?\d{2}\-?\d{4}$)"     


                Validation For(555) 555-5555 Format
                ValidationExpression="(^((\(?\d{3}\))|(\d{3}))?\s?\d{3}[\-.]?\d{4}$)" 
             
             */
        }

        /*
         Public Class OperacionSQL
                Shared Function Agregar(vSqlPM As CCore.cSQL.ParamManager) As String
                    If vSqlPM.Get_bFlag_Output Then
                        Return ""
                    Else
                        Return "Se produjo un error. Falta incluir el parametro de salida requerido, en el vSqlPM."
                    End If
                End Function

                Shared Function Eliminar(vSqlPM As CCore.cSQL.ParamManager) As String
                    If vSqlPM.Get_bFlag_By Then
                        Return ""
                    Else
                        Return "Se produjo un error. Falta incluir el parametro ""by"" requerido, en el vSqlPM."
                    End If
                End Function

                Shared Function Listado(vSqlPM As CCore.cSQL.ParamManager) As String
                    'If vSqlPM.Get_bFlag_By And vSqlPM.Get_bFlag_ModificarCampo Then
                    Return ""
                    'Else
                    'Return "Se produjo un error. Falta incluir el parametro ""by"" o el parametro ""ModificarCampo"" requerido, en el vSqlPM."
                    'End If
                End Function

                Shared Function Modificar(vSqlPM As CCore.cSQL.ParamManager) As String
                    If vSqlPM.Get_bFlag_By Then
                        Return ""
                    Else
                        Return "Se produjo un error. Falta incluir el parametro ""by"" requerido, en el vSqlPM."
                    End If
                End Function

                Shared Function Modificar_Campo(vSqlPM As CCore.cSQL.ParamManager) As String
                    If vSqlPM.Get_bFlag_By And vSqlPM.Get_bFlag_ModificarCampo Then
                        Return ""
                    Else
                        Return "Se produjo un error. Falta incluir el parametro ""by"" o el parametro ""ModificarCampo"" requerido, en el vSqlPM."
                    End If
                End Function

                Shared Function Registro(vSqlPM As CCore.cSQL.ParamManager) As String
                    'If vSqlPM.Get_bFlag_By And vSqlPM.Get_bFlag_ModificarCampo Then
                    Return ""
                    'Else
                    'Return "Se produjo un error. Falta incluir el parametro ""by"" o el parametro ""ModificarCampo"" requerido, en el vSqlPM."
                    'End If
                End Function
            End Class
         */

        #endregion
    }
}