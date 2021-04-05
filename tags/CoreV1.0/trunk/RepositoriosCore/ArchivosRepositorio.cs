using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionesCore;
using ModelosCore;
using RepositoriosCore.Base;
using System.Transactions;
using System.Drawing;

namespace RepositoriosCore
{
    public interface IArchivosRepositorio : IRepositorio<Archivos, ArchivosExt>
    {
        bool GuardarArchivo(List<ArchivosExt> pArchivo, ref ControllerBag pControllerBag);
        List<ArchivosExt> CargarArchivos(string pTabla, int pRegistroId, ref ControllerBag pControllerBag);
        bool BorrarArchivos(int pArchivoId, ref ControllerBag pControllerBag);
        bool UpdateArchivos(List<ArchivosExt> pArchivos, ref ControllerBag pControllerbag);
        List<ArchivosExt> SwapArchivos(int pRegistroId, int pArchivoId, string pTabla, ref ControllerBag pControllerbag);
        int GuardarArchivoUnico(ArchivosExt ArchivoUnico, ref ControllerBag pControllerbag);
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
            string path = base.Registro(pArchivoId, ref pControllerBag).NombreFisicoCompleto;
            base.Delete(pArchivoId, ref pControllerBag);
            if (File.Exists(pControllerBag.RutaFisica + path))
            {
                File.Delete(pControllerBag.RutaFisica + path);
            }
            return true;
        }

        public List<ArchivosExt> CargarArchivos(string pTabla, int pRegistroId, ref ControllerBag pControllerBag)
        {

            FiltroArchivos Archivo = new FiltroArchivos() { RegistroId = pRegistroId, Tabla = pTabla,Seccion =pControllerBag.Seccion };

            return (List<ArchivosExt>)CustomMultipleQuery<FiltroArchivos, ArchivosExt>(Archivo, "usp_Archivos__Listado", ref pControllerBag);
        }

        public ArchivosExt CargarArchivoUnico(int pId,ref ControllerBag pControllerbag)
        {
            return base.Registro(pId, ref pControllerbag);
        }

        public bool GuardarArchivo(List<ArchivosExt> pListaArchivo, ref ControllerBag pControllerbag)
        {


            using (var transactionScope = new TransactionScope())
            {
                int Cantidad = pListaArchivo.Count;
                for (int i = 0; i < Cantidad; i++)
                {
                    Archivos Archivo = new Archivos(pListaArchivo[i]);

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
                Archivos Archivo = new Archivos(ArchivoUnico);

                ArchivoUnico.Id = base.Insert(Archivo, ref pControllerbag);
                GuardarFisico(ArchivoUnico, ref pControllerbag);

                transactionScope.Complete();
            }

            return ArchivoUnico.Id;
        }

        public bool UpdateArchivos(List<ArchivosExt> pArchivos, ref ControllerBag pControllerBag)
        {
            int Cantidad = pArchivos.Count;
            for (int i = 0; i < Cantidad; i++)
            {
                Archivos archivo = new Archivos(pArchivos[i]);
                base.Update(archivo, ref pControllerBag);
            }

            return true;
        }

        private bool GuardarFisico(ArchivosExt pArchivo, ref ControllerBag pControllerBag)
        {
            ArchivosExt registro = base.Registro(pArchivo.Id, ref pControllerBag);
            string ruta = pControllerBag.RutaFisica + registro.SrcArchivo;
            string carpeta = ruta.Substring(0, ruta.LastIndexOf(@"/"));
            System.IO.Directory.CreateDirectory(carpeta);
            pArchivo.File.SaveAs(ruta);
            if (FImagenes.EsImagen(registro.SrcArchivo))
            {
                Image AuxImg = Image.FromStream(pArchivo.File.InputStream);
                Image thumbnail = FImagenes.MakeThumbnail(AuxImg, 160);
                string rutaTH = FStrings.AgregarSufijo(registro.SrcArchivo, "_th");
                ruta = pControllerBag.RutaFisica + rutaTH;
                thumbnail.Save(ruta);
            }


            return true;
        }

        public List<ArchivosExt> SwapArchivos(int pRegistroId, int pArchivoId, string pTabla, ref ControllerBag pControllerbag)
        {
            object data = new { RegistroId = pRegistroId, SwapOrdenDelRegistroId = pArchivoId, Tabla = pTabla };
            return CustomMultipleQuery<object, ArchivosExt>(data, "usp_Archivos__Listado_y_SwapOrden", ref pControllerbag).ToList();
        }



        public class FiltroArchivos
        {
            public int RegistroId { get; set; }
            public string Tabla { get; set; }
            public DateTime FechaDeEjecucion { get; set; } = DateTime.Now;
            public string Seccion { get; set; }
        }

        public int CambiarCampo(int pId,string pCampo, object pValor,ref ControllerBag pControllerbag)
        {
            return UpdateCampo(pId, pCampo, pValor, ref pControllerbag);
        }
    }
}
