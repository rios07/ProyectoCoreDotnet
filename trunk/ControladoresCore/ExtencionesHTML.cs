using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControladoresCore.Extenciones
{
    public static class DisableHtmlControlExtension
    {
        public static MvcHtmlString DisableIf(this MvcHtmlString htmlString, Func<bool> expression)
        {
            if (expression.Invoke())
            {
                
                var html = htmlString.ToString();
                int inicio = html.IndexOf("href");
                if (inicio > 0)
                {
                    var replace = html.Substring(inicio+6);
                    int fin = replace.IndexOf("\"");
                    replace = replace.Substring(0, fin);
                    html = html.Replace(replace, "#");
                }
                const string disabled = "\"disabled\"";
                html = html.Insert(html.IndexOf(">",
                  StringComparison.Ordinal), " disabled= " + disabled);
                return new MvcHtmlString(html);
            }
            return htmlString;
        }
    }

    public static class HtmlHelperExtension
    {

        /// <summary>
        /// Para armar paneles de bootstrap con título y cuerpo
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="header">Título del panel</param>
        /// <param name="body">Cuerpo del panel</param>
        /// <returns></returns>
        public static PanelBootstrap BeginPanel(this HtmlHelper pHelper, MvcHtmlString pHeader)
        {
            string prefijo_header = "<div class=\"panel panel-primary\"><div class=\"panel-heading\"><h4 class=\"panel-title\">";
            string sufijo_header = "</h4></div>";
            string prefijo_body = "<div class=\"panel-body\">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new PanelBootstrap(pHelper);
        }

        /// <summary>
        /// Para armar paneles de bootstrap con título y cuerpo
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="header">Título del panel</param>
        /// <param name="body">Cuerpo del panel</param>
        /// <returns></returns>
        public static PanelBootstrap BeginPanel(this HtmlHelper pHelper, string pHeader)
        {
            string prefijo_header = "<div class=\"panel panel-primary\"><div class=\"panel-heading\"><h4 class=\"panel-title\">";
            string sufijo_header = "</h4></div>";
            string prefijo_body = "<div class=\"panel-body\">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new PanelBootstrap(pHelper);
        }

        public static void EndPanel(this HtmlHelper pHelper)
        {
            string sufijo_body = "</div></div>";

            pHelper.ViewContext.Writer.Write(sufijo_body);
        }

    }

    public class PanelBootstrap : IDisposable
    {
        private readonly HtmlHelper _html;

        public PanelBootstrap(HtmlHelper html)
        {
            _html = html;
        }

        public void Dispose()
        {
            _html.EndPanel();
        }
    }
}
