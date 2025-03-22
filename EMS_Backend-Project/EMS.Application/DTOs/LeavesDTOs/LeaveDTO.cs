using System.ComponentModel.DataAnnotations;
namespace EMS_Backend_Project.EMS.Application.DTOs.LeavesDTOs
{
    public class LeaveDTO
    {
        public int EmployeeId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string LeaveType { get; set; }
        public string? Reason { get; set; }
        public string Status { get; set; }
    }
}