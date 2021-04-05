using FuncionesCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosCore.CustomAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class Ignorar : Attribute
    {
        private Operacion _target;

        public Ignorar(Operacion target)
        {
            _target = target;
        }

        public Operacion Value()
        {
            return _target;
        }

       
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class SinSeccion : Attribute
    {

    }
}
