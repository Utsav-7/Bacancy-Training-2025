using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_Backend_Project.EMS.Domain.Entities
{
    public class Leave
    {
        [Key]
        public int LeaveId { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        public DateOnly StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        public DateOnly EndDate { get; set; }

        public int TotalDays
        {
            get
            {
                if (EndDate < StartDate) return 0;
                return (EndDate.ToDateTime(TimeOnly.MinValue) - StartDate.ToDateTime(TimeOnly.MinValue)).Days + 1;
            }

            set;
        }

        [Required(ErrorMessage = "Leave Type is required.")]
        public string LeaveType { get; set; }

        [StringLength(250, ErrorMessage = "Reason cannot exceed 250 characters.")]
        public string? Reason { get; set; }

        [Required(ErrorMessage = "Leave Status is required.")]
        public string Status { get; set; }

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public virtual Employee Employee { get; set; }
    }
}
