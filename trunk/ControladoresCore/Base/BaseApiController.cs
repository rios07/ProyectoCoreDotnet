using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ControladoresCore.ViewModels;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using ServiciosCore;


namespace ControladoresCore.Base
{
    public abstract class BaseApiController<Modelo, ModeloExt, VM> : ApiController where Modelo : BaseModelo, new()
        where ModeloExt : Modelo
        where VM : BaseVM, new()
    {
        public BaseApiController(ILogErroresServicio pLogErroresServicio)
        {
            _logErroresServicio = pLogErroresServicio;
        }

        protected string _seccion = "intranet";
        protected abstract IBaseServicios<Modelo, ModeloExt> GetServicio();

        private ILogErroresServicio _logErroresServicio;
        // GET: api/Test
        [Authorize]
        public virtual HttpResponseMessage Get()
        {
            var controllerBag = new ControllerBag();
            controllerBag.Seccion = _seccion;
            try
            {
                GetServicio().SetDatosDeLogin(new DatosDeLogin
                {
                    UsuarioId = int.Parse(Request.Properties["userId"].ToString())
                }); //userId pertenece a request, no al token
                return Request.CreateResponse(HttpStatusCode.OK, GetServicio().Listado(ref controllerBag));
            }
            catch (Exception e)
            {
                _logErroresServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
                LogErrores log = new LogErrores() { Accion = "Get", Capa = "Api", Mensaje = e.Message, Metodo = "Listando" };
                _logErroresServicio.Insert(log, ref controllerBag);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // GET: api/Test/5
        public virtual HttpResponseMessage Get(int id)
        {
            var controllerBag = new ControllerBag();
            controllerBag.Seccion = _seccion;
            try
            {
                GetServicio().SetDatosDeLogin(new DatosDeLogin
                { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });
                return Request.CreateResponse(HttpStatusCode.OK, GetServicio().Registro(id, ref controllerBag));
            }
            catch (Exception e)
            {
                _logErroresServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
                LogErrores log = new LogErrores() { Accion = "Get", Capa = "Api", Mensaje = e.Message, Metodo = "Listando" };
                _logErroresServicio.Insert(log, ref controllerBag);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST: api/Test
        public virtual HttpResponseMessage Post([FromBody] Modelo value)
        {
            var controllerBag = new ControllerBag();
            controllerBag.Seccion = _seccion;
            GetServicio().SetDatosDeLogin(new DatosDeLogin
            { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });
            HttpStatusCode statusCode;
            string responseMsg;
            try
            {
                int idInsert = GetServicio().Insert(value, ref controllerBag);
                if (controllerBag.TieneErrores())
                {
                    _logErroresServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
                    LogErrores log = new LogErrores() { Accion = "Post", Capa = "Api", Mensaje = controllerBag[0].Contenido, Metodo = "Conflict" };
                    _logErroresServicio.Insert(log, ref controllerBag);
                    responseMsg = controllerBag[0].Contenido;
                    statusCode = HttpStatusCode.Conflict;
                }
                else
                {
                    responseMsg = idInsert.ToString();
                    statusCode = HttpStatusCode.Created;
                }
            }
            catch (Exception e)
            {
                _logErroresServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
                LogErrores log = new LogErrores() { Accion = "Post", Capa = "Api", Mensaje = e.Message, Metodo = "Exeption" };
                _logErroresServicio.Insert(log, ref controllerBag);
                responseMsg = e.Message;
                statusCode = HttpStatusCode.InternalServerError;
            }

            return Request.CreateResponse(statusCode, responseMsg);
        }

        // PUT: api/Test/5
        [HttpPut]
        public virtual HttpResponseMessage Put(int id ,[FromBody] Modelo value)
        {

            var controllerBag = new ControllerBag();
            controllerBag.Seccion = _seccion;
            GetServicio().SetDatosDeLogin(new DatosDeLogin
            { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });
            var statusCode = HttpStatusCode.OK;
            var responseMsg = "ok";
            /*   if (value.Id != id)
               {
                   statusCode = HttpStatusCode.BadRequest;
                   responseMsg = "El id del model no corresponde con el id enviado";
                   return Request.CreateResponse(statusCode, responseMsg);
               }*/

            try
            {
                GetServicio().Update(value, ref controllerBag);
                if (controllerBag.TieneErrores())
                {
                    _logErroresServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
                    LogErrores log = new LogErrores() { Accion = "Put", Capa = "Api", Mensaje = controllerBag[0].Contenido, Metodo = "Conflict" };
                    _logErroresServicio.Insert(log, ref controllerBag);
                    responseMsg = controllerBag[0].Contenido;
                    statusCode = HttpStatusCode.Conflict;
                }
            }
            catch (Exception e)
            {
                _logErroresServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
                LogErrores log = new LogErrores() { Accion = "Post", Capa = "Api", Mensaje = e.Message, Metodo = "Exeption" };
                _logErroresServicio.Insert(log, ref controllerBag);
                responseMsg = e.Message;
                statusCode = HttpStatusCode.InternalServerError;
            }

            return Request.CreateResponse(statusCode, responseMsg);
        }

        // DELETE: api/Test/5
        public virtual HttpResponseMessage Delete(int id)
        {
            var controllerBag = new ControllerBag();
            controllerBag.Seccion = _seccion;
            GetServicio().SetDatosDeLogin(new DatosDeLogin
            { UsuarioId = int.Parse(Request.Properties["userId"].ToString()) });
            var statusCode = HttpStatusCode.OK;
            var responseMsg = "ok";
            try
            {
                GetServicio().Delete(id, ref controllerBag);
                if (controllerBag.TieneErrores())
                {
                    _logErroresServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
                    LogErrores log = new LogErrores() { Accion = "Delete", Capa = "Api", Mensaje = controllerBag[0].Contenido, Metodo = "Conflict" };
                    _logErroresServicio.Insert(log, ref controllerBag);
                    statusCode = HttpStatusCode.Conflict;
                    responseMsg = controllerBag[0].Contenido;
                }
            }
            catch (Exception e)
            {
                _logErroresServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
                LogErrores log = new LogErrores() { Accion = "Delete", Capa = "Api", Mensaje = e.Message, Metodo = "Exeption" };
                _logErroresServicio.Insert(log, ref controllerBag);
                statusCode = HttpStatusCode.InternalServerError;
                responseMsg = controllerBag[0].Contenido;
            }


            return Request.CreateResponse(statusCode, responseMsg);
        }

    }
}