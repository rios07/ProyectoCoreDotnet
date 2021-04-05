using System;

namespace FuncionesCore
{
    public class FPaginasGeneral
    {
        #region titulos
        public static string Add = " - Agregar un registro";
        public static string AddSimple = " - Agregar";
        public static string Diagrama = " - Diagrama";
        public static string Enviar = " - Enviar";
        public static string Graficos = " - Gráficos";
        public static string GraficosDeControl = " - Gráficos De Control";
        public static string GraficoComparativo = " - Gráfico Comparativo";
        public static string GraficoComparativoPorRutas = " - Gráfico Comparativo por Rutas";
        public static string GMap = " - Mapa";
        public static string Listado = " - Listado";
        public static string ListadoAvanzado = " - Listado Avanzado";
        public static string ListadoDeControl = " - Listado De Control";
        public static string Selected = " - Registro seleccionado";
        public static string Tablero = " - Tablero";
        #endregion
        public class Notas
        {
            public static string Add(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<br><br>(*): Campos Obligatorios // [#]: Máxima cantidad de caracteres permitidos.";
                }
                else
                {
                    return "<br><br>(*): Campos Obligatorios // [#]: Máxima cantidad de caracteres permitidos. <br><br><b>Notas: </b><br>" + pTexto;
                }
            }
            public static string Enviar(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }
            }
            public static string Graficos(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }
            }
            public static string GraficosDeControl(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }
            }
            public static string GraficoComparativo(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }
            }
            public static string GraficoComparativoPorRutas(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }
            }
            public static string GMap(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }
            }
            public static string Listado(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }
            }
            public static string ListadoAvanzado(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }
            }
            public static string ListadoDeControl(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }
            }
            public static string Selected(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<br><br>(*): Campos Obligatorios // [#]: Máxima cantidad de caracteres permitidos.";
                }
                else
                {
                    return "<br><br>(*): Campos Obligatorios // [#]: Máxima cantidad de caracteres permitidos. <br><br><b>Notas: </b><br>" + pTexto;
                }
            }
            public static string Tablero(string pTexto)
            {
                if (pTexto == "")
                {
                    return "<b>No hay Notas.</b>";
                }
                else
                {
                    return "<b>Notas: </b><br>" + pTexto;
                }

            }
        }
        public static string LinksConcatenadosSoloListados(string pUrlListado, string pUrlListadoAvanzado = "")
        {
            string link = " - <a href=\"" + pUrlListado + "\">abrir el listado</a>";
            if (pUrlListadoAvanzado == "")
            {
                return link;
            }
            else
            {
                return link + " - <a href=\"" + pUrlListadoAvanzado + "\">abrir el listado avanzado</a> ";
            }
        }
        public static string LinksConcatenadosTodos(string pUrlSelected_Id, string pUrlListado, string pUrlAdd = "", string pUrlListadoAvanzado = "")
        {
            string link = " - <a href=\"" + pUrlSelected_Id + "\">abrir el registro cargado/actualizado</a>" + " - <a href=\"" + pUrlListado + "\">abrir el listado</a> ";

            if (pUrlAdd != "")
            {
                link = link + " - <a href=\"" + pUrlAdd + "\">agregarotroregistro</a>";
            }
            if (pUrlListadoAvanzado != "")
            {
                link = link + " - <a href=\"" + pUrlListadoAvanzado + "\">abrir el listado avanzado</a>";
            }

            return link;
        }
        #region Mensajes
        public static string NoHayRegistrosParaListar = "No Hay registros para mostrar.";
        public static string NoHayRegistrosParaListar_EnElPeriodoSeleccionado = "No Hay datos para mostrar en el período seleccionado.";
        public static string NoHayRegistrosSeleccionadosParaExportar = "Por favor, seleccione al menos 1 registro para poder continuar con el proceso de exportación.";
        public static string ExportadoConExito = "Los registros seleccionados fueron exportados con éxito.";
        public static string NoHayRegistrosParaGMAP = "Por favor, seleccione al menos 1 registro para poder mostrar el mapa.";
        public static string NoHayImagenSeleccionada = "No Hay ninguna imagen seleccionada para guardar.";
        public static string NoHayAdjuntoSeleccionado = "No Hay ningun adjunto seleccionado para guardar.";
        public static string SeAgregoConExitoElRegistro = "Se agregó con éxito el registro.";
        public static string SeAgregoConExitoLaImagenDelRegistro = "Se agregó con éxito la imagen";
        public static string SeAgregoConExitoElAdjunto = "Se agregó con éxito el adjunto.";
        public static string SeActivoConExitoElRegistro = "Se activó con éxito el registro.";
        public static string SeDesactivoConExitoElRegistro = "Se desactivó con éxito el registro.";
        public static string SeActualizoConExitoElRegistro = "Se actualizó con éxito el registro.";
        public static string SeAnuloConExitoElRegistro = "Se anuló con éxito el registro.";
        public static string SeEliminoConExitoElRegistro = "Se eliminó con éxito el registro.";
        public static string SeEliminoConExitoElAdjunto = "Se eliminó con éxito el adjunto.";
        public static string SeEmitioConExitoElRegistro = "Se emitió con éxito el registro.";
        public static string NoSePudoModificarYaExisteUnoConEsosDatos = "El registro no se pudo actualizar, ya existe otro con esos mismos datos.";
        public static string TieneEnlazadoUnRegistro = "No se puede operar en este registro, existe un error de elazado.";
        public static string NoTieneAutorizacionParaVerEstaPagina = "No tiene Autorización para ver esta página, disculpe las molestias.";
        public static string NoTieneAutorizacionParaVerEsteRegistro = "No tiene Autorización para ver este registro, disculpe las molestias.";
        public static string NoTieneAutorizacionParaModificarEsteRegistro = "No tiene Autorización para modificar este registro, disculpe las molestias.";
        public static string NoTieneAutorizacionParaModificarEsteRegistro_Base = "No se puede modificar este registro, por que es un registro \"Base\" del sistema.";
        public static string NoTieneAutorizacionParaModificarRegistros = "No tiene Autorización para modificar registros de éste módulo, disculpe las molestias.";
        public static string SeguroDeActivarRegistro = "Está seguro que desea activar este registro ?";
        public static string SeguroDeAnularRegistro = "Está seguro que desea anular este registro ?";
        public static string SeguroDeEliminarRegistro = "Está seguro que desea eliminar este registro ?";
        public static string NoSePuedeEliminarTieneEnlazadoUnRegistro = "Este registro no puede ser eliminado por que está siendo utilizado en el sistema";
        public static string ErrorActualizandoElRegistro = "Se produjo un error al actualizar los datos del registro. ";
        public static string ErrorAlCargarElRegistro = "Se produjo un error al cargar el registro. La página no puede ser mostrada. ";
        public static string ErrorAlCargarLaPagina = "Se produjo un error al cargar la página. ";
        public static string NoExisteElRegistro = "El registro no existe. ";
        public static string noHayRegistros = "No hay registros para mostrar. ";
        public static string HoraNoValida = "La hora ingresada no es válida.";
        public static string FechaNoValida = "La fecha ingresada no es válida.";
        public static string FechaFutura = "La fecha no puede ser mayor a la actual.";
        public static string FechaDesdeNoValida = "La fecha desde no es válida.";
        public static string FechaHastaNoValida = "La fecha hasta no es válida.";
        public static string FechaHastaMenorADesde = "La fecha hasta no puede ser anterior a la fecha desde.";
        public static string AnioNoValido = "Corregir el año para continuar.";
        public static string MesNoValido = "Corregir el mes para continuar.";
        public static string ElRegistroSeEncuentraActivo = "<p class=\"p-Activo\">El Registro se encuentra Activo. </p>";
        public static string ElRegistroSeEncuentraAnulado = "<p class=\"p-Anulado\"> El Registro se encuentra Anulado. </p>";
        public static string ElRegistroSeEncuentraDesactivado = "<p class=\"p-Anulado\"> El Registro está Desactivado. </p>";
        public static string Imagen_NODisponible = "Imagen no disponible.";
        public static string ActualizadoAntesDeGuardar = "Actualizó antes de Guardar ?.";
        public static string RegeolozalizarDirecciones = "Se regeolocalizarán todas las direcciones pertenecientes a la calle seleccionada. Esta operación puede demorar unos instantes. ¿Desea continuar?";

        public static string ErrorGeneral(string pMensaje)
        {
            return "No se puede continuar, Se produjo el siguiente error: " + pMensaje;
        }
        public static string HoraNoValidaEnRango(string pInicial, string pFinal)
        {
            return HoraNoValida + " Debe estar dentro del rango " + pInicial + " - " + pFinal;
        }

        public static string CantidadRegistrosListados(string pNumero, string pBuscar = "", string pDeTotalDeRegistros = "0")
        {
            string textoTotalDeRegistros = "";
            if (!(pDeTotalDeRegistros == "0"))
            {
                textoTotalDeRegistros = "(De un total de " + pDeTotalDeRegistros + ")";
            }
            string respuesta;
            switch (pNumero)
            {
                case "0":

                    respuesta = noHayRegistros;
                    break;
                case "1":

                    respuesta = "1 registro listado." + textoTotalDeRegistros;
                    break;
                default:

                    respuesta = pNumero + " registros listados." + textoTotalDeRegistros;
                    break;
            }
            if (String.IsNullOrEmpty(pBuscar)){
                return respuesta;
            }
            else
            {
                return respuesta + "<font color=\"black\">   ---  Resultado filtrado con el parámetro: </font><font color=\"red\">\"" + pBuscar + "\"</font><font color=\"black\">   ---  </font>";
            }
         }
        #endregion
    }
}
