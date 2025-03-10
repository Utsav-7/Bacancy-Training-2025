using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Day_3_CRUD.Models
{

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 8)")]
        public int Price { get; set; }

        // Navigation property
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}