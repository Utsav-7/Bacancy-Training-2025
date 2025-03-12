using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Day_4_Loading_Types.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public Boolean IsVIP { get; set; }

        // Navigation property
        public virtual List<Order> orders { get; set; }
    }
}
