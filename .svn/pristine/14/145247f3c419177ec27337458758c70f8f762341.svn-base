using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FuncionesCore;
using ModelosCore.CustomAnnotations;

namespace ModelosCore
{
    public class Archivos : BaseModelo
    {
        public Archivos(ArchivosExt pArchivo)
        {
            RegistroId = pArchivo.RegistroId;
            NombreFisicoCompleto = pArchivo.NombreFisicoCompleto;
            NombreAMostrar = pArchivo.NombreAMostrar;
            Observaciones = pArchivo.Observaciones;
            Tabla = pArchivo.Tabla;
            Id = pArchivo.Id;

        }

        public Archivos()
        {

        }
        [Ignorar(Operacion.update)]
        public int RegistroId { get; set; }
        [Ignorar(Operacion.update)]
        public string NombreFisicoCompleto { get; set; }
        public string NombreAMostrar { get; set; }
        public string Observaciones { get; set; }
        [Ignorar(Operacion.update)]
        public string Tabla { get; set; }

        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.anular;
        }
    }
    public class ArchivosExt : Archivos
    {
        public HttpPostedFileBase File { get; set; }
        public string Ruta { get; set; }
        public string ImgArchivo { get; set; }
        public string SrcIcono { get; set; }
        public string SrcArchivo  { get; set; }
        public string ProgramaAsociado { get; set; }
        public string Extension { get; set; }
    }
}
