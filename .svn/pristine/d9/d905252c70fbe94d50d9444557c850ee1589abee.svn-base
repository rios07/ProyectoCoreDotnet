using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System.Collections.Generic;

namespace ServiciosCore
{
    public interface ILogErroresServicio : IBaseServicios<LogErrores, LogErroresExt>
    {
        //IEnumerable<Paginas> GetPaginas();
    }

    public class LogErroresServicio : BaseServicios<LogErrores, LogErroresExt>, ILogErroresServicio
    {
        private ILogErroresRepositorio _logErroresRepositorio;
        //private IPaginasRepositorio PaginasRepositorio;
        private ITablasRepositorio _tablasRepositorio;
        public LogErroresServicio(ILogErroresRepositorio pLogErroresRepositorio,ITablasRepositorio pTablasRepositorio)
        {
            _logErroresRepositorio = pLogErroresRepositorio;
            _tablasRepositorio = pTablasRepositorio;
            //this.CategoriasDeLogErroresRepositorio = CategoriasDeLogErroresRepositorio;
        }

        /// <summary>
        /// Devuelve LogErroresRepositorio para que lo use el Servicio base.
        /// </summary>
        /// <returns></returns>
        public override IRepositorio<LogErrores, LogErroresExt> GetRepositorio()
        {
            return _logErroresRepositorio;
        }

        [ListadoDDL]
        public List<TablasExt> TablasDDL(ref ControllerBag pControllerbag,bool? pActivo,int pId)
        {
            return (List<TablasExt>)_tablasRepositorio.ListadoDDL(ref pControllerbag, pActivo, pId);
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _tablasRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }
    }
}
