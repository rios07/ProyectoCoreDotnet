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
    public interface INotasServicio : IBaseServicios<Notas, NotasExt>
    {

    }

    public class NotasServicio : BaseServicios<Notas, NotasExt>, INotasServicio
    {
        private INotasRepositorio _NotasRepositorio;
        private IIconosCSSRepositorio _iconosCssRepositorio;
        public NotasServicio(INotasRepositorio pNotasRepositorio,
                             IIconosCSSRepositorio pIconosCssRepositorio)
        {
            _NotasRepositorio = pNotasRepositorio;
            _iconosCssRepositorio = pIconosCssRepositorio;
        }

        public override IRepositorio<Notas, NotasExt> GetRepositorio()
        {
            return _NotasRepositorio;
        }

        [ListadoDDL]
        public List<IconosCSSExt> IconosCSSDLL(ref ControllerBag pControllerBag, bool? pActivo, int pId)
        {
            _iconosCssRepositorio.SetDatosDeLogin(_NotasRepositorio.GetDatosDeLogin());
            return (List<IconosCSSExt>) _iconosCssRepositorio.ListadoDDL(ref pControllerBag, pActivo, pId);
        }
    }

}