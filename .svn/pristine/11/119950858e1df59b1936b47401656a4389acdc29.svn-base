using ModelosCore;
using RepositoriosCore;
using ServiciosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore
{
    public interface IRolesDeUsuariosServicio : IBaseServicios<RolesDeUsuarios, RolesDeUsuariosExt>
    {

    }

    public class RolesDeUsuarioServicio : BaseServicios<RolesDeUsuarios, RolesDeUsuariosExt>, IRolesDeUsuariosServicio
    {
        private IRolesDeUsuariosRepositorio _RolesDeUsuariosRepositorio;

        public RolesDeUsuarioServicio(IRolesDeUsuariosRepositorio pRolesDeUsuariosRepositorio)
        {
            _RolesDeUsuariosRepositorio = pRolesDeUsuariosRepositorio;
        }

        public override IRepositorio<RolesDeUsuarios, RolesDeUsuariosExt> GetRepositorio()
        {
            return _RolesDeUsuariosRepositorio;
        }
    }

}