using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vuelos.Models
{
    public class ClaseVuelo
    {
        public int Id { get; set; }

        [Display(Name = "Horario de llegada")]
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }
        [Required (ErrorMessage = "Ingrese el número de vuelo")]
        [RegularExpression("^[A-Z]{2}( [0-9]{4})$", ErrorMessage = "Solo se permiten caracteres en mayuscula (2) [espacio] numeros(4)")]
        //SOLO PERMITE COMBINACION DE A-Z un espacio Y LUEGO 0-9 ^ principio $ fin 
        [StringLength(7, MinimumLength = 7 , ErrorMessage = "Solo se permiten 7 caracteres")]
        public string Vuelo { get; set; }
        [Required (ErrorMessage = "Ingrese la línea aérea")]
        [Display(Name = "Línea Aérea")]
        [StringLength(60, MinimumLength = 3 , ErrorMessage = "Mínimo de caracteres permitidos 3")]
        [RegularExpression("^[a-zA-Z]*$" , ErrorMessage ="Solo se permiten caracteres en mayuscula o minuscula")]
        public string Linea_Aerea { get; set; }
        public bool Demorado { get; set; }
    }
}
