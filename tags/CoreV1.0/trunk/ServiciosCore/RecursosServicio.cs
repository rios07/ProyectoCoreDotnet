using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ServiciosCore;

namespace ServiciosCore
{
    public interface IRecursosServicio : IBaseServicios<Recursos, RecursosExt>
    {
        bool EsResponsableDelRecurso(int pRecursoId, ref ControllerBag pControllerBag);
    }

    public class RecursosServicio : BaseServicios<Recursos, RecursosExt>, IRecursosServicio
    {
        private IRecursosRepositorio _RecursosRepositorio;
        private IUsuariosRepositorio _usuariosRepositorio;
        private IRelAsig_Usuarios_A_RecursosRepositorio _relAsigUsuariosARecursosRepositorio;

        public RecursosServicio(IRecursosRepositorio pRecursosRepositorio,
                                IUsuariosRepositorio pUsuariosRepositorio,
                                IRelAsig_Usuarios_A_RecursosRepositorio pRelAsigUsuariosARecursosRepositorio)
        {
            _RecursosRepositorio = pRecursosRepositorio;
            _usuariosRepositorio = pUsuariosRepositorio;
            _relAsigUsuariosARecursosRepositorio = pRelAsigUsuariosARecursosRepositorio;
        }

        public override IRepositorio<Recursos, RecursosExt> GetRepositorio()
        {
            return _RecursosRepositorio;
        }

        
        [ListadoDDL]
        public List<UsuariosExt> UsuariosDDL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _usuariosRepositorio.SetDatosDeLogin(_RecursosRepositorio.GetDatosDeLogin());
            return (List<UsuariosExt>) _usuariosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        public bool EsResponsableDelRecurso(int pRecursoId, ref ControllerBag pControllerBag)
        {
            return _RecursosRepositorio.EsResponsableDelRecurso(pRecursoId,ref pControllerBag);
            
        }
    }

}