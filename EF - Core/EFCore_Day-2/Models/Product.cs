using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Day_2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }

        // Many-to-Many: A Product can be in multiple Orders
        public List<Order> orders { get; set; } = new List<Order>();
    }
}
