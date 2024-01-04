using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Models.Custom
{
    public class AutorizacionRequest
    {
        [Required]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        public string Clave { get; set; } = string.Empty;
    }
}