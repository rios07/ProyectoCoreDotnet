/* Ordenar por nombre los ussing */
using ControladoresCore.Base;
using ControladoresCore.ViewModels;
using ModelosCore;
using ServiciosCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ControladoresCore
{
    public class PaisesController : BaseControladores<Paises, PaisesVM>
    {
        private IPaisesServicio _paisesServicio;

        public PaisesController(IPaisesServicio pPaisesServicio, ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuarioServicio) : base(pLogErroresServicio, pUsuarioServicio)
        {
            _paisesServicio = pPaisesServicio;
        }

        public override IBaseServicios<Paises, Paises> GetServicio()
        {
            throw new NotImplementedException();
        }

        // GET: Paises
        /*public override ActionResult Index()
        {
            //List<PaisesEx> Paises = PaisesServicio.GetPaises().ToList();
            List<PaisesExt> paises = _paisesServicio.GetAll().ToList();
            return View(paises);
        }*/

        // GET: Paises/Details/#
        /*public override ActionResult Details(int pId)
        {
            Paises pais = _paisesServicio.Get(pId);
            return View(pais);
        }*/

        // GET: Paises/Create
        public override ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paises/Edit/5
        /*public override ActionResult Edit(int pId)
        {
            Paises pais = _paisesServicio.Get(pId);
            return View(pais);
        }*/

        // POST: Paises/Edit/5
        /*[HttpPost]
        public override ActionResult Edit(int pId, PaisesVM pObj)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Paises/Delete/5
        public ActionResult Delete(int pId)
        {
            return View();
        }

        // POST: Paises/Delete/5
        [HttpPost]
        public ActionResult Delete(int pId, FormCollection pCollection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
