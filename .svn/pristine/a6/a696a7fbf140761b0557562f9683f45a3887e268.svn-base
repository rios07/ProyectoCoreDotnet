using System.Collections.Generic;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface ILogErroresServicio : IBaseServicios<LogErrores, LogErroresExt>
    {
        //IEnumerable<Paginas> GetPaginas();
    }

    public class LogErroresServicio : BaseServicios<LogErrores, LogErroresExt>, ILogErroresServicio
    {
        private readonly ILogErroresRepositorio _logErroresRepositorio;

        //private IPaginasRepositorio PaginasRepositorio;
        private readonly ITablasRepositorio _tablasRepositorio;

        public LogErroresServicio(ILogErroresRepositorio pLogErroresRepositorio, ITablasRepositorio pTablasRepositorio)
        {
            _logErroresRepositorio = pLogErroresRepositorio;
            _tablasRepositorio = pTablasRepositorio;
            //this.CategoriasDeLogErroresRepositorio = CategoriasDeLogErroresRepositorio;
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            base.SetDatosDeLogin(pDatosDeLogin);
            _tablasRepositorio.SetDatosDeLogin(pDatosDeLogin);
        }

        /// <summary>
        ///     Devuelve LogErroresRepositorio para que lo use el Servicio base.
        /// </summary>
        /// <returns></returns>
        public override IRepositorio<LogErrores, LogErroresExt> GetRepositorio()
        {
            return _logErroresRepositorio;
        }

        [ListadoDDL]
        public List<TablasExt> TablasDDL(ref ControllerBag pControllerbag, bool? pActivo, int pId)
        {
            return (List<TablasExt>) _tablasRepositorio.ListadoDDL(ref pControllerbag, pActivo, pId);
        }
    }
}