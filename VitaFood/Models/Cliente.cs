using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitaFood.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required, StringLength(200)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Usuario { get; set; }

        [Required, StringLength(100)]
        public string Contrasena { get; set; }

        [Required, StringLength(20)]
        public string Rol { get; set; } // Cliente / Administrador

        // FK
        public int ZonaId { get; set; }
        [ForeignKey("ZonaId")]
        public Zona Zona { get; set; }

        // Relaciones
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
