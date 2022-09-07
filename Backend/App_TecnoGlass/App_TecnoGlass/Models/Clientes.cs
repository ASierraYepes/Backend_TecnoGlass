using System.ComponentModel.DataAnnotations;

namespace App_TecnoGlass.Models
{
    public class Clientes
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public string nacionalidad { get; set; }
        [Required]
        public string correo { get; set; }
        
    }
}
