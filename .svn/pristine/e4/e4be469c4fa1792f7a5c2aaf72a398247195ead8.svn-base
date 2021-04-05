using AutoMapper;
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System.Collections.Generic;
using System.Web.Mvc;
//hola 
namespace ControladoresCore
{
    public class TareasController : ArchivosManagerController<Tareas, TareasExt, TareasVM>
    {
        private ITareasServicio _tareasServicio;

        public TareasController(ITareasServicio pTareasServicio,IArchivosServicio pArchivosServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosSevicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosSevicio, pArchivosServicio, pNotificacionesServicio)
        {
            _tareasServicio = pTareasServicio;
        }

        public override IBaseServicios<Tareas, TareasExt> GetServicio()
        {
            return _tareasServicio;
        }

        public override ActionResult Insert(string pTabla = "",int pRegistroId = 1)
        {
            TareasVM viewModel;

            if (TempData.ContainsKey("UltimoRequest"))
            {
                viewModel = (TareasVM)TempData["UltimoRequest"];
            }
            else
            {
                viewModel = new TareasVM();
            }
            viewModel.TablaDeReferencia = pTabla;
            viewModel.RegistroId = pRegistroId;
            CargarDDLs(viewModel, true);

            return View(viewModel);
        }

    }
}

