using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Day_4_Loading_Types.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public virtual Order orders { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product products { get; set; }
        [Required]
        public int Quantity { get; set; }

        // Navigation Property
    }
}