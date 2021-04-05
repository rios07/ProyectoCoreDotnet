using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore
{
    public interface INotificacionesServicio : IBaseServicios<Notificaciones,NotificacionesExt>
    {
        List<NotificacionesExt> CargarNotificaciones(ref ControllerBag pControllerBag);
        bool NotificacionVista(int pId,ref ControllerBag pControllerBag);
    }

    public class NotificacionesServicio : BaseServicios<Notificaciones, NotificacionesExt>, INotificacionesServicio
    {
        public INotificacionesRepositorio _notificacionesRepositorio { get; set; }

        public NotificacionesServicio(INotificacionesRepositorio notificacionesRepositorio)
        {
            _notificacionesRepositorio = notificacionesRepositorio;
        }

        public List<NotificacionesExt> CargarNotificaciones(ref ControllerBag pControllerBag)
        {
            return _notificacionesRepositorio.CargarNotificaciones(ref pControllerBag);
        }

        public override IRepositorio<Notificaciones, NotificacionesExt> GetRepositorio()
        {
            return _notificacionesRepositorio;
        }

        public bool NotificacionVista(int pId, ref ControllerBag pControllerBag)
        {
            return _notificacionesRepositorio.NotificacionVista(pId,ref pControllerBag);
        }

    }
}
