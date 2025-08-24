using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitaFood.Models
{
    public class Produccion
    {
        [Key]
        public int ProduccionId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int CantidadTotal { get; set; }

        // FK MenuDia
        public int MenuDiaId { get; set; }
        [ForeignKey("MenuDiaId")]
        public MenuDia MenuDia { get; set; }
    }
}
