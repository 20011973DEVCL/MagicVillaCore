using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Models.Dto
{
    public class NumeroVillaDto
    {   
        [Required]
        public int VillaNo { get; set; }
        
        [Required]
        public int VillaId { get; set; }

        public string DetalleEspecial { get; set; }
    }
}