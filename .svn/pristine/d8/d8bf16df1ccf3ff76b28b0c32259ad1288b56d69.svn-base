using AutoMapper;
using ControladoresCore.ViewModels;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using ServiciosCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Reflection;
using System.IO;
using System.Web;
using _DatosDelSistema;
using System.Diagnostics;
using CustomDataAnnotations;

namespace ControladoresCore.Base
{
    // Si no quiero usar U, tengo la posibilidad de solo pasarle T y su ViewModel
    // public abstract class BaseControladores<Modelo, VM> : BaseControladores<Modelo, Modelo, VM, VM> where Modelo : BaseModelo where VM : new()
    public abstract class BaseControladores<Modelo, VM> : BaseControladores<Modelo, Modelo, VM, VM> where Modelo : BaseModelo, new() where VM : BaseVM, new()
    {
        public BaseControladores(ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosServicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosServicio, pNotificacionesServicio)
        {
        }
    }

    // Si no quiero usar ni U, ni ViewModel, solo le paso T (el modelo)
    //public abstract class BaseControladores<T> : BaseControladores<T, T, T, T> where T : new() { }

    // public abstract class BaseControladores<Modelo, ModeloExt, VM> : BaseControladores<Modelo, ModeloExt, VM, VM> where Modelo : BaseModelo where ModeloExt : Modelo where VM : new()
    public abstract class BaseControladores<Modelo, ModeloExt, VM> : BaseControladores<Modelo, ModeloExt, VM, VM> where Modelo : BaseModelo, new() where ModeloExt : Modelo where VM : BaseVM, new()
    {
        public BaseControladores(ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosServicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosServicio, pNotificacionesServicio)
        {
        }
    }

    /// <summary>
    /// Controlador base para que lo hereden todos los demás, acá iria la funcionalidad compartida.
    /// </summary>
    [Authorize]
    //public abstract class BaseControladores<Modelo, ModeloExt, VM, VMExt> : Controller where Modelo : BaseModelo where ModeloExt : Modelo where VM : new()
    public abstract class BaseControladores<Modelo, ModeloExt, VM, VMExt> : Controller where Modelo : BaseModelo, new() where ModeloExt : Modelo where VM : BaseVM, new() where VMExt : VM, new()
    {
        ILogErroresServicio _logErroresServicio;
        public abstract IBaseServicios<Modelo, ModeloExt> GetServicio();
        private IUsuariosServicio _usuariosServicio;
        protected ControllerBag _controllerBag;  //private List<MensajeDeError> _miMsg;
        private INotificacionesServicio _notificacionesServicio;//TODO: Agregarlo donde corresponda
        protected int _idInsert;
        public BaseControladores(ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosServicio, INotificacionesServicio pNotificacionesServicio)
        {
            _logErroresServicio = pLogErroresServicio;
            _usuariosServicio = pUsuariosServicio;
            _notificacionesServicio = pNotificacionesServicio;
            _controllerBag = new ControllerBag(); // List<MensajeDeError>();
            //GetServicio().SetMiMsg(_miMsg);
        }

