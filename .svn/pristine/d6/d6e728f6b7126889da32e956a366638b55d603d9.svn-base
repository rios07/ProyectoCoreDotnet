using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class ContactosController : BaseControladores<Contactos, ContactosExt, ContactosVM>
    {
        private readonly IContactosServicio _ContactosServicio;
        private readonly IGruposDeContactosServicio _gruposDeContactosServicio;
        private readonly IRelAsig_Contactos_A_GruposDeContactosServicio _relAsigContactosAGruposDeContactosServicio;
        private readonly ITiposDeContactosServicio _tiposDeContactosServicio;

        public ContactosController(IContactosServicio pContactosServicio,
            ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio,
            INotificacionesServicio pNotificacionesServicio,
            ITiposDeContactosServicio pTiposDeContactosServicio,
            IRelAsig_Contactos_A_GruposDeContactosServicio pRelAsigContactosAGruposDeContactosServicio,
            IGruposDeContactosServicio pGruposDeContactosServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _ContactosServicio = pContactosServicio;
            _tiposDeContactosServicio = pTiposDeContactosServicio;
            _relAsigContactosAGruposDeContactosServicio = pRelAsigContactosAGruposDeContactosServicio;
            _gruposDeContactosServicio = pGruposDeContactosServicio;
        }

        public override IBaseServicios<Contactos, ContactosExt> GetServicio()
        {
            return _ContactosServicio;
        }

        public override ActionResult Insert(string pTabla = "", int pRegistroId = 1)
        {
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            return base.Insert(pTabla, pRegistroId);
        }

        public override ActionResult Insert(ContactosVM pObj)
        {
            var ret = base.Insert(pObj);
            if (pObj.TiposDeContactosIds != null)
            {
                _tiposDeContactosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
                _tiposDeContactosServicio.InsertRelaciones(_idInsert, FStrings.ToIdString(pObj.TiposDeContactosIds),
                    ref _controllerBag);
            }

            if (pObj.GrupoDeContactoId != null)
            {
                _relAsigContactosAGruposDeContactosServicio.SetDatosDeLogin(_ContactosServicio.GetDatosDeLogin());
                _relAsigContactosAGruposDeContactosServicio.InsertByGrupoDeContactoId(
                    FStrings.ToIdString(pObj.GrupoDeContactoId), _idInsert, ref _controllerBag);
            }

            return ret;
        }

        public override ActionResult Update(int pParam, ContactosVM pObj)
        {
            var retorno = base.Update(pParam, pObj);
            if (retorno.GetType().Name == "ViewResult") return retorno;
            _tiposDeContactosServicio.SetDatosDeLogin(_ContactosServicio.GetDatosDeLogin());

            if (pObj.TiposDeContactosIds != null)
                _tiposDeContactosServicio.UpdateRelaciones(pParam,
                    FStrings.ToIdString(pObj.TiposDeContactosIds), ref _controllerBag);

            if (pObj.GrupoDeContactoId != null && !pObj.GrupoDeContactoId.Contains(0))
            {
                _relAsigContactosAGruposDeContactosServicio.SetDatosDeLogin(_ContactosServicio.GetDatosDeLogin());
                _relAsigContactosAGruposDeContactosServicio.UpdateByGrupoDeContactoId(
                    FStrings.ToIdString(pObj.GrupoDeContactoId), pParam, ref _controllerBag);
            }
            else
            {
                _relAsigContactosAGruposDeContactosServicio.SetDatosDeLogin(_ContactosServicio.GetDatosDeLogin());
                _relAsigContactosAGruposDeContactosServicio.UpdateByGrupoDeContactoId("", pParam, ref _controllerBag);
            }

            return retorno;
        }


        public override ActionResult Registro(int pParam)
        {
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            _gruposDeContactosServicio.SetDatosDeLogin(_ContactosServicio.GetDatosDeLogin());
            var rawObj = base.Registro(pParam);
            if (rawObj.GetType().Name == "ViewResult")
            {
                var obj = (ViewResult) rawObj;
                var vm = (ContactosVM) obj.ViewData.Model;
                //---------Filtro por contrato---------//
                var filtroPorContacto = new Dictionary<string, string>
                {
                    {"ContactoId", pParam.ToString()}
                };

                var listParams = new ListParams();
                var modelItems =
                    (List<GruposDeContactosExt>) _gruposDeContactosServicio.Listado(filtroPorContacto, ref listParams,
                        ref _controllerBag);
                vm.GruposDelContacto = Mapper.Map<List<GruposDeContactosVM>>(modelItems);


                obj.ViewData.Model = vm;
                return obj;
            }

            return rawObj;
        }

        public override ActionResult Listado(string pParam = "")
        {
            _controllerBag.DatosDeUnaPagina.AutorizadoACargarLaPagina = true;
            return base.Listado(pParam);
        }
    }
}