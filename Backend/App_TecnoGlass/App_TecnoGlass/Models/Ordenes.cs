using System.ComponentModel.DataAnnotations;

namespace App_TecnoGlass.Models
{
    public class Ordenes
    {
        public int id { get; set; }
        [Required]
        public int cliente { get; set; }
        [Required]
        public string fechaOrden  { get; set; }
        [Required]
        public int estado { get; set; }
        
    }
}
