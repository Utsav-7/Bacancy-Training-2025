namespace EMS_Backend_Project.EMS.Application.DTOs.ReportAnalyticsDTOs
{
    public class WorkHoursReportDTO
    {
        public int EmployeeId { get; set; }
        public int Year { get; set; }  
        public string Period { get; set; }  
        public TimeSpan TotalHoursWorked { get; set; }  
        public TimeSpan AverageDailyHours { get; set; } 
    }
}
