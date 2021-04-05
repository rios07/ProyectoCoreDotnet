﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ControladoresCore.ViewModels;
using FuncionesCore;
using ModelosCore;
using ServiciosCore;

namespace ControladoresCore.Base
{
    /// <summary>
    /// llename gato(Femaldi)
    /// </summary>
    /// <typeparam name="Modelo"></typeparam>
    /// <typeparam name="ModeloExt"></typeparam>
    /// <typeparam name="VM"></typeparam>
    public abstract class ArchivosManagerController<Modelo, ModeloExt, VM> : BaseControladores<Modelo, ModeloExt, VM> where Modelo : BaseModelo, new() where ModeloExt : Modelo where VM : BaseVM, new()
    {
        private IArchivosServicio _archivosServicio;
        private ILogErroresServicio _pLogErroresServicio;
        private IUsuariosServicio _pUsuariosSevicio;
        private INotificacionesServicio _pNotificacionesServicio;

        public ArchivosManagerController(ILogErroresServicio pLogErroresServicio, IUsuariosServicio pUsuariosServicio, IArchivosServicio pArchivosServicio, INotificacionesServicio pNotificacionesServicio) : base(pLogErroresServicio, pUsuariosServicio, pNotificacionesServicio)
        {
            _archivosServicio = pArchivosServicio;

        }



        [HttpPost]
        public ActionResult UpdateAdjuntos(int pParam, VM pObj, List<ArchivosVM> pArchivos)
        {

            var result = base.Update(pParam, pObj);
            if (pArchivos != null)
            {
                string tabla = new Modelo().GetType().Name;
                GuardarArchivos(pArchivos, pParam, tabla);
            }
            return result; //Devuelvo el resultado del update común
        }

        //Guardado generico de archivos
        public bool GuardarArchivos(List<ArchivosVM> archivosVM, int pId, string pTabla)
        {
            _archivosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            _controllerBag.RutaFisica = HttpContext.Request.MapPath("~/"); //El controlador es el único que sabe de rutas físicas
            List<ArchivosExt> listaArchivo = PrepararArchivo(archivosVM, pId, pTabla);
            _archivosServicio.GuardarArchivos(listaArchivo, ref _controllerBag);
            return true;
        }

        //Guardado usado tipicamente para modulos con archivos especificos que son parte del registro
        public int GuardarArchivoUnico(List<ArchivosVM> archivosVM, int pId, string pTabla)
        {
            _archivosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            _controllerBag.RutaFisica = HttpContext.Request.MapPath("~/"); //El controlador es el único que sabe de rutas físicas
            List<ArchivosExt> listaArchivo = PrepararArchivo(archivosVM, pId, pTabla);
            if (listaArchivo[0].NombreFisicoCompleto == "")
            {
                return -1;
            }
            return _archivosServicio.GuardarArchivoUnico(listaArchivo[0], ref _controllerBag);
        }

        //
        public int GuardarArchivoUnicoNumero(List<ArchivosVM> archivosVM, int pId, string pTabla, int pNumeroArchivo)
        {
            _archivosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            _controllerBag.RutaFisica = HttpContext.Request.MapPath("~/"); //El controlador es el único que sabe de rutas físicas
            List<ArchivosExt> listaArchivo = PrepararArchivoNro(archivosVM, pId, pTabla, pNumeroArchivo);
            if (listaArchivo[0].NombreFisicoCompleto == "")
            {
                return -1;
            }
            return _archivosServicio.GuardarArchivoUnico(listaArchivo[0], ref _controllerBag);
        }

        public List<ArchivosExt> PrepararArchivo(List<ArchivosVM> pListaArchivoVM, int pId, string pTabla)
        {
            List<ArchivosExt> listaArchivos = new List<ArchivosExt>();
            //foreach
            int cantidad = Request.Files.Count;
            int cantidadDeArchivosAceptados = 0;
            for (int i = 0; i < cantidad; i++)
            {
                if (Request.Files[i].FileName != "")
                {
                    ArchivosExt archivo = Mapper.Map<ArchivosVM, ArchivosExt>(pListaArchivoVM[cantidadDeArchivosAceptados]);
                    archivo.File = Request.Files[i];
                    archivo.NombreFisicoCompleto = Path.GetFileName(archivo.File.FileName);

                    archivo.Tabla = pTabla;
                    archivo.RegistroId = pId;
                    listaArchivos.Add(archivo);
                    cantidadDeArchivosAceptados++;
                }


            }

            return listaArchivos;
        }

        public List<ArchivosExt> PrepararArchivoNro(List<ArchivosVM> pListaArchivoVM, int pId, string pTabla, int pNumeroDeArchivo)
        {
            List<ArchivosExt> listaArchivos = new List<ArchivosExt>();
            //foreach
            int cantidad = Request.Files.Count;
            

            if (Request.Files[pNumeroDeArchivo].FileName != "")
            {
                ArchivosExt archivo = Mapper.Map<ArchivosVM, ArchivosExt>(pListaArchivoVM[0]);
                archivo.File = Request.Files[pNumeroDeArchivo];
                archivo.NombreFisicoCompleto = Path.GetFileName(archivo.File.FileName);

                archivo.Tabla = pTabla;
                archivo.RegistroId = pId;
                listaArchivos.Add(archivo);
                
            }




            return listaArchivos;
        }

        public ActionResult BorrarArchivo(int pParam)
        {
            _archivosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            _controllerBag.RutaFisica = HttpContext.Request.MapPath("~/");
            bool retorno = _archivosServicio.BorrarArchivos(pParam, ref _controllerBag);
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateArchivo(ArchivosVM pArchivos)
        {
            _archivosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            _controllerBag.RutaFisica = HttpContext.Request.MapPath("~/");
            ArchivosExt archivos = Mapper.Map<ArchivosVM, ArchivosExt>(pArchivos);
            archivos.Tabla = new Modelo().GetType().Name;
            List<ArchivosExt> archivosLista = new List<ArchivosExt>();
            archivosLista.Add(archivos);
            var result = _archivosServicio.UpdateArchivos(archivosLista, ref _controllerBag);
            return Json(result);
        }

        public virtual JsonResult CargarArchivos(int pRegistroId)
        {
            var tabla = new Modelo().GetType().Name;
            _archivosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            return Json(_archivosServicio.CargarArchivos(tabla, pRegistroId, ref _controllerBag));
        }

        public ArchivosExt CargarArchivoUnico(int pId)
        {
            _archivosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            return _archivosServicio.CargarArchivoUnico(pId, ref _controllerBag);
        }

        public List<ArchivosExt> CargarArchivosTabla(int pRegistroId, string pTabla)
        {
            var tabla = pTabla;
            _archivosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            return _archivosServicio.CargarArchivos(tabla, pRegistroId, ref _controllerBag);
        }

        public ActionResult SwapArchivos(int pRegistroId, int pArchivoId)
        {
            string tabla = new Modelo().GetType().Name;
            _archivosServicio.SetDatosDeLogin(GetServicio().GetDatosDeLogin());
            return Json(_archivosServicio.SwapArchivos(pRegistroId, pArchivoId, tabla, ref _controllerBag));
        }

        public int CambiarCampo(int pId, string pCampo, object pValor, ref ControllerBag pControllerbag)
        {
            return _archivosServicio.CambiarCampo(pId, pCampo, pValor, ref pControllerbag);
        }
    }
}
