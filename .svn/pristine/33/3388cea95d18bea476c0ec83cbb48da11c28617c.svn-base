using FuncionesCore;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore
{
    public interface IArchivosServicio : IBaseServicios<Archivos, ArchivosExt>
    {
        bool GuardarArchivos(List<ArchivosExt> pArchivo, ref ControllerBag pControllerbag);
        List<ArchivosExt> CargarArchivos(string pTabla, int pRegistroId, ref ControllerBag pControllerBag);
        bool BorrarArchivos(int pArchivoId, ref ControllerBag pControllerBag);
        bool UpdateArchivos(List<ArchivosExt> pArchivos, ref ControllerBag pControllerbag);
        List<ArchivosExt> SwapArchivos(int pRegistroId, int pArchivoId, string pTabla, ref ControllerBag pControllerbag);
        int GuardarArchivoUnico(ArchivosExt pArchivo, ref ControllerBag pControllerbag);
        ArchivosExt CargarArchivoUnico(int pId, ref ControllerBag pControllerbag);
        int CambiarCampo(int pId, string pCampo, object pValor, ref ControllerBag pControllerbag);
    }
    public class ArchivosServicio : BaseServicios<Archivos, ArchivosExt>, IArchivosServicio
    {
        private IArchivosRepositorio _archivosRepositorio;

        public ArchivosServicio(IArchivosRepositorio archivosRepositorio)
        {
            _archivosRepositorio = archivosRepositorio;
        }

        public bool GuardarArchivos(List<ArchivosExt> pArchivo, ref ControllerBag pControllerbag)
        {
            return _archivosRepositorio.GuardarArchivo(pArchivo,ref pControllerbag);
        }

        public int GuardarArchivoUnico(ArchivosExt pArchivo, ref ControllerBag pControllerbag)
        {
            return _archivosRepositorio.GuardarArchivoUnico(pArchivo, ref pControllerbag);
        }

        public List<ArchivosExt> CargarArchivos(string pTabla, int pRegistroId, ref ControllerBag pControllerBag)
        {
            return _archivosRepositorio.CargarArchivos(pTabla, pRegistroId, ref pControllerBag);
        }

        public ArchivosExt CargarArchivoUnico(int pId, ref ControllerBag pControllerbag)
        {
            return _archivosRepositorio.CargarArchivoUnico(pId, ref pControllerbag);
        }

        public override IRepositorio<Archivos, ArchivosExt> GetRepositorio()
        {
            return _archivosRepositorio;
        }

        public bool BorrarArchivos(int pArchivoId, ref ControllerBag pControllerBag)
        {
            return _archivosRepositorio.BorrarArchivos(pArchivoId,ref pControllerBag);
        }

        public bool UpdateArchivos(List<ArchivosExt> pArchivos, ref ControllerBag pControllerbag)
        {
            return _archivosRepositorio.UpdateArchivos(pArchivos,ref pControllerbag);
        }

        public List<ArchivosExt> SwapArchivos(int pRegistroId, int pArchivoId, string pTabla, ref ControllerBag pControllerbag)
        {
            return _archivosRepositorio.SwapArchivos(pRegistroId, pArchivoId, pTabla, ref pControllerbag);
        }

        public int CambiarCampo(int pId, string pCampo, object pValor, ref ControllerBag pControllerbag)
        {
            return _archivosRepositorio.CambiarCampo(pId, pCampo, pValor, ref pControllerbag);
        }
    }
}
