using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface INotificacionesServicio : IBaseServicios<Notificaciones, NotificacionesExt>
    {
        List<NotificacionesExt> CargarNotificaciones(ref ControllerBag pControllerBag);
        bool NotificacionVista(int pId, ref ControllerBag pControllerBag);
    }

    public class NotificacionesServicio : BaseServicios<Notificaciones, NotificacionesExt>, INotificacionesServicio
    {
        public NotificacionesServicio(INotificacionesRepositorio notificacionesRepositorio)
        {
            _notificacionesRepositorio = notificacionesRepositorio;
        }

        public INotificacionesRepositorio _notificacionesRepositorio { get; set; }

        public List<NotificacionesExt> CargarNotificaciones(ref ControllerBag pControllerBag)
        {
            return _notificacionesRepositorio.CargarNotificaciones(ref pControllerBag);
        }

        public bool NotificacionVista(int pId, ref ControllerBag pControllerBag)
        {
            return _notificacionesRepositorio.NotificacionVista(pId, ref pControllerBag);
        }

        public override IRepositorio<Notificaciones, NotificacionesExt> GetRepositorio()
        {
            return _notificacionesRepositorio;
        }
    }
}