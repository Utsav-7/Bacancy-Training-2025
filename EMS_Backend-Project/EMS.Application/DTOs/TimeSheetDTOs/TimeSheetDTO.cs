using EMS_Backend_Project.EMS.Domain.Common.Validation;
using System.ComponentModel.DataAnnotations;

namespace EMS_Backend_Project.EMS.Application.DTOs.TimeSheetDTOs
{
    public class TimeSheetDTO
    {
        public int EmployeeId { get; set; }
        public DateOnly WorkDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan BreakTime { get; set; } = TimeSpan.Zero;
        public string? Description { get; set; }
    }
}
