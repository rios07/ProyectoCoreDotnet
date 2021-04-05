using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;

namespace ServiciosCore
{
    public interface IReservasDeRecursosServicio : IBaseServicios<ReservasDeRecursos, ReservasDeRecursosExt>
    {
        int AprobarReserva(int pParam,string pObservacionesDelAprobador, ref ControllerBag pControllerBag);
        string CheckearDisponibilidad(int pRecursoId, DateTime pFechaDeInicio, DateTime pFechaLimite, ref ControllerBag pControllerBag);
    }

    public class ReservasDeRecursosServicio : BaseServicios<ReservasDeRecursos, ReservasDeRecursosExt>, IReservasDeRecursosServicio
    {
        private IReservasDeRecursosRepositorio _ReservasDeRecursosRepositorio;
        private IUsuariosRepositorio _usuariosRepositorio;
        private IRecursosRepositorio _recursosRepositorio;
        public ReservasDeRecursosServicio(IReservasDeRecursosRepositorio pReservasDeRecursosRepositorio,
                                          IUsuariosRepositorio pUsuariosRepositorio,
                                          IRecursosRepositorio pRecursosRepositorio)
        {
            _ReservasDeRecursosRepositorio = pReservasDeRecursosRepositorio;
            _usuariosRepositorio = pUsuariosRepositorio;
            _recursosRepositorio = pRecursosRepositorio;

        }

        public override IRepositorio<ReservasDeRecursos, ReservasDeRecursosExt> GetRepositorio()
        {
            return _ReservasDeRecursosRepositorio;
        }

        public int AprobarReserva(int pParam,string pObservacionesDelAprobador, ref ControllerBag pControllerBag)
        {
            return _ReservasDeRecursosRepositorio.AprobarReserva(pParam, pObservacionesDelAprobador,ref pControllerBag);
        }

        public override ReservasDeRecursosExt Registro(int pId, ref ControllerBag pControllerBag)
        {
            ReservasDeRecursosExt obj = base.Registro(pId, ref pControllerBag);
            _recursosRepositorio.SetDatosDeLogin(_ReservasDeRecursosRepositorio.GetDatosDeLogin());
            obj.EsResponsable = _recursosRepositorio.EsResponsableDelRecurso(obj.RecursoId, ref pControllerBag);
            return obj;
        }

        [ListadoDDL]
        public List<UsuariosExt> UsuariosDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _usuariosRepositorio.SetDatosDeLogin(_ReservasDeRecursosRepositorio.GetDatosDeLogin());
            return (List<UsuariosExt>) _usuariosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        [ListadoDDL]
        public List<RecursosExt> RecursosDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _recursosRepositorio.SetDatosDeLogin(_ReservasDeRecursosRepositorio.GetDatosDeLogin());
            return (List<RecursosExt>) _recursosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        public string CheckearDisponibilidad(int pRecursoId, DateTime pFechaDeInicio, DateTime pFechaLimite, ref ControllerBag pControllerBag)
        {
            _ReservasDeRecursosRepositorio.CheckearDisponibilidad(pRecursoId, pFechaDeInicio, pFechaLimite, ref pControllerBag);
            return "fixme";
        }
    }

}