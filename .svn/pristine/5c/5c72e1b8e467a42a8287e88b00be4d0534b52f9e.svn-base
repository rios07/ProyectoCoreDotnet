using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System.Collections.Generic;
using System.Web.Mvc;
using FuncionesCore;

//hola 
namespace ControladoresCore
{
    public class RecursosController : BaseControladores<Recursos, RecursosExt, RecursosVM>
    {
        private IRecursosServicio _RecursosServicio;
        private IRelAsig_Usuarios_A_RecursosServicio _relAsigUsuariosARecursosServicio;
        public RecursosController(IRecursosServicio pRecursosServicio, 
                                  ILogErroresServicio pLogErroresServicio,
                                  IUsuariosServicio pUsuariosSevicio, 
                                  INotificacionesServicio pNotificacionesServicio,
                                  IRelAsig_Usuarios_A_RecursosServicio pRelAsigUsuariosARecursosServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _RecursosServicio = pRecursosServicio;
            _relAsigUsuariosARecursosServicio = pRelAsigUsuariosARecursosServicio;
        }

        public override IBaseServicios<Recursos, RecursosExt> GetServicio()
        {
            return _RecursosServicio;
        }

        public override ActionResult Insert(RecursosVM pObj)
        {
            var retorno = base.Insert(pObj);
            _relAsigUsuariosARecursosServicio.SetDatosDeLogin(_RecursosServicio.GetDatosDeLogin());
            if (pObj.UsuarioIds != null)
            {
                _relAsigUsuariosARecursosServicio.InsertByUsuarioIdsString(_idInsert, FStrings.ToIdString(pObj.UsuarioIds), ref _controllerBag);
            }
            return retorno;
        }

        public override ActionResult Update(int pParam)
        {
            ViewResult ret = (ViewResult) base.Update(pParam);
            RecursosVM vm = (RecursosVM)ret.ViewData.Model;
            _relAsigUsuariosARecursosServicio.SetDatosDeLogin(_RecursosServicio.GetDatosDeLogin());
            List<RelAsig_Usuarios_A_RecursosExt> relDelRecurso = _relAsigUsuariosARecursosServicio.ResponsablesDeRecurso(vm.Id, ref _controllerBag);
            string idsString = "";
            foreach (RelAsig_Usuarios_A_RecursosExt rel in relDelRecurso)
            {
                idsString += rel.Id + ",";
            }

            int remove = idsString.LastIndexOf(",");
            if (remove != -1)
            {
                idsString = idsString.Remove(remove);
                vm.UsuariosIdsString = idsString;
                ret.ViewData.Model = vm;
            }
           
            return ret;
        }

        public override ActionResult Update(int pParam, RecursosVM pObj)
        {
            var retorno = base.Update(pParam, pObj);
            _relAsigUsuariosARecursosServicio.SetDatosDeLogin(_RecursosServicio.GetDatosDeLogin());
            _relAsigUsuariosARecursosServicio.UpdateByUsuarioIdsString(pParam, FStrings.ToIdString(pObj.UsuarioIds), ref _controllerBag);
            return retorno;
        }
    }
}