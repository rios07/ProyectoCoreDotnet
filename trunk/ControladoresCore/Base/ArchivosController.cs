using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ControladoresCore.ViewModels;
using FuncionesCore;
using RepositoriosCore;
using ServiciosCore;

namespace ControladoresCore.Base
{
    public class ArchivosController : ApiController
    {
        private readonly IArchivosServicio _ArchivosServicio;

        public ArchivosController(IArchivosServicio pArchivoservicio)
        {
            _ArchivosServicio = pArchivoservicio;
        }

        [Authorize]
        public HttpResponseMessage Get()
        {
            try
            {
                var controllerBag = new ControllerBag();
                _ArchivosServicio.SetDatosDeLogin(new DatosDeLogin
                {
                    UsuarioId = int.Parse(Request.Properties["userId"].ToString())
                }); //userId pertenece a request, no al token
                controllerBag.Seccion = "administracion";
                return Request.CreateResponse(HttpStatusCode.OK, _ArchivosServicio.Listado(ref controllerBag));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}