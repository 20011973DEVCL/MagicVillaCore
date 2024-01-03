using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla.Models
{
    public class UsuarioUpdateDto
    {
        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Clave { get; set; }
    }
}