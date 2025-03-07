using System.ComponentModel.DataAnnotations;

namespace EFCore_Day_2_Fluent_API.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> orders { get; set; } = new List<Order>();
    }
}
