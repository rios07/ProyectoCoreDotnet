using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using RepositoriosCore.Base;
using ServiciosCore;

//hola 
namespace ControladoresCore
{
    public class RelAsig_RolesDeUsuarios_A_UsuariosController : BaseControladores<RelAsig_RolesDeUsuarios_A_Usuarios,
        RelAsig_RolesDeUsuarios_A_UsuariosExt, RegistroRolesUsuariosVM>
    {
        private readonly IRelAsig_RolesDeUsuarios_A_UsuariosServicio _rolUsuarioServicio;
        private readonly IUsuariosServicio _usuariosServicio;

        public RelAsig_RolesDeUsuarios_A_UsuariosController(
            IRelAsig_RolesDeUsuarios_A_UsuariosServicio pRolUsuarioServicio, ILogErroresServicio pLogErroresServicio,
            IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(
            pLogErroresServicio, pUsuariosSevicio, pNotificacionesServicio)
        {
            _rolUsuarioServicio = pRolUsuarioServicio;
            _usuariosServicio = pUsuariosSevicio;
        }

        public override IBaseServicios<RelAsig_RolesDeUsuarios_A_Usuarios, RelAsig_RolesDeUsuarios_A_UsuariosExt>
            GetServicio()
        {
            return _rolUsuarioServicio;
        }

        public override ActionResult Listado(string pAvanzado = "")
        {
            if (NoTienePermiso("Cargar"))
            {
                _controllerBag.Add("Usted No tiene Permisos ", true);
                return RedirectToAction("Listado", new Usuarios().GetType().ToString(), null);
            }

            var viewModel = new UsuariosVM();
            //CargarDDLs(viewModel);
            return View(viewModel);
        }

        public override ActionResult Update(int pParam)
        {
            var datosDeLogin = _rolUsuarioServicio.GetDatosDeLogin();
            _usuariosServicio.SetDatosDeLogin(datosDeLogin);
            var usuario = _usuariosServicio.Registro(pParam, ref _controllerBag);
            var retorno = new RegistroRolesUsuariosVM {UsuarioID = usuario.Id};
            CargarDDLs(retorno, true);
            var RolesRetornados = _rolUsuarioServicio.ObtenerRoles(pParam, ref _controllerBag);
            var RolesRetornadosVM =
                Mapper.Map<List<RelAsig_RolesDeUsuarios_A_Usuarios>, List<RelAsig_RolesDeUsuarios_A_UsuariosVM>>(
                    RolesRetornados);
            retorno.Roles = RolesRetornadosVM;
            return View(retorno);
        }

        public override ActionResult Update(int pParam, RegistroRolesUsuariosVM pObj)
        {
            var cambioDeRoles = Mapper.Map<RegistroRolesUsuariosVM, RegistroRolesUsuarios>(pObj);
            foreach (var item in cambioDeRoles.Roles)
                if (item.FechaDesde == null)
                    item.FechaDesde = DateTime.Now;
            _rolUsuarioServicio.UpdateRoles(cambioDeRoles, ref _controllerBag);
            return RedirectToAction("Listado");
        }

        public override ActionResult ObtenerDatos(DatatableParameters parameters)
        {
            var datosDeLogin = _rolUsuarioServicio.GetDatosDeLogin();
            _usuariosServicio.SetDatosDeLogin(datosDeLogin);
            var listParams = new ListParams();
            //listParams.activo = parameters.activos;
            listParams.filtro = parameters.search.value == null ? "" : parameters.search.value;
            listParams.ordenarPor = parameters.headers[parameters.order[0].column].field;
            listParams.sentido = parameters.order[0].dir == "desc";
            listParams.RegistrosPorPagina = parameters.length;
            listParams.NumeroDePagina = parameters.start / parameters.length + 1;

            //si tiene filtros armo el diccionario para mandarle al servicio
            var filtros = new Dictionary<string, string>();
            if (parameters.filtros != null)
                parameters.filtros.ForEach(f => filtros.Add(f.key, f.value != null ? f.value : "-1"));

            var source = _usuariosServicio.Listado(filtros, ref listParams, ref _controllerBag).ToList();
            var destination = Mapper.Map<List<UsuariosExt>, List<UsuariosVM>>(source);


            var listado = new DatosDeListadoUsuarios(destination, parameters);
            listado.draw = parameters.draw;
            listado.recordsTotal = listParams.TotalDeRegistros;
            listado.recordsFiltered = listParams.TotalDeRegistros;

            return Json(listado);
        }

        public ActionResult CargarUsuariosUpdate(int pParam)
        {
            var datosDeLogin = _rolUsuarioServicio.GetDatosDeLogin();
            _usuariosServicio.SetDatosDeLogin(datosDeLogin);
            var usuario = _usuariosServicio.Registro(pParam, ref _controllerBag);
            var retorno = new RegistroRolesUsuariosVM {UsuarioID = usuario.Id};
            CargarDDLs(retorno, true);
            var RolesRetornados = _rolUsuarioServicio.ObtenerRoles(pParam, ref _controllerBag);
            var RolesRetornadosVM =
                Mapper.Map<List<RelAsig_RolesDeUsuarios_A_Usuarios>, List<RelAsig_RolesDeUsuarios_A_UsuariosVM>>(
                    RolesRetornados);
            retorno.Roles = RolesRetornadosVM;
            return Json(retorno);
        }

        public string ObtenerRolesAAgregar(List<RelAsig_RolesDeUsuarios_A_UsuariosVM> pListaDeRoles)
        {
            var retorno = "";
            foreach (var item in pListaDeRoles)
                if (item.Asignado)
                    retorno = retorno + item.RolDeUsuarioId + ",";
            return retorno;
        }

        public class DatosDeListadoUsuarios
        {
            public DatosDeListadoUsuarios(List<UsuariosVM> datos, DatatableParameters parameters)
            {
                data = new List<List<string>>();
                foreach (var registro in datos)
                {
                    var fila = new List<string>();
                    foreach (var header in parameters.headers)
                    {
                        var valor = typeof(UsuariosVM).GetProperty(header.field).GetValue(registro);
                        if (valor != null)
                        {
                            if (header.mask != null)
                                fila.Add(header.mask.Replace("{VAL}", valor.ToString()));
                            else
                                fila.Add(valor.ToString());
                        }
                        else
                        {
                            fila.Add("");
                        }
                    }

                    data.Add(fila);
                }
            }

            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<List<string>> data { get; set; }
        }
    }
}