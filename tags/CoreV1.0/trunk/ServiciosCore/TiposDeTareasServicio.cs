using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore
{
    public interface ITiposDeTareasServicio : IBaseServicios<TiposDeTareas, TiposDeTareasExt>
    {

    }
    public class TiposDeTareasServicio : BaseServicios<TiposDeTareas, TiposDeTareasExt>, ITiposDeTareasServicio
    {
        private ITiposDeTareasRepositorio _TiposDeTareasRepositorio;

        public TiposDeTareasServicio(ITiposDeTareasRepositorio pTiposDeTareasRepositorio)
        {
            _TiposDeTareasRepositorio = pTiposDeTareasRepositorio;
        }

        public override IRepositorio<TiposDeTareas, TiposDeTareasExt> GetRepositorio()
        {
            return _TiposDeTareasRepositorio;
        }
    }

}
