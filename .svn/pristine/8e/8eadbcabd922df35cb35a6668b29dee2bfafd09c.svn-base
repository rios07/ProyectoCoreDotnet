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
    public interface IImportanciasDeTareasServicio : IBaseServicios<ImportanciasDeTareas, ImportanciasDeTareasExt>
    {

    }
    public class ImportanciasDeTareasServicio : BaseServicios<ImportanciasDeTareas, ImportanciasDeTareasExt>, IImportanciasDeTareasServicio
    {
        private IImportanciasDeTareasRepositorio _ImportanciasDeTareasRepositorio;

        public ImportanciasDeTareasServicio(IImportanciasDeTareasRepositorio pImportanciasDeTareasRepositorio)
        {
            _ImportanciasDeTareasRepositorio = pImportanciasDeTareasRepositorio;
        }

        public override IRepositorio<ImportanciasDeTareas, ImportanciasDeTareasExt> GetRepositorio()
        {
            return _ImportanciasDeTareasRepositorio;
        }
    }

}
