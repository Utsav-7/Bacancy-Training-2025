using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Day_4_Loading_Types.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Boolean IsDeleted { get; set; }

        // Navigation Property
        public virtual Customer customer { get; set; }
        public virtual List<OrderProduct> orderProduct { get; set; }
    }
}