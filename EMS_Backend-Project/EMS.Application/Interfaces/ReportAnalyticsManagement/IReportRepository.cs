using EMS_Backend_Project.EMS.Application.DTOs.ReportAnalyticsDTOs;

namespace EMS_Backend_Project.EMS.Application.Interfaces.ReportAnalyticsManagement
{
    public interface IReportRepository
    {
        Task<WeeklyWorkHoursReportDTO> GetWeeklyWorkHoursReportAsync(int employeeId, DateOnly date);
        Task<MonthlyWorkHoursReportDTO> GetMonthlyWorkHoursReportAsync(int employeeId, int month, int year);
        Task<ICollection<WeeklyWorkHoursReportDTO>> GetWeeklyReportOfAllEmployee(DateOnly date);
        Task<ICollection<MonthlyWorkHoursReportDTO>> GetMonthlyReportOfAllEmployee(int month, int year);
        Task<ICollection<MonthlyWorkHoursReportDTO>> GetCustomReport(DateOnly startDate, DateOnly endDate);
    }
}