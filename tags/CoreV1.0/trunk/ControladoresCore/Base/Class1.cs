using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FuncionesCore;
using ServiciosCore;

namespace ControladoresCore.Base
{
    public abstract class BaseControladores : Controller
    {
        protected ILogErroresServicio _logErroresServicio;
        protected IUsuariosServicio _usuariosServicio;
        protected ControllerBag _controllerBag;  //private List<Mensaje> _miMsg;
        protected INotificacionesServicio _notificacionesServicio;//TODO: Agregarlo donde corresponda
    }
}
