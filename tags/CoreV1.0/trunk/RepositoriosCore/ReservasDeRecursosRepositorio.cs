using System;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IReservasDeRecursosRepositorio : IRepositorio<ReservasDeRecursos, ReservasDeRecursosExt>
    {
        int AprobarReserva(int pParam,string pObservacionesDelAprobador, ref ControllerBag pControllerBag);
        string CheckearDisponibilidad(int pRecursoId, DateTime pFechaDeInicio, DateTime pFechaLimite, ref ControllerBag pControllerBag);
    }

    public class ReservasDeRecursosRepositorio : BaseRepositorios<ReservasDeRecursos, ReservasDeRecursosExt>, IReservasDeRecursosRepositorio
    {
        public ReservasDeRecursosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {

        }

        public int AprobarReserva(int pParam, string pObservacionesDelAprobador,ref ControllerBag pControllerBag)
        {
            object obj = new {id = pParam, ObservacionesDelAprobador = pObservacionesDelAprobador, ReservaAprobada=true};
            return CustomExecute(obj, "usp_ReservasDeRecursos__Update_Aprobacion", ref pControllerBag);
           
        }

        public string CheckearDisponibilidad(int pRecursoId, DateTime pFechaDeInicio, DateTime pFechaLimite, ref ControllerBag pControllerBag)
        {
            object obj = new
            {
                RecursoId = pRecursoId,
                FechaDeInicio = pFechaDeInicio,
                FechaLimite = pFechaLimite
            };
            var ret = CustomExecute(obj, "usp_ReservasDeRecursos__RecursoDisponible", ref pControllerBag);

            return ret.ToString();
        }
    }
}
