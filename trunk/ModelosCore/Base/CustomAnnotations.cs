using System;
using FuncionesCore;

namespace ModelosCore.CustomAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class Ignorar : Attribute
    {
        private readonly Operacion _target;

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