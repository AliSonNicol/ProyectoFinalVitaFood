using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitaFood.Models
{
    public class PedidoDetalle
    {

        [Key]
        public int PedidoDetalleId { get; set; }

        // FK Pedido
        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }

        // FK MenuDia
        public int MenuDiaId { get; set; }
        [ForeignKey("MenuDiaId")]
        public MenuDia MenuDia { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Subtotal { get; set; }
    }
}
