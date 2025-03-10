using System.ComponentModel.DataAnnotations;

namespace EF_Core_Day_3_CRUD.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int CustId { get; set; }

        // Navigation property
        public Customer Customer { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}