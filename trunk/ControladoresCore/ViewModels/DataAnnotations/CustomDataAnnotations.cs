using System;
using System.ComponentModel.DataAnnotations;

namespace CustomDataAnnotations
{
    public class FechaValidaAttribute : ValidationAttribute
    {
        public FechaValidaAttribute() : base("Fecha No valida")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var FechaMinima = new DateTime(1753, 01, 01);
            var FechaMaxima = new DateTime(9999, 01, 01);
            var FechaActual = (DateTime) value;
            if (FechaActual < FechaMinima || FechaActual > FechaMaxima)
            {
                var ErrorMessage = "La Fecha no es   ";
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Campo : Attribute
    {
        private readonly string _target;

        public Campo(string target)
        {
            _target = target;
        }

        public string Value()
        {
            return _target;
        }
    }
}