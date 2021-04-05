using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface ITiposDeContactosRepositorio : IRepositorio<TiposDeContactos, TiposDeContactosExt>
    {
        List<TiposDeContactosExt> ListadoDDLFiltrado(ref ControllerBag pControllerBag);
    }

    public class TiposDeContactosRepositorio : BaseRepositorios<TiposDeContactos, TiposDeContactosExt>,
        ITiposDeContactosRepositorio
    {
        public TiposDeContactosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }

        public List<TiposDeContactosExt> ListadoDDLFiltrado(ref ControllerBag pControllerBag)
        {
            return (List<TiposDeContactosExt>) CustomMultipleQuery<object, TiposDeContactosExt>(
                new {pControllerBag.Seccion}, "usp_TiposDeContactos__ListadoDDLoCBXL_FiltrandoContexto",
                ref pControllerBag);
        }
    }
}