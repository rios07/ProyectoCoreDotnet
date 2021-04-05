using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ControladoresCore.ViewModels;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using ServiciosCore;

namespace ControladoresCore.Base
{
    class ArchivoApiController : ApiController
    {
        private IArchivosServicio _archivosServicio;

        public ArchivoApiController(IArchivosServicio pArchivosSevicio)
        {
            _archivosServicio = pArchivosSevicio;
        }

        public HttpResponseMessage Get(string tabla= null , int registroId = 0)
        {
            var controllerBag = new ControllerBag();
            _archivosServicio.SetDatosDeLogin(new DatosDeLogin
                { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });
            HttpStatusCode statusCode;
            string responseMsg;

            controllerBag.Seccion = "intranet";
            List<ArchivosExt> archivos = _archivosServicio.CargarArchivos(tabla, registroId, ref controllerBag);

            if (controllerBag.TieneErrores())
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, controllerBag[0]);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, archivos);
            }

        }
        public HttpResponseMessage Post([FromBody] ArchivosApiVM pArchivo)
        {
            NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {

                var controllerBag = new ControllerBag();
                _archivosServicio.SetDatosDeLogin(new DatosDeLogin
                    {UsuarioId = int.Parse(Request.Properties["userId"].ToString())});
                HttpStatusCode statusCode;
                string responseMsg;

                controllerBag.Seccion = "intranet";


                controllerBag.RutaFisica = ConfigurationManager.AppSettings["LocalDir"];
                if (String.IsNullOrEmpty(controllerBag.RutaFisica))
                {
                    Logger.Info("LocalDir no definido en config");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "LocalDir no definido en config");
                }

                ArchivosExt archivo = new ArchivosExt()
                {
                    NombreAMostrar = pArchivo.NombreAMostrar,
                    NombreFisicoCompleto = pArchivo.NombreAMostrar,
                    Observaciones = pArchivo.Observaciones,
                    RegistroId = pArchivo.RegistroId,
                    Tabla = pArchivo.Tabla,
                    FileByteArray = Encoding.GetEncoding("iso-8859-1").GetBytes(pArchivo.ByteStrings)
                };

                int idInsert = _archivosServicio.GuardarArchivoUnico(archivo, ref controllerBag);

                if (controllerBag.TieneErrores())
                {
                    responseMsg = controllerBag[0].Contenido;
                    statusCode = HttpStatusCode.Conflict;
                }
                else
                {
                    responseMsg = idInsert.ToString();
                    statusCode = HttpStatusCode.Created;
                }


                return Request.CreateResponse(statusCode, responseMsg);
            }
            catch (Exception e)
            {
                string exceptionToLog = Newtonsoft.Json.JsonConvert.SerializeObject(e);

                Logger.Error(e.Message);
                Logger.Error(exceptionToLog);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
            
        }


    }

    class ArchivosApiVM : ArchivosVM
    {
        public string Tabla { get; set; }
        public string ByteStrings { get; set; } //iso 8859-1 encoded

        public string RutaImg { get; set; }
    }
}
