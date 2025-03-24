using System.ComponentModel.DataAnnotations;
using EMS_Backend_Project.EMS.Domain.Common.Validation;

namespace EMS_Backend_Project.EMS.Domain.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        [CustomStringLength(50)]
        public string DepartmentName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}