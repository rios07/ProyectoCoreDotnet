using ControladoresCore.ViewModels;
using FuncionesCore;
using ModelosCore;
using ServiciosCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
namespace ControladoresCore.Base
{
    public abstract class BaseApiController<Modelo, ModeloExt, VM> : ApiController where Modelo : BaseModelo, new() where ModeloExt : Modelo where VM : BaseVM, new() 
    {
        protected abstract IBaseServicios<Modelo, ModeloExt> GetServicio();

        // GET: api/Test
        [Authorize]
        public HttpResponseMessage Get()
        {
            try
            {
                ControllerBag controllerBag = new ControllerBag();
                GetServicio().SetDatosDeLogin(new RepositoriosCore.DatosDeLogin() { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });//userId pertenece a request, no al token
                controllerBag.Seccion = "intranet";
                return Request.CreateResponse(HttpStatusCode.OK, GetServicio().Listado(ref controllerBag));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        // GET: api/Test/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                ControllerBag controllerBag = new ControllerBag();
                GetServicio().SetDatosDeLogin(new RepositoriosCore.DatosDeLogin() { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });
                controllerBag.Seccion = "intranet";
                return Request.CreateResponse(HttpStatusCode.OK, GetServicio().Registro(id, ref controllerBag));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
           
        }

        // POST: api/Test
        public HttpResponseMessage Post([FromBody]Modelo value)
        {
            ControllerBag controllerBag = new ControllerBag();
            GetServicio().SetDatosDeLogin(new RepositoriosCore.DatosDeLogin() { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });
            HttpStatusCode statusCode = HttpStatusCode.Created;
            string responseMsg = "Creado";
            controllerBag.Seccion = "intranet";
            try
            {
                GetServicio().Insert(value, ref controllerBag);
                if (controllerBag.TieneErrores())
                {
                    responseMsg = controllerBag[0].Contenido;
                    statusCode = HttpStatusCode.Conflict;
                }
                else
                {
                    statusCode = HttpStatusCode.Created;
                }
            }
            catch (Exception e)
            {
                responseMsg = e.Message;
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Request.CreateResponse(statusCode, responseMsg);
        }

        // PUT: api/Test/5
        public HttpResponseMessage Put(int id, [FromBody]Modelo value)
        {
            ControllerBag controllerBag = new ControllerBag();
            GetServicio().SetDatosDeLogin(new RepositoriosCore.DatosDeLogin() { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });
            HttpStatusCode statusCode = HttpStatusCode.OK;
            string responseMsg = "ok";
            controllerBag.Seccion = "intranet";
            if (value.Id != id)
            {
                statusCode = HttpStatusCode.BadRequest;
                responseMsg = "El id del model no corresponde con el id enviado";
                return Request.CreateResponse(statusCode, responseMsg);
            }
            try
            {
                GetServicio().Update(value, ref controllerBag);
                if (controllerBag.TieneErrores())
                {
                    responseMsg = controllerBag[0].Contenido;
                    statusCode = HttpStatusCode.Conflict;
                }
            }
            catch (Exception e)
            {
                responseMsg = e.Message;
                statusCode = HttpStatusCode.InternalServerError;

            }
            return Request.CreateResponse(statusCode, responseMsg);

        }

        // DELETE: api/Test/5
        public HttpResponseMessage Delete(int id)
        {
            ControllerBag controllerBag = new ControllerBag();
            GetServicio().SetDatosDeLogin(new RepositoriosCore.DatosDeLogin() { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });
            HttpStatusCode statusCode = HttpStatusCode.OK;
            string responseMsg = "ok";
            controllerBag.Seccion = "intranet";
            try
            {
                GetServicio().Delete(id, ref controllerBag);
                if (controllerBag.TieneErrores())
                {
                    statusCode = HttpStatusCode.Conflict;
                    responseMsg = controllerBag[0].Contenido;
                }
            }
            catch (Exception e)
            {
                statusCode = HttpStatusCode.InternalServerError;
                responseMsg = controllerBag[0].Contenido;
            }
            

            return Request.CreateResponse(statusCode, responseMsg);
        }

        
    }
}