        public virtual ActionResult Insert(string pTabla = "", int pRegistroId = 1)
        {
            
            VM viewModel;

            if (TempData.ContainsKey("UltimoRequest"))
            {
                viewModel = (VM)TempData["UltimoRequest"];
            }
            else
            {
                viewModel = new VM();
            }

            CargarDDLs(viewModel, true);

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Insert(VM pObj)
        {
            if (NoTienePermiso("Operar"))
            {
                _controllerBag.Add("Usted No tiene Permisos ", true);
                return RedirectToAction(AccionAnterior(), ControllerAnterior(), null);
            }

            _controllerBag.Operacion = Operacion.insert;
            if (ModelState.IsValid && pObj != null) //ModelStat.IsValid checkea las dataAnotations.
            {
                VM source = pObj;
                Modelo destination = Mapper.Map<VM, Modelo>(source);


                int registroId = GetServicio().Insert(destination, ref _controllerBag);
                _idInsert = registroId;
                // Si tiene errores --> Le retorno la misma para que corrija
                if (_controllerBag.TieneErrores())
                {
                    //cargo en tempdata pObj
                    TempData["UltimoRequest"] = pObj;
                    return RedirectToAction("Insert");
                }
                else
                {
                    _controllerBag.Add("Registro añadido exitosamente. <a href=\"Registro/" + registroId + "\" title=\"Registro\">Ir al registro</a>");
                    return RedirectToAction("Insert");
                }
            }
            else
            {
                CargarDDLs(pObj, true);
                return View(pObj); // Le retorno la misma para que corrija
            }
        }


        [OperacionPadre("Registro")]
        public virtual ActionResult Delete(int pParam)
        {
            if (NoTienePermiso("Operar"))
            {
                _controllerBag.Add("Usted No tiene Permisos ", true);
                return RedirectToAction(AccionAnterior(), ControllerAnterior(), null);
            }

            _controllerBag.Operacion = Operacion.delete;
            GetServicio().Delete(pParam, ref _controllerBag);

            if (_controllerBag.TieneErrores())
            {
                return RedirectToAction("Registro", new { pParam = pParam });
            }
            else
            {
                return RedirectToAction("Listado");
            }
        }

        public virtual ActionResult Registro(int pParam)
        {

            if (NoTienePermiso("Cargar"))
            {
                _controllerBag.Add("Usted No tiene Permisos ", true);
                return RedirectToAction(AccionAnterior(), ControllerAnterior(), null);
            }

            _controllerBag.Operacion = Operacion.registro;
            ModeloExt source = GetServicio().Registro(pParam, ref _controllerBag);
            if (source == null)
            {
                _controllerBag.Add("Registro inexistente", true);
                return RedirectToAction("Listado", new Modelo().GetType().Name, null);
            }
            VM destination = Mapper.Map<ModeloExt, VM>(source);


            return View(destination);
        }

        public virtual ActionResult Update(int pParam)
        {
            if (NoTienePermiso("Cargar"))
            {
                _controllerBag.Add("Usted No tiene Permisos ", true);
                return RedirectToAction(AccionAnterior(), ControllerAnterior(), null);
            }

            _controllerBag.Operacion = Operacion.update;
            Modelo source = GetServicio().Registro(pParam, ref _controllerBag);
            if (source == null)
            {
                _controllerBag.Add("Registro inexistente", true);
                return RedirectToAction("Listado", typeof(Modelo).Name, null);
            }
            VM destination = Mapper.Map<Modelo, VM>(source);
            CargarDDLs(destination, true);
            return View(destination);
        }

        [HttpPost]
        [ActionName("Update")]
        public virtual ActionResult Update(int pParam, VM pObj)
        {
            if (NoTienePermiso("Operar"))
            {
                _controllerBag.Add("Usted No tiene Permisos ", true);
                return RedirectToAction(AccionAnterior(), ControllerAnterior(), null);
            }

            _controllerBag.Operacion = Operacion.update;
            if (pObj != null)
            {
                VM source = pObj;
                Modelo destination = Mapper.Map<VM, Modelo>(source);
                GetServicio().Update(destination, ref _controllerBag);

                // Si tiene errores --> Le retorno la misma p q corrija, si no, --> al index.
                if (_controllerBag.TieneErrores())
                {
                    CargarDDLs(pObj, true);
                    return RedirectToAction("Update", pParam);
                }
                else
                {
                    return RedirectToAction("Listado");
                }
            }
            else
            {
                return View(pObj); // Le retorno la misma p q corrija
            }
        }

        public virtual ActionResult NoPermisos()
        {
            return View();
        }

        public virtual ActionResult Listado(string pParam = "")
        {
            if (NoTienePermiso("Cargar"))
            {
                _controllerBag.Add("Usted No tiene Permisos ", true);
                return RedirectToAction("Listado", new Modelo().GetType().ToString(), null);
            }
            if (pParam == "Avanzado")
            {
                ViewBag.ListadoAvanzado = true;
                ViewBag.DatosDeUnaPagina.Titulo = ViewBag.DatosDeUnaPagina.Titulo + " Avanzado";
            }
            else
            {
                ViewBag.ListadoAvanzado = false;
            }
            VM viewModel = new VM();
            CargarDDLs(viewModel, null);
            return View(viewModel);
        }

        /// <summary>
        /// función que se ejecuta justo antes de cualquier acción de un controller derivado de BaseControladores
        /// </summary>
        /// <param name="pFilterContext"></param>
        [AllowAnonymous]
        protected override void OnActionExecuting(ActionExecutingContext pFilterContext)
        {
            bool esAnonima = false;
            var atributes = pFilterContext.ActionDescriptor.GetCustomAttributes(false);
            string actionName = pFilterContext.ActionDescriptor.ActionName;
            

            if (pFilterContext.RouteData.Values["pSeccion"] != null)
            {
                _controllerBag.Seccion = pFilterContext.RouteData.Values["pSeccion"].ToString().ToLower();
                ViewBag.Seccion = pFilterContext.RouteData.Values["pSeccion"].ToString().ToLower();
            }
            if (actionName.IndexOf("_", StringComparison.Ordinal) != -1)
            {
                if (actionName.IndexOf("RelAsig", StringComparison.Ordinal) != 0)
                {
                    string seccion = actionName.Substring(actionName.IndexOf("_", StringComparison.Ordinal) + 1);
                    actionName = actionName.Substring(0, actionName.IndexOf("_", StringComparison.Ordinal));
                }
            }
            foreach (var atribute in atributes)
            {
                if (atribute.ToString() == "System.Web.Mvc.OverrideAuthorizationAttribute")
                {
                    esAnonima = true;
                    _controllerBag.EsAnonima = true;

                }
            }
            //de esta manera recuperamos el _controllerBag si hubo un RedirectToAction (no hay ViewBag entre Actions)
            if (TempData.ContainsKey("Msg"))
            {
                _controllerBag = (ControllerBag)TempData["Msg"];
            }

            if ((Request.Cookies[".ASPXAUTH"] != null || Request.Cookies["AuthCookie_Intra"] != null) && (Session["DatosDeLogin"] == null || ((DatosDeLogin)Session["DatosDeLogin"]).UsuarioId == 1))
            {
                DatosDeLogin datosDeLogin = null;
                if (Request.Cookies[".ASPXAUTH"] != null) //si usa cookie propia
                {
                    datosDeLogin = _usuariosServicio.ConfirmarCookie(Server.HtmlEncode(Request.Cookies[".ASPXAUTH"].Value), ref _controllerBag);
                } 
                else //si usa cookie de la intra
                {
                    datosDeLogin = _usuariosServicio.ConfirmarCookie(Server.HtmlEncode(Request.Cookies["AuthCookie_Intra"].Value), ref _controllerBag);
                }

                if (datosDeLogin.UsuarioId > 1)
                {
                    Session.Add("DatosDeLogin", datosDeLogin);
                    TempData["EsMasterAdmin"] = datosDeLogin.EsMasterAdmin;
                    GetServicio().SetDatosDeLogin(datosDeLogin);
                    if (datosDeLogin != null)
                        TempData["EsMasterAdmin"] = datosDeLogin.EsMasterAdmin;

                }
                else //si no trajo datos válidos, reseteo la cookie, la sesión y redirijo al login
                {
                    Response.Cookies[".ASPXAUTH"].Expires = DateTime.Now.AddDays(-1);
                    Session.Abandon();
                    pFilterContext.Result = RedirectToAction("Index", "Home");
                    return;
                }

            }
            else
            {
                DatosDeLogin datosDeLogin = (DatosDeLogin)Session["DatosDeLogin"];
                if (datosDeLogin == null && esAnonima)
                {
                    datosDeLogin = new DatosDeLogin();
                    Session.Add("DatosDeLogin", datosDeLogin);
                }
                if (datosDeLogin != null)
                {
                    TempData["Nombre"] = datosDeLogin.NombreCompleto;
                    GetServicio().SetDatosDeLogin(datosDeLogin);
                    if (datosDeLogin != null)
                        TempData["EsMasterAdmin"] = datosDeLogin.EsMasterAdmin;
                }
                else
                {
                    if (!esAnonima)
                    {
                        pFilterContext.Result = RedirectToAction("Index", "Home");
                        return;
                    }
                }

            }

            Operacion pOp = new Operacion();
            pOp = Operaciones.ActionName(actionName);
            if (((System.Web.Mvc.ReflectedActionDescriptor)pFilterContext.ActionDescriptor).MethodInfo.CustomAttributes.Count() != 0)
            {
                foreach (CustomAttributeData customAttribute in ((System.Web.Mvc.ReflectedActionDescriptor)pFilterContext.ActionDescriptor).MethodInfo.CustomAttributes)
                {
                    if (customAttribute.AttributeType.Name == "OperacionPadre")
                    {
                        pOp = Operaciones.ActionName(customAttribute.ConstructorArguments[0].Value.ToString());
                    }
                }
            }
            
            if (pOp != Operacion.otro)//29/8/18
            {
                GetServicio().PrecargaInicialDeUnaPagina(pOp, ref _controllerBag);
                foreach (Mensaje mensaje in _controllerBag)
                {
                    if (mensaje.Contenido == "La página no existe.")
                    {
                        _controllerBag.Redir = "404";
                    }
                }
                CargarDatosDePagina();
            }
            else
            {
                try
                {
                    CargarDatosDePagina();
                }
                catch (Exception e)
                {
                   
                }
            }
            ViewBag.Operacion = pOp.ToString();

        }

        /// <summary>
        /// Para manejar las excepciones de to do el BaseControladores
        /// </summary>
        /// <param name="pFilterContext"></param>
        protected override void OnException(ExceptionContext pFilterContext)
        {
            pFilterContext.ExceptionHandled = true;
            string controllerName = pFilterContext.RouteData.Values["controller"].ToString();
            string actionName = pFilterContext.RouteData.Values["action"].ToString();
            if (pFilterContext.RouteData.Values["pSeccion"] != null)
            {
                _controllerBag.Seccion = pFilterContext.RouteData.Values["pSeccion"].ToString();
                ViewBag.Seccion = pFilterContext.RouteData.Values["pSeccion"].ToString();
            }
            pFilterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml",
            };
            ViewResult result = (ViewResult)pFilterContext.Result;
            result.ViewBag.ErrorMessage = pFilterContext.Exception.Message;

            DatosDeLogin datosDeLogin = (DatosDeLogin)Session["DatosDeLogin"];
            if (datosDeLogin != null)
            {
                _logErroresServicio.SetDatosDeLogin(datosDeLogin);
            }

            LogErrores log = ArmarLogError(pFilterContext);
            _logErroresServicio.Insert(log, ref _controllerBag);
            result.ViewBag.DatosDeUnaPagina = ViewBag.DatosDeUnaPagina;
        }

