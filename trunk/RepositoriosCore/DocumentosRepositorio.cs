using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelosCore;
using RepositoriosCore;
using RepositoriosCore.Base;

namespace RepositoriosCore
{
    public interface IDocumentosRepositorio : IRepositorio<Documentos, Documentos>
    {

    }
    public class DocumentosRepositorio : BaseRepositorios<Documentos, Documentos>, IDocumentosRepositorio
    {
        public DocumentosRepositorio(IConexion pMiConexion) : base(pMiConexion)
        {
        }
    }
}
