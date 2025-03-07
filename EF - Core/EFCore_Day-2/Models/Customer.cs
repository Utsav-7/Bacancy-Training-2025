using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Day_2.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        public string CustName { get; set; }
        public int OrderId { get; set; }
        
        // Navigation property
        public List<Order> orders { get; set; } = new List<Order>();
    }
}