        public virtual JsonResult CargarNotificaciones()
        {
            _notificacionesServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            return Json(_notificacionesServicio.CargarNotificaciones(ref _controllerBag), JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult NotificacionVista(int pParam)
        {
            _notificacionesServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            return Json(_notificacionesServicio.NotificacionVista(pParam, ref _controllerBag), JsonRequestBehavior.AllowGet);
        }

        public LogErrores ArmarLogError(ExceptionContext pFilterContext)
        {
            string mensaje = pFilterContext.Exception.Message;
            string accion = pFilterContext.RouteData.Values["action"].ToString();
            string capa = pFilterContext.Exception.Source;
            string metodo = pFilterContext.Exception.TargetSite.Name;
            string machineName = pFilterContext.HttpContext.Server.MachineName;
            string pagina = "";
            try
            {
                pagina = ViewBag.DatosDeUnaPagina.Titulo;

            }
            catch (Exception e)
            {

            }
            if (pFilterContext.RequestContext.HttpContext.Request.UrlReferrer != null)
            {
                pFilterContext.RequestContext.HttpContext.Request.UrlReferrer.ToString();
            }

            var stackTrace = new StackTrace(pFilterContext.Exception, true);
            var frame = stackTrace.GetFrame(0);
            string linea = frame.GetFileLineNumber().ToString();
            int numeroDeError = pFilterContext.Exception.HResult;
            LogErrores log = new LogErrores() { MensajeDeError = mensaje, Accion = accion, Capa = capa, Metodo = metodo, MachineName = machineName, Pagina = pagina, LineaDeError = linea, NumeroDeError = numeroDeError };
            return log;
        }
        /// <summary>
        /// Esta función se llama LUEGO de ejecutar cada action.
        /// </summary>
        /// <param name="pFilterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext pFilterContext)
        {
            base.OnActionExecuted(pFilterContext);

            if (pFilterContext.Result.GetType() == typeof(ViewResult))
            {
                ViewResult viewResult = (ViewResult)pFilterContext.Result;

                var atributes = pFilterContext.ActionDescriptor.GetCustomAttributes(false);
                bool esAnonima = false;
                if (_controllerBag.Redir != "")
                {
                    if (_controllerBag.Redir == "404")
                    {
                        pFilterContext.Result = new ViewResult
                        {
                            ViewName = "NoPagina",
                            ViewData = viewResult.ViewData,
                            TempData = viewResult.TempData
                        };
                    }

                    _controllerBag.Clear();
                }
                else
                {
                    foreach (var atribute in atributes)
                    {
                        if (atribute.ToString() == "System.Web.Mvc.OverrideAuthorizationAttribute")
                        {
                            esAnonima = true;
                        }
                    }
                    if (!_controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina && !esAnonima)
                    {
                        pFilterContext.Result = new ViewResult
                        {
                            ViewName = "NoPermisos",
                            ViewData = viewResult.ViewData,
                            TempData = viewResult.TempData
                        };
                    }
                }



                ViewResult result = (ViewResult)pFilterContext.Result;
                result.ViewBag.Msg = _controllerBag;
            }
        }

        /// <summary>
        /// "sobreescribo" el RedirectToAction original para que siempre setee el _controllerBag, no fue magia
        /// </summary>
        /// <param name="pActionName"></param>
        /// <returns></returns>
        new protected RedirectToRouteResult RedirectToAction(string pActionName)
        {
            TempData["Msg"] = _controllerBag;
            return base.RedirectToAction(pActionName);
        }
        new protected RedirectToRouteResult RedirectToAction(string pActionName, object pRouteValue)
        {
            TempData["Msg"] = _controllerBag;
            return base.RedirectToAction(pActionName, pRouteValue);
        }

        new protected RedirectToRouteResult RedirectToAction(string pActionName, string pControllerName)
        {
            TempData["Msg"] = _controllerBag;
            return base.RedirectToAction(pActionName, pControllerName);
        }

        new protected RedirectToRouteResult RedirectToAction(string pActionName, string pControllerName, object pRouteValue)
        {
            TempData["Msg"] = _controllerBag;
            return base.RedirectToAction(pActionName, pControllerName, pRouteValue);
        }

        protected void CargarDDLs(VM pObj, bool? pActivos)
        {
            //Consigo los tipos de return de los metodos y las propiedades
            List<PropertyInfo> props = pObj.GetType().GetProperties().ToList();
            List<MethodInfo> methods = GetServicio().GetType().GetMethods().Where(x => x.GetCustomAttribute<ListadoDDL>() != null).ToList();
            //Busco en las propiedades una que sea una lista
            foreach (PropertyInfo prop in props)
                if (prop.PropertyType.Name == typeof(List<>).Name)
                {
                    //busco en los metodos del servicio que devuelva un IEnumerable que sean mapeable con la propiedad actual
                    var tipoDest = prop.PropertyType.GetGenericArguments().FirstOrDefault();
                    foreach (MethodInfo method in methods)
                    {
                        var tipoSource = method.ReturnType.GetGenericArguments().FirstOrDefault();
                        if (tipoSource != null && tipoDest != null)
                        {
                            //Pruebo si existe un mapeo valido entre el metodo y el propiedades.
                            if (BaseGlobal.ExisteMapa(tipoSource, tipoDest))
                            {
                                int targetId = 0;
                                if (prop.GetCustomAttributes(typeof(Campo), false).Cast<Campo>().Count() != 0)
                                {
                                    string targetField = prop.GetCustomAttributes(typeof(Campo), false).Cast<Campo>().First().Value();
                                    targetId = (int)pObj.GetType().GetProperty(targetField).GetValue(pObj);
                                }
                                object[] parametros = { _controllerBag, pActivos, targetId };
                                object source = method.Invoke(GetServicio(), parametros);
                                var dest = Activator.CreateInstance(prop.PropertyType);
                                Mapper.Map(source, dest, method.ReturnType, prop.PropertyType);
                                prop.SetValue(pObj, dest);
                            }
                        }
                    }
                }
        }
        /// <summary>
        /// Devuelve True si no tiene permisos
        /// </summary>
        /// <returns></returns>
        protected bool NoTienePermiso(string pPermiso)
        {
            //TODO: Ver logica de esto
            return false;
        }
        protected void CargarDatosDePagina()
        {
            if (_controllerBag.DatosDeUnaPagina != null)
            {
                ViewBag.DatosDeUnaPagina = _controllerBag.DatosDeUnaPagina;
                DatosDeLogin datosDeLogin = (DatosDeLogin)Session["DatosDeLogin"];
                ViewBag.Contexto = datosDeLogin.Contexto;
                ViewBag.Roles = datosDeLogin.RolesDeUsuario;
            }
            else
            {
                _controllerBag.DatosDeUnaPagina = new DatosDeUnaPagina();
                ViewBag.DatosDeUnaPagina = _controllerBag.DatosDeUnaPagina;
                DatosDeLogin datosDeLogin = (DatosDeLogin)Session["DatosDeLogin"];
                ViewBag.Contexto = datosDeLogin.Contexto;
            }
        }

        protected string AccionAnterior()
        {
            string retorno = Request.UrlReferrer.LocalPath.ToString();
            int aux = retorno.IndexOf("/", 1);
            if (aux > 0)
            {
                retorno = retorno.Substring(aux + 1);
            }
            else
            {
                retorno = "Index";
            }
            return retorno;
        }

        protected string ControllerAnterior()
        {

            string retorno = Request.UrlReferrer.LocalPath.ToString();
            int aux = retorno.IndexOf("/", 1);
            if (aux > 0)
            {
                retorno = retorno.Substring(1, aux - 1);
            }
            else
            {
                retorno = "Home";
            }
            return retorno;
        }


        [HttpPost]
        public virtual ActionResult ObtenerDatos(DatatableParameters parameters)
        {
            ListParams listParams = new ListParams();
            //listParams.activo = parameters.activos;
            listParams.filtro = parameters.search.value == null ? "" : parameters.search.value;
            listParams.ordenarPor = parameters.headers[parameters.order[0].column].field;
            listParams.sentido = (parameters.order[0].dir == "asc");
            listParams.RegistrosPorPagina = parameters.length;
            listParams.NumeroDePagina = parameters.start / parameters.length + 1;

            //si tiene filtros armo el diccionario para mandarle al servicio
            Dictionary<String, String> filtros = new Dictionary<string, string>();
            if (parameters.filtros != null)
            {
                foreach (var filtro in parameters.filtros)
                {
                    if (filtro.value != null && filtro.value == "null")
                    {
                        filtro.value = null;
                    }
                    else
                    {
                        if (filtro.value != null && filtro.value == "")
                        {
                            filtro.value = "-1";
                        }
                    }
                    filtros.Add(filtro.key, filtro.value);
                }
            }

            List<ModeloExt> source = GetServicio().Listado(filtros, ref listParams, ref _controllerBag).ToList();
            List<VMExt> destination = Mapper.Map<List<ModeloExt>, List<VMExt>>(source);

            DatosDeListado listado = new DatosDeListado(destination, parameters);
            listado.draw = parameters.draw;
            listado.recordsTotal = listParams.TotalDeRegistros;
            listado.recordsFiltered = listParams.TotalDeRegistros;

            return Json(listado);
        }

        public FileResult Exportar(Dictionary<String, String> filtros)
        {
            List<ModeloExt> source = GetServicio().Listado(ref _controllerBag).ToList();
            List<VMExt> destination = Mapper.Map<List<ModeloExt>, List<VMExt>>(source);
            string nombreArchivo = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortTimeString() + "_" + new VMExt().GetType().Name + ".xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(FExportar.ExportarExcel(destination).ToArray(), contentType, nombreArchivo);
        }

        public class DatosDeListado
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<List<String>> data { get; set; }

            public DatosDeListado(List<VMExt> datos, DatatableParameters parameters)
            {
                data = new List<List<String>>();
                foreach (VMExt registro in datos)
                {
                    List<String> fila = new List<String>();
                    foreach (Header header in parameters.headers)
                    {
                        Object valor = typeof(VMExt).GetProperty(header.field).GetValue(registro);
                        bool visible = true;
                        if (header.visibleField != null)
                        {
                            visible = (bool)typeof(VMExt).GetProperty(header.visibleField).GetValue(registro);
                        }

                        if (valor != null && visible)
                        {
                            if (header.mask != null)
                            {
                                fila.Add(header.mask.Replace("{VAL}", valor.ToString()));
                            }
                            else
                            {
                                fila.Add(valor.ToString());
                            }
                        }
                        else
                        {
                            fila.Add("");
                        }
                    }
                    data.Add(fila);
                }
            }
        }

        public ActionResult testGentPDF()
        {
            InformesVM model = new InformesVM()
            {
                Activo = true,
                CategoriaDeInforme = "Alta Categoria",
                CategoriaDeInformeId = 1,
                FechaDeInforme = new DateTime(2019, 2, 23),
                Observaciones = "Obersvando ando",
                Texto = "Un texto de demostracion para mostrar mi dominancia .net",
                Titulo = "LOOK AT THIS SHIT BRA"
            };
            //string htmlText = RenderViewToString(ControllerContext, "~/Views/Informes/Registro.cshtml", model);



            var Renderer = new IronPdf.HtmlToPdf();
            //var PDF = Renderer.RenderHtmlAsPdf("<h1 style='size:500px'> &#8501 </h1>");
            //var PDF = Renderer.RenderHtmlAsPdf(htmlText);
            string path = HttpRuntime.AppDomainAppPath;

            string html = System.IO.File.ReadAllText(path + "/TestPDF.html");
            string tabla = "<table style='width:100%'>" +
                                "<tr>" +
                                    "<th>Nombre</th>" +
                                    "<th>Año</th>" +
                                    "<th>Cantidad de casos</th>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>Pablo</td>" +
                                    "<td>1990</td>" +
                                    "<td>2404</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>Marta</td>" +
                                    "<td>1785</td>" +
                                    "<td>12</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>Javier</td>" +
                                    "<td>2012</td>" +
                                    "<td>878</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>Ernesto</td>" +
                                    "<td>1991</td>" +
                                    "<td>8791</td>" +
                                "</tr>" +
                           "</table> ";
            html = html.Replace("$tabla$", tabla);
            var PDF = Renderer.RenderHtmlAsPdf(html);
            //var PDF = Renderer.RenderHTMLFileAsPdf(path );

            var OutputPath = @"D:\Repo\Particular-Core\Repositorio_SI2019_ParticularCore\trunk\ProyectoParticular\HtmlToPDF.pdf";


            PDF.SaveAs(OutputPath);
            FileStream fileStream = new FileStream(OutputPath, FileMode.Open, FileAccess.Read);

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return File(fileStream, "application/pdf");
        }


        static string RenderViewToString(ControllerContext context, string viewPath, object model = null, bool partial = false)
        {
            // first find the ViewEngine for this view
            ViewEngineResult viewEngineResult = null;
            if (partial)
                viewEngineResult = ViewEngines.Engines.FindPartialView(context, viewPath);
            else
                viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null);

            if (viewEngineResult == null)
                throw new FileNotFoundException("View cannot be found.");

            // get the view and attach the model to view data
            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view,
                    context.Controller.ViewData,
                    context.Controller.TempData,
                    sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }
        //Override para asignarle el maxJsonLength para que funcione el -Todos- los registros
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }

