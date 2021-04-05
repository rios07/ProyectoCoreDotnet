using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface INotificacionesRepositorio : IRepositorio<Notificaciones, NotificacionesExt>
    {
        List<NotificacionesExt> CargarNotificaciones(ref ControllerBag pControllerBag);
        bool NotificacionVista(int pId, ref ControllerBag pControllerBag);
    }

    public class NotificacionesRepositorio : BaseRepositorios<Notificaciones, NotificacionesExt>,
        INotificacionesRepositorio
    {
        public NotificacionesRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }

        public List<NotificacionesExt> CargarNotificaciones(ref ControllerBag pControllerBag)
        {
            return (List<NotificacionesExt>) CustomMultipleQuery<object, NotificacionesExt>(
                new {pControllerBag.Seccion, TotalDeRegistros = -1,Leida=0}, "usp_Notificaciones__Listado", ref pControllerBag);
        }

        public bool NotificacionVista(int pId, ref ControllerBag pControllerBag)
        {
            UpdateCampo(pId, "Leida", 1, ref pControllerBag);
            return true;
        }

        public class Dummie
        {
        }
    }
}