using System;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace ServiciosCore
{
    public interface IDocumentosServicio : IBaseServicios<Documentos, Documentos>
    {

    }
    public class DocumentosServicio : BaseServicios<Documentos, Documentos>, IDocumentosServicio
    {
        IDocumentosRepositorio _documentosRepositorio;

        public DocumentosServicio(IDocumentosRepositorio documentosRepositorio)
        {
            _documentosRepositorio = documentosRepositorio;
        }

        public string InsertImagen()
        {
            return null;
        }

        public override IRepositorio<Documentos, Documentos> GetRepositorio()
        {
            throw new NotImplementedException();
        }
    }
}
