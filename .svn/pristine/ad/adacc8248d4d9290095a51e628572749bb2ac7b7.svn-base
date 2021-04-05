using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CustomDataAnnotations
{
    public class FechaValidaAttribute : ValidationAttribute
    {
        public FechaValidaAttribute() : base("Fecha No valida")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime FechaMinima = new DateTime(1753, 01, 01);
            DateTime FechaMaxima = new DateTime(9999, 01, 01);
            DateTime FechaActual = (DateTime)value;
            if ((FechaActual < FechaMinima) || FechaActual > FechaMaxima)
            {
                string ErrorMessage = "La Fecha no es   ";
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
        

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Campo : Attribute
    {
        private string _target;

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
