using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class RelAsig_CuentasDeEnvios_A_TablasController : BaseControladores<RelAsig_CuentasDeEnvios_A_Tablas,
        RelAsig_CuentasDeEnvios_A_TablasExt, RelAsig_CuentasDeEnvios_A_TablasVM>
    {
        private readonly IRelAsig_CuentasDeEnvios_A_TablasServicio _RelAsig_CuentasDeEnvios_A_TablasServicio;

        public RelAsig_CuentasDeEnvios_A_TablasController(
            IRelAsig_CuentasDeEnvios_A_TablasServicio pRelAsig_CuentasDeEnvios_A_TablasServicio,
            ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio,
            INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio,
            pNotificacionesServicio)
        {
            _RelAsig_CuentasDeEnvios_A_TablasServicio = pRelAsig_CuentasDeEnvios_A_TablasServicio;
        }

        public override IBaseServicios<RelAsig_CuentasDeEnvios_A_Tablas, RelAsig_CuentasDeEnvios_A_TablasExt>
            GetServicio()
        {
            return _RelAsig_CuentasDeEnvios_A_TablasServicio;
        }
    }
}