        public JsonResult RecargarDDL()
        {
            VM vm = new VM();
            CargarDDLs(vm, null);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        //IMPORTANTE HERRAMIENTA NO BORRAR

        //public object GetInstance(string FullyQualifiedNameOfClass)

        //{
        //    Type type = Type.GetType(FullyQualifiedNameOfClass);
        //    if (type != null)
        //        return Activator.CreateInstance(type);
        //    foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        //    {
        //        type = asm.GetType(FullyQualifiedNameOfClass);
        //        if (type != null)
        //            return Activator.CreateInstance(type);
        //    }
        //    return null;
        //}
        public class DatatableParameters
        {
            public bool activos { get; set; }
            public int draw { get; set; }
            public int length { get; set; }
            public int start { get; set; }
            public Search search { get; set; }
            public List<Order> order { get; set; }
            public List<Columna> columns { get; set; }
            public List<Filtro> filtros { get; set; }
            public List<Header> headers { get; set; }
        }
        public class Filtro
        {
            public string key { get; set; }
            public string value { get; set; }
        }
        public class Columna
        {
            public int data { get; set; }
            public string name { get; set; }
            public bool orderable { get; set; }
            public bool searchable { get; set; }
            public Search search { get; set; }
        }
        public class Search
        {
            public bool regex { get; set; }
            public string value { get; set; }
        }
        public class Header
        {
            public string field { get; set; }
            public string visibleField { get; set; }
            public string mask { get; set; }
        }
        public class Order
        {
            public int column { get; set; }
            public string dir { get; set; }
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class OperacionPadre : Attribute
    {
        private string _target;

        public OperacionPadre(string target)
        {
            _target = target;
        }

        public string Value()
        {
            return _target;
        }
    }
}