using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladoresCore
{
    public class ActoresController : BaseControladores<Actores, ActoresExt, ActoresVM>
    {
        IActoresServicio _actoresServicio;

        public ActoresController(IActoresServicio pActoresServicio, ILogErroresServicio pLogErroresServicio,IUsuariosServicio pUsuariosServicio, INotificacionesServicio pNotificacionesServicio) :base(pLogErroresServicio,pUsuariosServicio, pNotificacionesServicio)
        {
            _actoresServicio = pActoresServicio;
        }

        public override IBaseServicios<Actores, ActoresExt> GetServicio()
        {
            return _actoresServicio;
        }
    }
}
