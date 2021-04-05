using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System.Collections.Generic;
using System.Web.Mvc;
using FuncionesCore;
using RepositoriosCore.Base;

//hola 
namespace ControladoresCore
{
    public class GruposDeContactosController : BaseControladores<GruposDeContactos, GruposDeContactosExt, GruposDeContactosVM>
    {
        private IGruposDeContactosServicio _GruposDeContactosServicio;
        private IRelAsig_Contactos_A_GruposDeContactosServicio _relAsigContactosAGruposDeContactosServicio;
        private IContactosServicio _contactosServicio;
        public GruposDeContactosController(IGruposDeContactosServicio pGruposDeContactosServicio, ILogErroresServicio pLogErroresServicio,
                                           IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio,
                                           IRelAsig_Contactos_A_GruposDeContactosServicio pRelAsigContactosAGruposDeContactosServicio,
                                           IContactosServicio pContactosServicio) : base(pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _GruposDeContactosServicio = pGruposDeContactosServicio;
            _relAsigContactosAGruposDeContactosServicio = pRelAsigContactosAGruposDeContactosServicio;
            _contactosServicio = pContactosServicio;
        }

        public override IBaseServicios<GruposDeContactos, GruposDeContactosExt> GetServicio()
        {
            return _GruposDeContactosServicio;
        }

        public override ActionResult Insert(GruposDeContactosVM pObj)
        {
            ActionResult ret = base.Insert(pObj);

            if (pObj.ContactosIds != null)
            {
                _relAsigContactosAGruposDeContactosServicio.SetDatosDeLogin(_GruposDeContactosServicio.GetDatosDeLogin());
                _relAsigContactosAGruposDeContactosServicio.InsertByContactosIdsString(FStrings.ToIdString(pObj.ContactosIds),_idInsert,ref _controllerBag);
            }

            return ret;
        }

        public override ActionResult Update(int pParam, GruposDeContactosVM pObj)
        {
            ActionResult ret = base.Update(pParam, pObj);

            if (pObj.ContactosIds != null)
            {
                _relAsigContactosAGruposDeContactosServicio.SetDatosDeLogin(_GruposDeContactosServicio.GetDatosDeLogin());
                _relAsigContactosAGruposDeContactosServicio.UpdateByContactosIdsString(FStrings.ToIdString(pObj.ContactosIds), pParam, ref _controllerBag);
            }
            else
            {
                _relAsigContactosAGruposDeContactosServicio.SetDatosDeLogin(_GruposDeContactosServicio.GetDatosDeLogin());
                _relAsigContactosAGruposDeContactosServicio.UpdateByContactosIdsString("", pParam, ref _controllerBag);
            }

            return ret;
        }

      

        public override ActionResult Registro(int pParam)
        {
            _contactosServicio.SetDatosDeLogin(_GruposDeContactosServicio.GetDatosDeLogin());
            ActionResult rawObj = base.Registro(pParam);
            if (rawObj.GetType().Name == "ViewResult")
            {
                ViewResult obj = (ViewResult)rawObj;
                GruposDeContactosVM vm = (GruposDeContactosVM)obj.ViewData.Model;
                //---------Filtro por contrato---------//
                Dictionary<string, string> filtroPorContacto = new Dictionary<string, string>
                {
                    {"GrupoDeContactoId", pParam.ToString()}
                };

                ListParams listParams = new ListParams();
                List<ContactosExt> modelItems = (List<ContactosExt>)_contactosServicio.Listado(filtroPorContacto, ref listParams, ref _controllerBag);
                vm.Contactos = Mapper.Map<List<ContactosVM>>(modelItems);
                

                obj.ViewData.Model = vm;
                return obj;
            }
            else
            {
                return rawObj;      
            }
            
        }
    }
}