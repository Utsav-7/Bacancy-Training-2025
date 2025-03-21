using System.ComponentModel.DataAnnotations;
using EMS_Backend_Project.EMS.Domain.Common.Validation;

namespace EMS_Backend_Project.EMS.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [CustomStringLength(60)]
        public string? Address { get; set; } 

        [CustomStringLength(100)]
        public string? TeckStack { get; set; } 

        [Required]
        public DateOnly JoinDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        public DateOnly? RelievingDate { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; } = new HashSet<TimeSheet>();
        public virtual ICollection<Leave>? Leaves { get; set; } = new HashSet<Leave>();
        public virtual ICollection<ReportAnalysis> Report { get; set; } = new HashSet<ReportAnalysis>();
    }
}