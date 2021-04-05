using System;
using System.Web;
using System.Web.Mvc;

namespace ControladoresCore.Extensiones
{
    public static class DisableHtmlControlExtension
    {
        public static MvcHtmlString DisableIf(this MvcHtmlString htmlString, Func<bool> expression)
        {
            if (expression.Invoke())
            {
                var html = htmlString.ToString();
                var inicio = html.IndexOf("href");
                if (inicio > 0)
                {
                    var replace = html.Substring(inicio + 6);
                    var fin = replace.IndexOf("\"");
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
        ///     Para armar paneles de bootstrap con título y cuerpo
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="header">Título del panel</param>
        /// <param name="body">Cuerpo del panel</param>
        /// <returns></returns>
        public static PanelBootstrap BeginPanel(this HtmlHelper pHelper, MvcHtmlString pHeader)
        {
            var prefijo_header =
                "<div class=\"panel panel-primary\"><div class=\"panel-heading\"><h4 class=\"panel-title\">";
            var sufijo_header = "</h4></div>";
            var prefijo_body = "<div class=\"panel-body fade-in \">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new PanelBootstrap(pHelper);
        }

        /// <summary>
        ///     Para armar paneles de bootstrap con título y cuerpo
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="header">Título del panel</param>
        /// <param name="body">Cuerpo del panel</param>
        /// <returns></returns>
        public static PanelBootstrap BeginPanel(this HtmlHelper pHelper, string pHeader)
        {
            var prefijo_header =
                "<div class=\"panel panel-primary\"><div class=\"panel-heading\"><h4 class=\"panel-title\">";
            var sufijo_header = "</h4></div>";
            var prefijo_body = "<div class=\"panel-body fade-in \">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new PanelBootstrap(pHelper);
        }

        public static PanelBootstrap BeginPanel(this HtmlHelper pHelper, string pHeader, string pAtributosHTML)
        {
            var prefijo_header = "<div class=\"panel panel-primary \" " + pAtributosHTML +
                                 " ><div class=\"panel-heading\"><h4 class=\"panel-title\">";
            var sufijo_header = "</h4></div>";
            var prefijo_body = "<div class=\"panel-body fade-in \">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new PanelBootstrap(pHelper);
        }

        public static PanelBootstrap BeginPanelFiltro(this HtmlHelper pHelper, string pHeader)
        {
            var prefijo_header =
                "<div class=\"panel panel-primary\"><div class=\"panel-heading\"><h4 class=\"panel-title\">";
            var sufijo_header = "</h4></div>";
            var prefijo_body = "<div class=\"panel-body fade-in p0\">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new PanelBootstrap(pHelper);
        }

        public static PanelBootstrap BeginPanelFiltro(this HtmlHelper pHelper, MvcHtmlString pHeader)
        {
            var prefijo_header =
                "<div class=\"panel panel-primary\"><div class=\"panel-heading\"><h4 class=\"panel-title\">";
            var sufijo_header = "</h4></div>";
            var prefijo_body = "<div class=\"panel-body fade-in p0\">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new PanelBootstrap(pHelper);
        }

        public static PanelBootstrap BeginPanelFiltro(this HtmlHelper pHelper, string pHeader, string pAtributosHTML)
        {
            var prefijo_header = "<div class=\"panel panel-primary \" " + pAtributosHTML +
                                 " ><div class=\"panel-heading\"><h4 class=\"panel-title\">";
            var sufijo_header = "</h4></div>";
            var prefijo_body = "<div class=\"panel-body fade-in p0\">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new PanelBootstrap(pHelper);
        }

        public static void EndPanel(this HtmlHelper pHelper)
        {
            var sufijo_body = "</div></div>";

            pHelper.ViewContext.Writer.Write(sufijo_body);
        }

        /// <summary>
        ///     Para armar Cardes de bootstrap con título y cuerpo
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="header">Título del Card</param>
        /// <param name="body">Cuerpo del Card</param>
        /// <returns></returns>
        public static CardBootstrap BeginCard(this HtmlHelper pHelper, MvcHtmlString pHeader)
        {
            var prefijo_header = "<div class=\"card m-b-20\"><div class=\"card-header bg-primary text-white\">";
            var sufijo_header = "</div>";
            var prefijo_body = "<div class=\"card-body card-block fade-in\">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new CardBootstrap(pHelper);
        }

        /// <summary>
        ///     Para armar Cardes de bootstrap con título y cuerpo
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="header">Título del Card</param>
        /// <param name="body">Cuerpo del Card</param>
        /// <returns></returns>
        public static CardBootstrap BeginCard(this HtmlHelper pHelper, string pHeader, bool bCollapse = false)
        {
            var prefijo_header = bCollapse
                ? "<div class=\"card m-b-20\"><div class=\"card-header bg-primary text-white\"><h5 class=\"mb-0 mt-0 font-16\"><a data-toggle=\"collapse\" href=\"#collapse" +
                  pHeader.Replace(" ", "_") +
                  "\" style=\"display:inline !important;color:white\" aria-expanded=\"true\" aria-controls=\"collapse" +
                  pHeader.Replace(" ", "_") + "\" id=\"heading" + pHeader.Replace(" ", "_") + "\" class=\"d-block\">"
                : "<div class=\"card m-b-20\"><div class=\"card-header bg-primary text-white\">";
            var sufijo_header = bCollapse ? "<i class=\"fa fa-chevron-down pull-right\"></i></a></h5></div>" : "</div>";
            var prefijo_body = bCollapse
                ? "<div id=\"collapse" + pHeader.Replace(" ", "_") +
                  "\" class=\"card-body card-block fade-in collapse\" aria-labelledby=\"heading" +
                  pHeader.Replace(" ", "_") + "\">"
                : "<div class=\"card-body card-block fade-in\">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new CardBootstrap(pHelper);
        }

        public static CardBootstrap BeginCard(this HtmlHelper pHelper, string pHeader, string pAtributosHTML)
        {
            var prefijo_header = "<div class=\"card m-b-20\" " + pAtributosHTML +
                                 " ><div class=\"card-header bg-primary text-white\">";
            var sufijo_header = "</div>";
            var prefijo_body = "<div class=\"card-body card-block fade-in\">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new CardBootstrap(pHelper);
        }

        public static CardBootstrap BeginCard(this HtmlHelper pHelper, string pHeader, string pAtributosHTML,
            string pClases)
        {
            var prefijo_header = "<div class=\"card m-b-20 " + pClases + "\" " + pAtributosHTML +
                                 " ><div class=\"card-header bg-primary text-white  \">";
            var sufijo_header = "</div>";
            var prefijo_body = "<div class=\"card-body card-block fade-in\">";

            pHelper.ViewContext.Writer.Write(prefijo_header + pHeader + sufijo_header + prefijo_body);

            return new CardBootstrap(pHelper);
        }

        public static void EndCard(this HtmlHelper pHelper)
        {
            var sufijo_body = "</div></div>";

            pHelper.ViewContext.Writer.Write(sufijo_body);
        }


        public class PanelBootstrap : IDisposable
        {
            private readonly HtmlHelper _html;

            public PanelBootstrap(HtmlHelper pHtml)
            {
                _html = pHtml;
            }

            public void Dispose()
            {
                _html.EndPanel();
            }
        }

        public class CardBootstrap : IDisposable
        {
            private readonly HtmlHelper _html;

            public CardBootstrap(HtmlHelper pHtml)
            {
                _html = pHtml;
            }

            public void Dispose()
            {
                _html.EndCard();
            }
        }

        #region Boton

        public static HtmlString Boton(string pAccion, bool pPermiso, string pSeccion = "")
        {
            HtmlString Retorno = null;

            if (pAccion == "Update")
            {
                if (pPermiso)
                    Retorno = new HtmlString(
                        "<input type = \"submit\" id=\"BotonDefault\"  value = \"Guardar\" class=\"btn btn-primary\" />");
                else
                    Retorno = new HtmlString(
                        "<input type = \"button\" id=\"BotonDefault\" value = \"Guardar\" class=\"btn btn-primary\"  onclick=\"Permiso();\" />");
            }

            if (pAccion == "Insert")
            {
                if (pPermiso)
                    Retorno = new HtmlString(
                        "<input type = \"submit\"  value = \"Crear\" class=\"btn btn-primary\" />");
                else
                    Retorno = new HtmlString(
                        "<input type = \"button\" value = \"Crear\" class=\"btn btn-primary\"  onclick=\"Permiso();\" />");
            }

            if (pAccion == "Listado")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<th field=\"Id\"style=\"width: 5 %;\" mask=\"<a href=\'" + pSeccion +
                                                 "/Registro/{VAL}\'>Abrir</href>\">Abrir</th>");
                    else
                        Retorno = new HtmlString(
                            "<th field=\"Id\"style=\"width: 5 %;\" mask=\"<a href=\'Registro/{VAL}\'>Abrir</href>\">Abrir</th>");
                }
                else
                {
                    Retorno = new HtmlString("<th field=\"Id\"style=\"width: 5 %;\" mask=\"<a href='#'>Abrir</href>\">Abrir</th>");
                }
            }

            return Retorno;
        }

