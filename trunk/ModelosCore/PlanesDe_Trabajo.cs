using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosCore
{
    public class PlanesDe_Trabajo : BaseModelos
    {
        public int ID { get; set; }
        public int Encuestador_Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }

    }

    public class PlanesDe_TrabajoEx : PlanesDe_Trabajo
    {
        public string Encuestador { get; set; }
    }
}
