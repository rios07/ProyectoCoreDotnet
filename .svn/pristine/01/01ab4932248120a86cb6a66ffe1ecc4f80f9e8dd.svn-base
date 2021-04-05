using FuncionesCore;
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
    public interface IRelAsig_CuentasDeEnvios_A_TablasServicio : IBaseServicios<RelAsig_CuentasDeEnvios_A_Tablas, RelAsig_CuentasDeEnvios_A_TablasExt>
    {

    }
    public class RelAsig_CuentasDeEnvios_A_TablasServicio : BaseServicios<RelAsig_CuentasDeEnvios_A_Tablas, RelAsig_CuentasDeEnvios_A_TablasExt>, IRelAsig_CuentasDeEnvios_A_TablasServicio
    {
        private IRelAsig_CuentasDeEnvios_A_TablasRepositorio _relAsig_CuentasDeEnvios_A_TablasRepositorio;
        private ITablasRepositorio _tablasRepositorio;
        private ICuentasDeEnviosRepositorio _cuentasDeEnviosRepositorio;

        public RelAsig_CuentasDeEnvios_A_TablasServicio(IRelAsig_CuentasDeEnvios_A_TablasRepositorio pRelAsig_CuentasDeEnvios_A_TablasRepositorio,ITablasRepositorio pTablasRepositorio, ICuentasDeEnviosRepositorio pCuentasDeEnviosRepositorio)
        {
            _relAsig_CuentasDeEnvios_A_TablasRepositorio = pRelAsig_CuentasDeEnvios_A_TablasRepositorio;
            _tablasRepositorio = pTablasRepositorio;
            _cuentasDeEnviosRepositorio = pCuentasDeEnviosRepositorio;
        }

        public override IRepositorio<RelAsig_CuentasDeEnvios_A_Tablas, RelAsig_CuentasDeEnvios_A_TablasExt> GetRepositorio()
        {
            return _relAsig_CuentasDeEnvios_A_TablasRepositorio;
        }

        public override void SetDatosDeLogin(DatosDeLogin pDatosDeLogin)
        {
            _tablasRepositorio.SetDatosDeLogin(pDatosDeLogin);
            _cuentasDeEnviosRepositorio.SetDatosDeLogin(pDatosDeLogin);
            base.SetDatosDeLogin(pDatosDeLogin);
        }

        [ListadoDDL]
        public List<TablasExt> TablasDLL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<TablasExt>)_tablasRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }

        [ListadoDDL]
        public List<CuentasDeEnviosExt> CuentasDLL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            return (List<CuentasDeEnviosExt>)_cuentasDeEnviosRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }
    }

}