        public static HtmlString Boton(string pAccion, bool pPermiso, string HtmlString, string pSeccion = "")
        {
            HtmlString Retorno = null;

            if (pAccion == "Update")
            {
                if (pPermiso)
                    Retorno = new HtmlString(
                        "<input type = \"submit\" id=\"BotonDefault\" value = \"Guardar\" class=\"btn btn-primary\" " +
                        HtmlString + "  />");
                else
                    Retorno = new HtmlString(
                        "<input type = \"button\" id=\"BotonDefault\" value = \"Guardar\" class=\"btn btn-primary\"  " +
                        HtmlString + " onclick=\"Permiso();\" />");
            }

            if (pAccion == "Insert")
            {
                if (pPermiso)
                    Retorno = new HtmlString("<input type = \"submit\" value = \"Crear\" class=\"btn btn-primary\" " +
                                             HtmlString + "  />");
                else
                    Retorno = new HtmlString("<input type = \"button\" value = \"Crear\" class=\"btn btn-primary\" " +
                                             HtmlString + "  onclick=\"Permiso();\" />");
            }

            if (pAccion == "Listado")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<th field=\"Id\" " + HtmlString + " mask=\"<a href=\'/" + pSeccion +
                                                 "/Registro/{VAL}\'>Abrir</href>\">Abrir</th>");
                    else
                        Retorno = new HtmlString("<th field=\"Id\" " + HtmlString +
                                                 " mask=\"<a href=\'Registro/{VAL}\'>Abrir</href>\">Abrir</th>");
                }
                else
                {
                    Retorno = new HtmlString("<th field=\"Id\" " + HtmlString +
                                             " mask=\"<a href='#'>Abrir</href>\">Abrir</th>");
                }
            }

            return Retorno;
        }

        public static HtmlString Boton(string pController, string pAction, int pid, bool pPermiso, string pSeccion = "")
        {
            var Retorno = new HtmlString("ERROR");
            if (pAction == "Delete")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<a class=\"btn btn-danger\" value=\"false\" href=\"/" + pSeccion +
                                                 "/" + pController + "/" + pAction + "/" + pid +
                                                 "\" onclick=\"return ConfirmarEliminar($(this));\">Eliminar</a>");
                    else
                        Retorno = new HtmlString("<a class=\"btn btn-danger\" value=\"false\" href=\"/" + pController +
                                                 "/" + pAction + "/" + pid +
                                                 "\" onclick=\"return ConfirmarEliminar($(this));\">Eliminar</a>");
                }
                else
                {
                    Retorno = new HtmlString(
                        "<a class=\"btn btn-danger\" href=\"#\" onclick=\"Permiso();\" >Eliminar</a>");
                }
            }

            if (pAction == "Update")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<a class=\"btn btn-primary\" id=\"BotonDefault\"  href=\"/" +
                                                 pSeccion + "/" + pController + "/" + pAction + "/" + pid +
                                                 "\">Editar</a>");
                    else
                        Retorno = new HtmlString("<a class=\"btn btn-primary\" id=\"BotonDefault\"  href=\"/" +
                                                 pController + "/" + pAction + "/" + pid + "\">Editar</a>");
                }
                else
                {
                    Retorno = new HtmlString(
                        "<a class=\"btn btn-primary\" id=\"BotonDefault\" href=\"#\" onclick=\"Permiso();\" >Editar</a>");
                }
            }

            if (pAction == "UpdateAdjunto")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<a class=\"btn btn-primary\"  id=\"BotonDefault\" href=\"/" +
                                                 pSeccion + "/" + pController + "/" + pAction + "/" + pid +
                                                 "\">Editar</a>");
                    else
                        Retorno = new HtmlString("<a class=\"btn btn-primary\"  id=\"BotonDefault\" href=\"/" +
                                                 pController + "/" + pAction + "/" + pid + "\">Editar</a>");
                }
                else
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString(
                            "<a class=\"btn btn-primary\" href=\"#\" onclick=\"Permiso();\" >Borrar</a>");
                    else
                        Retorno = new HtmlString(
                            "<a class=\"btn btn-primary\" href=\"#\" onclick=\"Permiso();\" >Borrar</a>");
                }
            }

            if (pAction == "Listado")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<th field=\"Id\" mask=\"<a href=\'/" + pSeccion + "/" + pController +
                                                 "/Registro/{VAL}\'>Abrir</href>\">Abrir</th>");
                    else
                        Retorno = new HtmlString("<th field=\"Id\" mask=\"<a href=\'/" + pController +
                                                 "/Registro/{VAL}\'>Abrir</href>\">Abrir</th>");
                }
                else
                {
                    Retorno = new HtmlString("<th field=\"Id\" mask=\"<a href='#'>Abrir</href>\">Abrir</th>");
                }
            }

            return Retorno;
        }

        public static HtmlString Boton(string pController, string pAction, int pid, bool pPermiso,
            bool pPermisoOperarSecundario, string pSeccion = "")
        {
            var Retorno = new HtmlString("ERROR");
            if (pAction == "Delete")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<a class=\"btn btn-danger\" value=\"false\" href=\"/" + pSeccion +
                                                 "/" + pController + "/" + pAction + "/" + pid +
                                                 "\" onclick=\"return ConfirmarEliminar($(this));\">Eliminar</a>");
                    else
                        Retorno = new HtmlString("<a class=\"btn btn-danger\" value=\"false\" href=\"/" + pController +
                                                 "/" + pAction + "/" + pid +
                                                 "\" onclick=\"return ConfirmarEliminar($(this));\">Eliminar</a>");
                }
                else
                {
                    Retorno = new HtmlString(
                        "<a class=\"btn btn-danger\" href=\"#\" onclick=\"Permiso();\" >Eliminar</a>");
                }
            }

            if (pAction == "Update")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<a class=\"btn btn-primary\" id=\"BotonDefault\"  href=\"/" +
                                                 pSeccion + "/" + pController + "/" + pAction + "/" + pid +
                                                 "\">Editar</a>");
                    else
                        Retorno = new HtmlString("<a class=\"btn btn-primary\" id=\"BotonDefault\"  href=\"/" +
                                                 pController + "/" + pAction + "/" + pid + "\">Editar</a>");
                }
                else
                {
                    Retorno = new HtmlString(
                        "<a class=\"btn btn-primary\" id=\"BotonDefault\" href=\"#\" onclick=\"Permiso();\" >Editar</a>");
                }
            }

            if (pAction == "UpdateAdjunto")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<a class=\"btn btn-primary\"  id=\"BotonDefault\" href=\"/" +
                                                 pSeccion + "/" + pController + "/" + pAction + "/" + pid +
                                                 "\">Editar</a>");
                    else
                        Retorno = new HtmlString("<a class=\"btn btn-primary\"  id=\"BotonDefault\" href=\"/" +
                                                 pController + "/" + pAction + "/" + pid + "\">Editar</a>");
                }
                else
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString(
                            "<a class=\"btn btn-primary\" href=\"#\" onclick=\"Permiso();\" >Borrar</a>");
                    else
                        Retorno = new HtmlString(
                            "<a class=\"btn btn-primary\" href=\"#\" onclick=\"Permiso();\" >Borrar</a>");
                }
            }

            if (pAction == "Listado")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<th field=\"Id\" mask=\"<a href=\'/" + pSeccion + "/" + pController +
                                                 "/Registro/{VAL}\'>Abrir</href>\">Abrir</th>");
                    else
                        Retorno = new HtmlString("<th field=\"Id\" mask=\"<a href=\'/" + pController +
                                                 "/Registro/{VAL}\'>Abrir</href>\">Abrir</th>");
                }
                else
                {
                    Retorno = new HtmlString("<th field=\"Id\" mask=\"<a href='#'>Abrir</href>\">Abrir</th>");
                }
            }

            return Retorno;
        }

        public static HtmlString Boton(string pController, string pAction, int pid, bool pPermisoOperar,
            bool pPermisoOperarSecundario, bool pActivo = true, string pSeccion = "")
        {
            var Retorno = new HtmlString("ERROR");
            if (pAction == "Update")
            {
                if (!pActivo)
                {
                    if (pPermisoOperar)
                    {
                        if (pSeccion != "")
                            Retorno = new HtmlString("<a class=\"btn btn-primary\" value=\"false\" href=\"/" +
                                                     pSeccion + "/" + pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ValidarEditar($(this),'Editar');\">Editar</a>");
                        else
                            Retorno = new HtmlString("<a class=\"btn btn-primary\" value=\"false\" href=\"/" +
                                                     pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ValidarEditar($(this),'Editar');\">Editar</a>");
                    }
                    else
                    {
                        Retorno = new HtmlString(
                            "<a class=\"btn btn-primary\" id=\"BotonDefault\" href=\"#\" onclick=\"Permiso();\" >Editar</a>");
                    }
                }
                else
                {
                    if (pPermisoOperar)
                    {
                        if (pSeccion != "")
                            Retorno = new HtmlString("<a class=\"btn btn-primary\" value=\"false\" href=\"/" +
                                                     pSeccion +
                                                     "/" + pController + "/" + pAction + "/" + pid + "\">Editar</a>");
                        else
                            Retorno = new HtmlString("<a class=\"btn btn-primary\" value=\"false\" href=\"/" +
                                                     pController + "/" + pAction + "/" + pid + "\" >Editar</a>");
                    }
                    else
                    {
                        Retorno = new HtmlString(
                            "<a class=\"btn btn-primary\" id=\"BotonDefault\" href=\"#\" onclick=\"Permiso();\" >Editar</a>");
                    }
                }
            }

            if (pAction == "Delete")
            {
                if (pActivo)
                {
                    if (pPermisoOperar)
                    {
                        if (pSeccion != "")
                            Retorno = new HtmlString("<a class=\"btn btn-danger\" value=\"false\" href=\"/" + pSeccion +
                                                     "/" + pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ConfirmarEliminar($(this),'Anular');\">Anular</a>");
                        else
                            Retorno = new HtmlString("<a class=\"btn btn-danger\" value=\"false\" href=\"/" +
                                                     pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ConfirmarEliminar($(this),'Anular');\">Anular</a>");
                    }
                    else
                    {
                        Retorno = new HtmlString(
                            "<a class=\"btn btn-danger\" href=\"#\" onclick=\"Permiso();\" >Eliminar</a>");
                    }
                }
                else
                {
                    if (pPermisoOperarSecundario)
                    {
                        if (pSeccion != "")
                            Retorno = new HtmlString("<a class=\"btn btn-danger\" value=\"false\" href=\"/" + pSeccion +
                                                     "/" + pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ConfirmarEliminar($(this),'activar');\">Activar</a>");
                        else
                            Retorno = new HtmlString("<a class=\"btn btn-danger\" value=\"false\" href=\"/" +
                                                     pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ConfirmarEliminar($(this),'activar');\">Activar</a>");
                    }
                    else
                    {
                        Retorno = new HtmlString(
                            "<a class=\"btn btn-danger\" href=\"#\" onclick=\"Permiso();\" >Activar</a>");
                    }
                }
            }

            return Retorno;
        }
        public static HtmlString BotonDeAcciones(string pController, string pAction, int pid, bool pPermisoOperar,
            bool pPermisoOperarSecundario, bool pActivo = true, string pSeccion = "")
        {
            var Retorno = new HtmlString("ERROR");
            if (pAction == "Update")
            {
                if (!pActivo)
                {
                    if (pPermisoOperar)
                    {
                        if (pSeccion != "")
                            Retorno = new HtmlString("<a class=\"dropdown-item btn-primary\" value=\"false\" href=\"/" +
                                                     pSeccion + "/" + pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ValidarEditar($(this),'Editar');\">Editar</a>");
                        else
                            Retorno = new HtmlString("<a class=\"dropdown-item btn-primary\" value=\"false\" href=\"/" +
                                                     pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ValidarEditar($(this),'Editar');\">Editar</a>");
                    }
                    else
                    {
                        Retorno = new HtmlString(
                            "<a class=\"dropdown-item btn-primary\" id=\"BotonDefault\" href=\"#\" onclick=\"Permiso();\" >Editar</a>");
                    }
                }
                else
                {
                    if (pPermisoOperar)
                    {
                        if (pSeccion != "")
                            Retorno = new HtmlString("<a class=\"dropdown-item btn-primary\" value=\"false\" href=\"/" +
                                                     pSeccion +
                                                     "/" + pController + "/" + pAction + "/" + pid + "\">Editar</a>");
                        else
                            Retorno = new HtmlString("<a class=\"dropdown-item btn-primary\" value=\"false\" href=\"/" +
                                                     pController + "/" + pAction + "/" + pid + "\" >Editar</a>");
                    }
                    else
                    {
                        Retorno = new HtmlString(
                            "<a class=\"dropdown-item btn-primary\" id=\"BotonDefault\" href=\"#\" onclick=\"Permiso();\" >Editar</a>");
                    }
                }
            }

            if (pAction == "Delete")
            {
                if (pActivo)
                {
                    if (pPermisoOperar)
                    {
                        if (pSeccion != "")
                            Retorno = new HtmlString("<a class=\"dropdown-item btn-danger\" value=\"false\" href=\"/" + pSeccion +
                                                     "/" + pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ConfirmarEliminar($(this),'Anular');\">Anular</a>");
                        else
                            Retorno = new HtmlString("<a class=\"dropdown-item btn-danger\" value=\"false\" href=\"/" +
                                                     pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ConfirmarEliminar($(this),'Anular');\">Anular</a>");
                    }
                    else
                    {
                        Retorno = new HtmlString(
                            "<a class=\"dropdown-item btn-danger\" href=\"#\" onclick=\"Permiso();\" >Eliminar</a>");
                    }
                }
                else
                {
                    if (pPermisoOperarSecundario)
                    {
                        if (pSeccion != "")
                            Retorno = new HtmlString("<a class=\"dropdown-item btn-danger\" value=\"false\" href=\"/" + pSeccion +
                                                     "/" + pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ConfirmarEliminar($(this),'activar');\">Activar</a>");
                        else
                            Retorno = new HtmlString("<a class=\"dropdown-item btn-danger\" value=\"false\" href=\"/" +
                                                     pController + "/" + pAction + "/" + pid +
                                                     "\" onclick=\"return ConfirmarEliminar($(this),'activar');\">Activar</a>");
                    }
                    else
                    {
                        Retorno = new HtmlString(
                            "<a class=\"dropdown-item btn-danger\" href=\"#\" onclick=\"Permiso();\" >Activar</a>");
                    }
                }
            }

            return Retorno;
        }
        public static HtmlString BotonDeAcciones(string pController, string pAction, int pid, bool pPermiso,
           bool pPermisoOperarSecundario, string pSeccion = "")
        {
            var Retorno = new HtmlString("ERROR");
            if (pAction == "Delete")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<a class=\"dropdown-item btn-danger\" value=\"false\" href=\"/" + pSeccion +
                                                 "/" + pController + "/" + pAction + "/" + pid +
                                                 "\" onclick=\"return ConfirmarEliminar($(this));\">Eliminar</a>");
                    else
                        Retorno = new HtmlString("<a class=\"dropdown-item btn-danger\" value=\"false\" href=\"/" + pController +
                                                 "/" + pAction + "/" + pid +
                                                 "\" onclick=\"return ConfirmarEliminar($(this));\">Eliminar</a>");
                }
                else
                {
                    Retorno = new HtmlString(
                        "<a class=\"btn btn-danger\" href=\"#\" onclick=\"Permiso();\" >Eliminar</a>");
                }
            }

            if (pAction == "Update")
            {
                if (pPermiso)
                {
                    if (pSeccion != "")
                        Retorno = new HtmlString("<a class=\"dropdown-item btn-primary\" id=\"BotonDefault\"  href=\"/" +
                                                 pSeccion + "/" + pController + "/" + pAction + "/" + pid +
                                                 "\">Editar</a>");
                    else
                        Retorno = new HtmlString("<a class=\"dropdown-item btn-primary\" id=\"BotonDefault\"  href=\"/" +
                                                 pController + "/" + pAction + "/" + pid + "\">Editar</a>");
                }
                else
                {
                    Retorno = new HtmlString(
                        "<a class=\"dropdown-item btn-primary\" id=\"BotonDefault\" href=\"#\" onclick=\"Permiso();\" >Editar</a>");
                }
            }

 
            return Retorno;
        }

        public static HtmlString Boton(string pController, string pAction, string pSeccion = "")
        {
            var Retorno = new HtmlString("ERROR");
            if (pAction == "Listado")
            {
                if (pSeccion != "")
                    Retorno = new HtmlString("<a class=\"btn btn-primary removeOnIframe\" href=\"/" + pSeccion + "/" +
                                             pController + "/" + pAction + "\">Volver al listado</a>");
                else
                    Retorno = new HtmlString("<a class=\"btn btn-primary removeOnIframe\" href=\"/" + pController +
                                             "/" + pAction + "\">Volver al listado</a>");
            }

            return Retorno;
        }

        public static HtmlString ImgAjaxTable()
        {
            return new HtmlString(
                "<th field=\"Id\" mask=\"<a href='#'><img src=\"/Intranet/__Contenidos/Contextos/CarpetaDeSist/Informes/Informes_15413214_3_ObraDummie4_th.jpg\"></href>\">Abrir</th>");
        }

        /// <summary>
        ///     Genera un desplegable con "--" , "Si","No' con su campo para filtro.
        /// </summary>
        /// <param name="pNombreAMostrar"></param>
        /// <param name="pNombreFiltro"></param>
        /// <returns></returns>
        public static HtmlString FiltroCheckbox(string pNombreAMostrar, string pNombreFiltro)
        {
            return new HtmlString(
                "<select style=\"width:70px;\" class=\"form-control\" data-val=\"true\" filtro=\"" + pNombreFiltro +
                "\" id=\"" + pNombreFiltro + "\" name=\"" + pNombreFiltro + "\">" +
                "<option value=\"null\">--</option>" +
                "<option value=\"1\">Si</option>" +
                "<option value=\"0\">No</option>" +
                "</select>");
        }

        public static HtmlString FiltroCheckboxNoNull(string pNombreAMostrar, string pNombreFiltro,
            bool pDefault = true)
        {
            if (pDefault)
                return new HtmlString("<div class=\"col-lg-3\">" +
                                      pNombreAMostrar +
                                      "<select style=\"width:70px;\" class=\"form-control\" data-val=\"true\" filtro=\"" +
                                      pNombreFiltro + "\" id=\"" + pNombreFiltro + "\" name=\"" + pNombreFiltro +
                                      "\">" +
                                      "<option value=\"1\">Si</option>" +
                                      "<option value=\"0\">No</option>" +
                                      "</select>" +
                                      "</div>");
            return new HtmlString("<div class=\"col-lg-3\">" +
                                  pNombreAMostrar +
                                  "<select style=\"width:70px;\" class=\"form-control\" data-val=\"true\" filtro=\"" +
                                  pNombreFiltro + "\" id=\"" + pNombreFiltro + "\" name=\"" + pNombreFiltro + "\">" +
                                  "<option value=\"0\">No</option>" +
                                  "<option value=\"1\">Si</option>" +
                                  "</select>" +
                                  "</div>");
        }

        public static HtmlString SelectedValuesDDL(string pDdlId, string pIdStrings)
        {
            if (pIdStrings != null)
            {
                var ids = pIdStrings.Split(',');
                var vals = "[";
                foreach (var id in ids) vals = vals + id + ", ";

                vals = vals + "]";
                return new HtmlString(" $(function() { $('#" + pDdlId + "').val(" + vals + "); $('#" + pDdlId +
                                      "').trigger('change')});");
            }

            return null;
        }

        public static HtmlString SelectedValuesDDL(string pDdlId, int[] pIds)
        {
            if (pIds != null)
            {
                var vals = "[";
                foreach (var id in pIds) vals = vals + (id + ", ");

                vals = vals + "]";
                return new HtmlString(" $(function() { $('#" + pDdlId + "').val(" + vals + "); $('#" + pDdlId +
                                      "').trigger('change')});");
            }

            return null;
        }

        //public static HtmlString CargarAutoCompletar(string pFieldName, string pModelList, string pArrayName = "listArray", string pCampo = "Nombre")
        //{
        //    return new HtmlString("var " + pArrayName + " = [];\n" +
        //    "@foreach(var d in Model." + pModelList + ")\n" +
        //    "{\n" +
        //        "@:" + pArrayName + ".push('@d.Nombre');\n" +
        //    "}\n" +
        //    "$('#tags').autocomplete({\n" +
        //        "source: myArray\n" +
        //    "});\n");
        //}
    }

    #endregion
}