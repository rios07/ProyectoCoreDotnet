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
    public interface IImportacionesServicio : IBaseServicios<Importaciones, ImportacionesExt>
    {

    }
    public class ImportacionesServicio : BaseServicios<Importaciones, ImportacionesExt>, IImportacionesServicio
    {
        private IImportacionesRepositorio _ImportacionesRepositorio;

        public ImportacionesServicio(IImportacionesRepositorio pImportacionesRepositorio)
        {
            _ImportacionesRepositorio = pImportacionesRepositorio;
        }

        public override IRepositorio<Importaciones, ImportacionesExt> GetRepositorio()
        {
            return _ImportacionesRepositorio;
        }
    }

}
