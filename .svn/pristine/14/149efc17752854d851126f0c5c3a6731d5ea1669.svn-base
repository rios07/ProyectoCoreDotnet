using FuncionesCore;

namespace ModelosCore
{
    public class Contactos : BaseModelo
    {
        public bool EsUnaOrganizacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Alias { get; set; }
        public string RelacionConElContacto { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
        public string Url { get; set; }
        public string Observaciones { get; set; }
        public string Organizacion { get; set; }

        //[Ignorar(Operacion.insert)]
        //[Ignorar(Operacion.update)]
        //public int GrupoDeContactoId { get; set; }-
        public override bool Valido(ref ControllerBag pControllerBag)
        {
            return true;
        }

        public override AnularEliminar PermiteAnularEliminarValido()
        {
            return AnularEliminar.eliminar;
        }
    }

    public class ContactosExt : Contactos
    {
        public string TiposDeContacto { get; set; }
        public string GruposDeContacto { get; set; }

        public string TipoDeContactoIdsString { get; set; }

        //public bool Activo { get; set; }
        public string GrupoDeContactoIdsString { get; set; }
    }
}