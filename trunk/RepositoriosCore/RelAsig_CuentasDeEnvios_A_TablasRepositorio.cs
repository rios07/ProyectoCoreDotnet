using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface
        IRelAsig_CuentasDeEnvios_A_TablasRepositorio : IRepositorio<RelAsig_CuentasDeEnvios_A_Tablas,
            RelAsig_CuentasDeEnvios_A_TablasExt>
    {
    }

    public class RelAsig_CuentasDeEnvios_A_TablasRepositorio :
        BaseRepositorios<RelAsig_CuentasDeEnvios_A_Tablas, RelAsig_CuentasDeEnvios_A_TablasExt>,
        IRelAsig_CuentasDeEnvios_A_TablasRepositorio
    {
        public RelAsig_CuentasDeEnvios_A_TablasRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}