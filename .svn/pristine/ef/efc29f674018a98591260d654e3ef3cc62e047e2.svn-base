namespace FuncionesCore
{
    public class FHTML
    {
        /*
          Shared Function AgregarPrefijoADM(url As String) As String

          Si es un link, agrego el prefijo luego del href
                If InStr(url, "<a href=""") Then
                    Return url.Replace("<a href=""", "<a href=""" & Info.iSitioWeb.Adm.Prefijo)
                Else 'si no es un link agrego el prefijo al principio
                    Return Info.iSitioWeb.Adm.Prefijo & url
                End If
            End Function
         */

        public static string Td(string texto, string style = "", bool bold = false)
        {
            if (bold)
            {
                texto = "<b>" + texto + "</b>";
            }
            return "<td style=\"" + style + "\">" + texto + "</td>";
        }
       
        public static string Th(string texto, string style = "", bool bold = false, int iColSpan = 1)
        {
            if (bold)
            {
                texto = "<b>" + texto + "</b>";
            }
            return "<th colspan=\"" + iColSpan + "\" style=" + "\"" + style + "\">" + texto + "</th>";

        }

        public static string LinkAdministrar(string url)
        {
            return "<a href=" + "\"" + url + "\"" + ">Administrar</a>";
        }

        public static string LinkAdd(string url)
        {
            return "<a href=" + "\"" + url + "\"" + ">Agregar</a>";
        }

        public static string LinkGraficos(string url)
        {
            return "<a href=" + "\"" + url + "\"" + ">Gráficos</a>";
        }

        public static string LinkListado(string url)
        {
            return "<a href=" + "\"" + url + "\"" + ">Listado</a>";
        }

        public static string LinkMapa(string url)
        {
            return "<a href=\"" + url + "\">Mapa</a>";
        }

        public static string LinkSelected(string url, string id_o_Codigo)
        {
            return "<a href=\"" + url + "?registro=" + id_o_Codigo + "\">Abrir el registro</a>";
        }
        

        public static string Link(string url, string texto, string paramRegistroValue = "")
        {
            if (paramRegistroValue == "")
            {
                return "<a href=\"" + url + "\">" + texto + "</a>";
            }
            else
            {
                return "<a href=\"" + url + "?registro=" + paramRegistroValue + "\">" + texto + "</a>";
            }           
        }

        public static string LinkcCSS(string url, string texto,string css, string paramRegistroValue = "")
        {
            if (paramRegistroValue == "")
            {
                return "<a class=\"" + css + "\" &  href=\"" + url + "\" >" + texto + "</a>";
            }
            else
            {
                return "<a class=\"" + css + "\" &  href=\"" + url + "?Registro=" + paramRegistroValue + "\" >" + texto + "</a>";
            }
        }

        public static string LinkTBlank(string url,string texto, string paramRegistroValue = "")
        {
            if (paramRegistroValue == "")
            {
                return "<a Target=\"_blank\" href=\"" + url + "\" >" + texto + "</a>";
            }
            else
            {
                return "<a Target=\" _blank\" href=\"" + url + "?Registro=" + paramRegistroValue + "\" >" + texto + "</a>";
            }
        }

        public static string LinkTBlankcCSS(string url, string texto, string css, string paramRegistroValue = "")
        {
            if (paramRegistroValue == "")
            {
                return "<a class=\"" + css + "\" & Target=\" _blank\" href=\"" + url + "\" >" + texto + "</a>";
            }
            else
            {
                return "<a class=\"" + css + "\" & Target=\" _blank\" href=\"" + url + "?Registro=" + paramRegistroValue + "\" >" + texto + "</a>";
            }
        }

        public static string MailTo(string email, string texto, string subjet = "")
        {
            return "<a href=mailto:" + email + "?subject=" + subjet + ">" + texto + "</a>";
        }

        public static string MailTo(string email, string texto, string body, string subjet = "")
        {
            return "<a href=mailto:" + email + "?subject=" + subjet +"&body=" + body + ">" + texto + "</a>";
        }

    }
}
