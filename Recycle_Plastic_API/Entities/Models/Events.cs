using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Events
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required field")]
        public string Evento { get; set; }
        [Required(ErrorMessage = "is required field")]
        public string Lugar { get; set; }
        [Required(ErrorMessage = "is required field")]
        public string Organizador { get; set; }
        [Required(ErrorMessage = "is required field")]
        public string Contacto { get; set; }
        public string Fecha { get; set; }

    }
}
