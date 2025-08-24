using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitaFood.Models
{
    public class Pedido
    {

        [Key]
        public int PedidoId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required, StringLength(20)]
        public string Estado { get; set; } // Registrado, En Producción, Entregado

        // FK Cliente
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        // FK Zona
        public int ZonaId { get; set; }
        [ForeignKey("ZonaId")]
        public Zona Zona { get; set; }

        // Relaciones
        public ICollection<PedidoDetalle> Detalles { get; set; }
    }
}
