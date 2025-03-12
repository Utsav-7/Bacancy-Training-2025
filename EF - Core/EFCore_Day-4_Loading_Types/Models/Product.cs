using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Day_4_Loading_Types.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }

        // Navigation Property
        public virtual List<OrderProduct> orderProduct { get; set; }
    }
}
