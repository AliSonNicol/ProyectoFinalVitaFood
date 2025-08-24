using System.ComponentModel.DataAnnotations;

namespace VitaFood.Models
{
    public class MenuDia
    {
        [Key]
        public int MenuDiaId { get; set; }

        [Required, StringLength(200)]
        public string Nombre { get; set; }

        [Required, StringLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        // Relaciones
        public ICollection<PedidoDetalle> PedidoDetalles { get; set; }
        public ICollection<Produccion> Producciones { get; set; }
    }
}
