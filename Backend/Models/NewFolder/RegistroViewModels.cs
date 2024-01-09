using System.ComponentModel.DataAnnotations;

namespace Backend.Models.NewFolder
{
    public class RegistroViewModels
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string TipoDocumento { get; set; }
        [Required]
        public int NumeroDocumento { get; set; }
        [Required]
        public string FechaContratacion { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string SubArea { get; set; }
        
    }
}
