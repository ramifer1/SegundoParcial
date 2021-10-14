using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Modelo
{
    public class Fortuna
    {
        [Key]
        public int SuerteId { get; set; }
        [Required(ErrorMessage = "La Suerte es requerida")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "La Suerte debe contener entre 5 a 60 caracteres")]
        [Display(Name = "Detalle de la Suerte de la persona")]
        public string Detalle { get; set; }
        [Display(Name = "Imagen de la Suerte")]
        [Url]
        public string Imagen { get; set; }
    }
}
