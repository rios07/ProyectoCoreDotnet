using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class LogRegistrosController : BaseControladores<LogRegistros, LogRegistrosExt, LogRegistrosVM>
    {
        private readonly ILogRegistrosServicio _LogRegistrosServicio;


        public LogRegistrosController(ILogRegistrosServicio pLogRegistrosServicio,
            ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio,
            INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio,
            pNotificacionesServicio)
        {
            _LogRegistrosServicio = pLogRegistrosServicio;
        }

        public override IBaseServicios<LogRegistros, LogRegistrosExt> GetServicio()
        {
            return _LogRegistrosServicio;
        }
    }
}