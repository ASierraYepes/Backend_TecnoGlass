using System.ComponentModel.DataAnnotations;

namespace App_TecnoGlass.Models
{
    public class Estados
    {
        public int id { get; set; }
        [Required]
        public string descEstado { get; set; }
        
    }
}
