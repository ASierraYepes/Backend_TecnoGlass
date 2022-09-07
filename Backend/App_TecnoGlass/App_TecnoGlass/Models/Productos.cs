using System.ComponentModel.DataAnnotations;

namespace App_TecnoGlass.Models
{
    public class Productos
    {
        public int id { get; set; }
        [Required]
        public int nroOrden { get; set; }
        [Required]
        public string nomProduct { get; set; }
        [Required]
        public string ancho { get; set; }
        [Required]
        public string largo { get; set; }
        [Required]
        public string descripcion { get; set; }
    }
}
