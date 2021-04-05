using System;
using System.ComponentModel.DataAnnotations;


/*using LocalizeDataAnnotations.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;*/


namespace ModelosCore
{
    // Escribir los Annotations por orden alfabético

    //    https://techclub.formaciontajamar.com/validaciones-con-mvc/
    //    https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_data_annotations.htm

    /// <summary>
    ///     Aquí van los campos exclusivos de la tabla.
    /// </summary>
    // Escribir los Annotations de un mismo Campo por orden alfabético
    public class Cualquiera
    {
        [Display(Name = "Contexto id")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [Key]
        [Range(0, 9999)]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(150)]
        [DataType(DataType.Currency, ErrorMessage = "Introduzca un número")]
        [Compare("Pass", ErrorMessage = "El dato no coincide con el password")]
        public string Pass2 { set; get; }

        [StringLength(50, MinimumLength = 10,
            ErrorMessage = "La propiedad {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        public string NombreUsuario { get; set; }

        public DateTime? FechaEntrada { get; set; }

        [Display(Name = "Fecha(*)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM:yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaDeInforme { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Precio(*)")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Required]
        public decimal Precio { get; set; }

        public string Password { get; set; }
        public string PasswordConfirmacion { get; set; }

        [RegularExpression("\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\b", ErrorMessage = "Mail incorrecto")]
        public string Mail { get; set; }

        [StringLength(20, MinimumLength = 4,
            ErrorMessage = "El nombre de Ciudad debe tener una longitud entre {1} y {2} caracteres")]
        public string Ciudad { get; set; }

        /*[Display(Name = "Apellido", ResourceType = typeof(Textos))]*/
        public string Apellido { get; set; }
    }
}