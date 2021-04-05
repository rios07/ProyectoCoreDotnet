namespace FuncionesCore
{
    class FScripts
    {
        #region
        //TODO: Ver esto cuando JavaScrip

        //    Public Shared Tab_Menu_Default As String = "<script type=""text/javascript"">$(function () { $(""#tabs"").tabs({ event: ""mouseover"" }); });</script>"

        //        Public Shared Function Tab_Menu(sTab As String) As String
        //            Return "<script type=""text/javascript""> $(function () { $(""#tabs"").tabs({ selected: " & sTab & " }); });</script>"
        //        End Function

        //        Public Shared Tab_Menu_Producto As String = "<script type=""text/javascript"">$(function () { $(""#tabsVDP"").tabs({ event: ""mouseover"" }); });</script>"

        //        Public Shared Link_DataPicker As String = "<script type=""text/javascript"" src=""../js/DataPickers.js""></script>"

        //        Public Shared Link_MultiFileUpload As String = "<script type=""text/javascript"" src=""../js/jquery/jquery.MultiFile.js""></script>"

        //        Shared Function Armar_JS_imgGrande(WUC As String, imgGrande_id As String) As String
        //            ' function load_imgGrande(imagen) {
        //            '       document.getElementById('ctl00_contentPlaceHolder1_WUC_Pagina_InspeccionesDe_Servicios_Deficiencias_Selected_1_imgGrande').src = imagen;
        //            ' }

        //            'Return "<script type=""text/javascript""> " & _
        //            '        "$(function load_imgGrande(imagen) {" & _
        //            '        "document.getElementById('ctl00_contentPlaceHolder1_" & _
        //            '        WUC & "_1_" & imgGrande_id & "').src = imagen;" & _
        //            '        "});</script>"

        //            Return "<script type=""text/javascript""> " & _
        //                    "function load_imgGrande(imagen) {" & _
        //                    "document.getElementById('ctl00_contentPlaceHolder1_" & _
        //                    WUC & "_1_" & imgGrande_id & "').src = imagen;" & _
        //                    "}" & _
        //                    "</script>"

        //        End Function

        //        'FUNCION PARA REGISTRAR SCRIPTS DINAMICAMENTE (sScript se arma con las funciones de abajo)
        //        ''' <summary>
        //        ''' Sirve para registrar Scripts de Javascript, en sScript se ingresa el script, en Page el Parent.Page del WUC y en sName un nombre indicativo que no puede repetirse para un mismo WUC
        //        ''' </summary>
        //        Shared Sub RegistrarJS(sScript As String, ByRef Page As Control, sName As String)
        //            ScriptManager.RegisterStartupScript(Page, Page.GetType, sName, sScript, True)
        //        End Sub

        //        'FUNCIONES PARA ARMAR SCRIPTS DINAMICAMENTE
        //        ''' <summary>
        //        ''' Recibe un Control y devuelve como string el Script que agrega un TimePicker a dicho control (véase función RegistrarJS)
        //        ''' </summary>
        //        Shared Function TimePicker(Control As Control, Optional hourMin As String = "0", Optional hourMax As String = "23", Optional hourGrid As Integer = 4) As String
        //            hourMin = Left(hourMin, 2)
        //            hourMax = Left(hourMax, 2)
        //            Return "$(function () { $(""#" & Control.ClientID & """).timepicker({ timeFormat: 'HH:mm', hourGrid: " & hourGrid & ", hourMin: " & hourMin & ", hourMax: " & hourMax & ",  minuteGrid: 10, showOn: ""button"", buttonImage: ""images/iconos/calendar.gif"", buttonImageOnly: true }); });"
        //        End Function

        //        ''' <summary>
        //        ''' Recibe un Control y devuelve como string el Script que agrega un DatePicker a dicho control (véase función RegistrarJS)
        //        ''' </summary>
        //        Shared Function DatePicker(Control As Control) As String
        //            Return "$(function () { $(""#" & Control.ClientID & """).datepicker({ dateFormat: 'dd/mm/yy', controlType: 'select', showOn: ""button"", buttonImage: ""images/iconos/calendar.gif"", buttonImageOnly: true }); });"
        //        End Function

        //        Shared Sub CargarDatePickerEnGV(ByRef gv As GridView, sControl As String, ByRef Page As Control, Optional bAplicarSoloAEnabled As Boolean = False)
        //            Dim i As Integer = 1
        //            Dim txtCampo As TextBox
        //            Dim bEsTextBox As Boolean = False

        //            Try 'verifico si el control es un textbox
        //                txtCampo = DirectCast(gv.Rows(0).FindControl(sControl), TextBox)
        //                bEsTextBox = True
        //            Catch ex As Exception
        //                ' no es textbox --> no verifico el enabled
        //            End Try

        //            If bEsTextBox And bAplicarSoloAEnabled Then
        //                For Each row As GridViewRow In gv.Rows
        //                    txtCampo = DirectCast(row.FindControl(sControl), TextBox)
        //                    If txtCampo.Enabled Then RegistrarJS(DatePicker(row.FindControl(sControl)), Page, "dp_" & i & "_" & sControl)
        //                    i += 1
        //                Next
        //            Else
        //                For Each row As GridViewRow In gv.Rows
        //                    RegistrarJS(DatePicker(row.FindControl(sControl)), Page, "dp_" & i & "_" & sControl)
        //                    i += 1
        //                Next
        //            End If
        //        End Sub


        //        ''' <summary>
        //        ''' Se usa para el control DDCL_DropDownCheckList
        //        ''' </summary>
        //        ''' <param name="cbx"></param>
        //        ''' <param name="cbxl"></param>
        //        ''' <param name="bDropDownCheckBoxList"></param>
        //        ''' <returns></returns>
        //        ''' <remarks></remarks>
        //        Shared Function CheckAll(cbx As CheckBox, cbxl As CheckBoxList, Optional bDropDownCheckBoxList As Boolean = False) As String

        //            Return "$('#" & cbx.ClientID & "').click(function () {" & _
        //                            IIf(bDropDownCheckBoxList, "DDCL_DropDownCheckList_OpenCheckList();DDCL_DropDownCheckList_DisplayCheckedItems();", "") & _
        //                            "$('input[id^=""" & cbxl.ClientID & """]').each(function (i, elem) {" & _
        //                                "if ($('#" & cbx.ClientID & "').attr('checked')) {" & _
        //                                    "$(this).attr('checked', true);" & _
        //                                "} else {" & _
        //                                    "$(this).attr('checked', false);" & _
        //                                "}});});"
        //        End Function

        //        ''' <summary>
        //        ''' Recibe un TextBox y un CheckBoxList y devuelve como string el Script que convierte al TextBox en un filtro dinámico para el CheckBoxList (véase función RegistrarJS)
        //        ''' </summary>
        //        Shared Function AutoFiltro(txt As TextBox, cbxl As CheckBoxList) As String

        //            Return "$('#" & txt.ClientID & "').on('keyup', function () {" & _
        //                            "var query = this.value;" & _
        //                            "$('label[for^=""" & cbxl.ClientID & """]').each(function (i, elem) {" & _
        //                                "var lblText = $(this).text().toUpperCase();" & _
        //                                "if (lblText.indexOf(query.toUpperCase()) != -1) {" & _
        //                                    "$(this).css(""display"", ""inline"");" & _
        //                                    "$(""#"" + $(this).attr(""for"")).css(""display"", ""inline"");" & _
        //                                "} else {" & _
        //                                    "$(this).css(""display"", ""none"");" & _
        //                                    "$(""#"" + $(this).attr(""for"")).css(""display"", ""none"");" & _
        //                                "}});});"
        //        End Function

        //        Shared Function DisplayQuitarFiltro(txt As TextBox, div As HtmlGenericControl) As String
        //            If txt.Text.Length = 0 Then
        //                div.Attributes.CssStyle("display") = "none"
        //            Else
        //                div.Attributes.CssStyle("display") = "block"
        //            End If

        //            Return "$('#" & txt.ClientID & "').on('keyup', function () {" & _
        //                            "var query = this.value;" & _
        //                            "if (query != """") {" & _
        //                            "$('#" & div.ClientID & "').css(""display"", ""block"");}" & _
        //                            "else { $('#" & div.ClientID & "').css(""display"", ""none"");}" & _
        //                           "});"
        //        End Function

        //        Shared Sub Evitar_DobleClick_ByList(ByRef sPage As Page, ByRef Controles As ControlCollection)
        //            RegistrarJS("function DisableButtons() {var inputs = document.getElementsByTagName(""INPUT"");for (var i in inputs) {if (inputs[i].type == ""button"" || inputs[i].type == ""submit"") {inputs[i].disabled = true;}}} window.onbeforeunload = DisableButtons;", _
        //                        sPage, "globalDisable")

        //            'For Each up As UpdatePanel In Controles.OfType(Of UpdatePanel)()
        //            '    Evitar_DobleClick_ByListOf_Buttons(sPage, up.ContentTemplateContainer.Controls.OfType(Of Button).ToList())
        //            '    Evitar_DobleClick_ByListOf_ImageButtons(sPage, up.ContentTemplateContainer.Controls.OfType(Of ImageButton).ToList())
        //            '    Evitar_DobleClick_ByListOf_LinkButtons(sPage, up.ContentTemplateContainer.Controls.OfType(Of LinkButton).ToList())
        //            'Next

        //            'Evitar_DobleClick_ByListOf_Buttons(sPage, Controles.OfType(Of Button).ToList)
        //            'Evitar_DobleClick_ByListOf_ImageButtons(sPage, Controles.OfType(Of ImageButton).ToList)
        //            'Evitar_DobleClick_ByListOf_LinkButtons(sPage, Controles.OfType(Of LinkButton).ToList)
        //        End Sub

        //        'btnAgregar.Attributes.Add("onclick", " this.disabled = true; " + Page.ClientScript.GetPostBackEventReference(btnAgregar, Nothing) + ";")
        //        Shared Sub Evitar_DobleClick(ByRef sPage As Page, ByRef btn As Button)
        //            btn.Attributes.Add("onclick", " this.disabled = true; " + sPage.ClientScript.GetPostBackEventReference(btn, Nothing) + ";")
        //        End Sub
        //        Shared Sub Evitar_DobleClick(ByRef sPage As Page, ByRef btn As ImageButton)
        //            btn.Attributes.Add("onclick", " this.disabled = true; " + sPage.ClientScript.GetPostBackEventReference(btn, Nothing) + ";")
        //        End Sub
        //        Shared Sub Evitar_DobleClick(ByRef sPage As Page, ByRef btn As LinkButton)
        //            btn.Attributes.Add("onclick", " this.disabled = true; " + sPage.ClientScript.GetPostBackEventReference(btn, Nothing) + ";")
        //        End Sub

        //        Shared Sub Evitar_DobleClick_ByListOf_Buttons(ByRef sPage As Page, ByRef Controles As List(Of Button))
        //            For Each btn As Button In Controles
        //                btn.Attributes.Add("onclick", " this.disabled = true; " + sPage.ClientScript.GetPostBackEventReference(btn, Nothing) + ";")
        //            Next
        //        End Sub

        //        Shared Sub Evitar_DobleClick_ByListOf_ImegeButtons(ByRef sPage As Page, ByRef Controles As List(Of ImageButton))
        //            For Each btn As ImageButton In Controles
        //                btn.Attributes.Add("onclick", " this.disabled = true; " + sPage.ClientScript.GetPostBackEventReference(btn, Nothing) + ";")
        //            Next
        //        End Sub

        //        Shared Sub Evitar_DobleClick_ByListOf_LinkButtons(ByRef sPage As Page, ByRef Controles As List(Of LinkButton))
        //            For Each btn As LinkButton In Controles
        //                btn.Attributes.Add("onclick", " this.disabled = true; " + sPage.ClientScript.GetPostBackEventReference(btn, Nothing) + ";")
        //            Next
        //        End Sub

        //        ''' <summary>
        //        ''' Recibe un Control img de gráfico y le aplica la función responsive del lado del cliente.
        //        ''' </summary>
        //        Shared Function GraficoResponsive(Control As Control) As String
        //            Return "$(window).resize(function () { var width = 1325;" & _
        //                    "var height = 500;" & _
        //                    "if ($(window).width() < 940) {" & _
        //                        "width = 760;" & _
        //                        "height = 500 * width / 1325;" & _
        //                    "} else if ($(window).width() < 999) {" & _
        //                        "width = 930;" & _
        //                        "height = 500 * width / 1325;" & _
        //                    "} else if ($(window).width() < 1259) {" & _
        //                        "width = 990;" & _
        //                        "height = 500 * width / 1325;" & _
        //                    "} else if ($(window).width() < 1339) {" & _
        //                        "width = 1250;" & _
        //                        "height = 500 * width / 1325;" & _
        //                    "} else {" & _
        //                        "width = 1325;" & _
        //                        "height = 500;" & _
        //                    "}" & _
        //                    "var graph = $(""#" & Control.ClientID & """);" & _
        //                    "graph.css(""width"", width);" & _
        //                    "graph.css(""height"", height);" & _
        //                "});"
        //        End Function

        //    End Class
        //End Namespace
    }
    #endregion

}
