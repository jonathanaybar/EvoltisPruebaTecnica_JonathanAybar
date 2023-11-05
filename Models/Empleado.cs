using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaEvoltis_JonathanAybar.Models
{
    [Serializable]
    public class Empleado
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string CorreoElectronico { get; set; }

        [Required]
        public decimal Salario { get; set; }
    }
}