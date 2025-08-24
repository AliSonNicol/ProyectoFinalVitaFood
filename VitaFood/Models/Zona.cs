using System.ComponentModel.DataAnnotations;

namespace VitaFood.Models
{
    public class Zona
    {
        [Key]
        public int ZonaId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(200)]
        public string Descripcion { get; set; }

        // Relaciones
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
