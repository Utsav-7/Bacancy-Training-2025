using System.ComponentModel.DataAnnotations;

namespace EF_Core_Day_3_CRUD.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int OrderId { get; set; }

        public Boolean Active { get; set; } = true;

        // Navigtion property
        public List<Order> orders { get; set; } = new List<Order>();
    }
}