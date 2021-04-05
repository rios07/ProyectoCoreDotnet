using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Transactions;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;
namespace RepositoriosCore
{
    public interface IArchivosRepositorio : IRepositorio<Archivos, ArchivosExt>
    {
        bool GuardarArchivo(List<ArchivosExt> pArchivo, ref ControllerBag pControllerBag);
        List<ArchivosExt> CargarArchivos(string pTabla, int pRegistroId, ref ControllerBag pControllerBag);
        bool BorrarArchivos(int pArchivoId, ref ControllerBag pControllerBag);
        bool UpdateArchivos(List<ArchivosExt> pArchivos, ref ControllerBag pControllerbag);

        List<ArchivosExt> SwapArchivos(int pRegistroId, int pArchivoId, string pTabla,
            ref ControllerBag pControllerbag);

        int GuardarArchivoUnico(ArchivosExt ArchivoUnico, ref ControllerBag pControllerbag);
        //int GuardarArchivoUnicoAPI(ArchivosExt ArchivoUnico, ref ControllerBag pControllerbag);
        ArchivosExt CargarArchivoUnico(int pId, ref ControllerBag pControllerbag);
        int CambiarCampo(int pId, string pCampo, object pValor, ref ControllerBag pControllerbag);
    }

    public class ArchivosRepositorio : BaseRepositorios<Archivos, ArchivosExt>, IArchivosRepositorio
    {
        public ArchivosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }

        public bool BorrarArchivos(int pArchivoId, ref ControllerBag pControllerBag)
        {
            var path = base.Registro(pArchivoId, ref pControllerBag).NombreFisicoCompleto;
            base.Delete(pArchivoId, ref pControllerBag);
            if (File.Exists(pControllerBag.RutaFisica + path)) File.Delete(pControllerBag.RutaFisica + path);
            return true;
        }

        public List<ArchivosExt> CargarArchivos(string pTabla, int pRegistroId, ref ControllerBag pControllerBag)
        {
            var Archivo = new FiltroArchivos
                {RegistroId = pRegistroId, Tabla = pTabla, Seccion = pControllerBag.Seccion};

            return (List<ArchivosExt>) CustomMultipleQuery<FiltroArchivos, ArchivosExt>(Archivo,
                "usp_Archivos__Listado", ref pControllerBag);
        }

        public ArchivosExt CargarArchivoUnico(int pId, ref ControllerBag pControllerbag)
        {
            return base.Registro(pId, ref pControllerbag);
        }

        public bool GuardarArchivo(List<ArchivosExt> pListaArchivo, ref ControllerBag pControllerbag)
        {
            using (var transactionScope = new TransactionScope())
            {
                var Cantidad = pListaArchivo.Count;
                for (var i = 0; i < Cantidad; i++)
                {
                    var Archivo = new Archivos(pListaArchivo[i]);

                    pListaArchivo[i].Id = base.Insert(Archivo, ref pControllerbag);
                    GuardarFisico(pListaArchivo[i], ref pControllerbag);
                }

                transactionScope.Complete();
            }

            return true;
        }

        public int GuardarArchivoUnico(ArchivosExt ArchivoUnico, ref ControllerBag pControllerbag)
        {
            using (var transactionScope = new TransactionScope())
            {
                var Archivo = new Archivos(ArchivoUnico);
                
               

                ArchivoUnico.Id = base.Insert(Archivo, ref pControllerbag);



                GuardarFisico(ArchivoUnico, ref pControllerbag);

                transactionScope.Complete();
            }

            return ArchivoUnico.Id;
        }

        //public int GuardarArchivoUnicoAPI(ArchivosExt ArchivoUnico, ref ControllerBag pControllerbag)
        //{
        //    using (var transactionScope = new TransactionScope())
        //    {
        //        var Archivo = new Archivos(ArchivoUnico);

        //        ArchivoUnico.Id = base.Insert(Archivo, ref pControllerbag);
        //        GuardarFisico(ArchivoUnico, ref pControllerbag);

        //        transactionScope.Complete();
        //    }

        //    return ArchivoUnico.Id;
        //}

        public bool UpdateArchivos(List<ArchivosExt> pArchivos, ref ControllerBag pControllerBag)
        {
            var Cantidad = pArchivos.Count;
            for (var i = 0; i < Cantidad; i++)
            {
                var archivo = new Archivos(pArchivos[i]);
                base.Update(archivo, ref pControllerBag);
            }

            return true;
        }

        public List<ArchivosExt> SwapArchivos(int pRegistroId, int pArchivoId, string pTabla,
            ref ControllerBag pControllerbag)
        {
            object data = new {RegistroId = pRegistroId, SwapOrdenDelRegistroId = pArchivoId, Tabla = pTabla};
            return CustomMultipleQuery<object, ArchivosExt>(data, "usp_Archivos__Listado_y_SwapOrden",
                ref pControllerbag).ToList();
        }

        public int CambiarCampo(int pId, string pCampo, object pValor, ref ControllerBag pControllerbag)
        {
            return UpdateCampo(pId, pCampo, pValor, ref pControllerbag);
        }

        private bool GuardarFisico(ArchivosExt pArchivo, ref ControllerBag pControllerBag)
        {
            var registro = base.Registro(pArchivo.Id, ref pControllerBag);


           
            var ruta = pControllerBag.RutaFisica + registro.SrcArchivo;
            var carpeta = ruta.Substring(0, ruta.LastIndexOf(@"/"));


         
            Directory.CreateDirectory(carpeta);
            if (pArchivo.File != null)
            {
               

                pArchivo.File.SaveAs(ruta);
                if (FImagenes.EsImagen(registro.SrcArchivo))
                {
                    var AuxImg = Image.FromStream(pArchivo.File.InputStream);
                    var thumbnail = FImagenes.MakeThumbnail(AuxImg, 160);
                    var rutaTH = FStrings.AgregarSufijo(registro.SrcArchivo, "_th");
                    ruta = pControllerBag.RutaFisica + rutaTH;
                    thumbnail.Save(ruta);
                }
            }
            else
            {
               

                File.WriteAllBytes(ruta, pArchivo.FileByteArray);
                if (FImagenes.EsImagen(registro.SrcArchivo))
                {
                    FileStream file = new FileStream(ruta,FileMode.Open);//Lo abro asi porque trae problemas con el image y el ByteArray
                    var AuxImg = Image.FromStream(file);
                    var thumbnail = FImagenes.MakeThumbnail(AuxImg, 160);
                    var rutaTH = FStrings.AgregarSufijo(registro.SrcArchivo, "_th");
                    ruta = pControllerBag.RutaFisica + rutaTH;
                    thumbnail.Save(ruta);
                }

            }
            


            return true;
        }


        public class FiltroArchivos
        {
            public int RegistroId { get; set; }
            public string Tabla { get; set; }
            public DateTime FechaDeEjecucion { get; set; } = DateTime.Now;
            public string Seccion { get; set; }
        }
    }
}