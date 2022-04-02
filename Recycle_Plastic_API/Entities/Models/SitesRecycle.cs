using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class SitesRecycle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "is required field")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "is required field")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "is required field")]
        public string CodigoPostal { get; set; }
        [Required(ErrorMessage = "is required field")]
        public string Colonia { get; set; }
    }
}
