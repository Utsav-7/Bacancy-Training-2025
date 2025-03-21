using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_Backend_Project.EMS.Domain.Entities
{
    public class ReportAnalysis
    {
        [Key]
        public int ReportId { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public DateOnly ReportDate { get; set; }
        public TimeSpan TotalWorkedHours { get; set; }  
        public TimeSpan AverageDailyHours { get; set; } 
        public int LeaveTaken { get; set; }
        public double ConsistencyTime { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public double PerformanceRating { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow; 

        // Navigation Properties
        public virtual Employee? Employee { get; set; }
        public virtual Department? Department { get; set; }
    }
}
