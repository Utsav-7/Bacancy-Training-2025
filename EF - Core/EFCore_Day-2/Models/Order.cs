using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace EFCore_Day_2.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("CustId")]  
        public int? CustId { get; set; }

        public Customer customer { get; set; }

        // Many-to-Many: An Order can have multiple Products
        public List<Product> products { get; set; } = new List<Product>();
    }
}
