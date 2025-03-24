using EMS_Backend_Project.EMS.Application.DTOs.ReportAnalyticsDTOs;

namespace EMS_Backend_Project.EMS.Application.Interfaces.ReportAnalyticsManagement
{
    public interface IReportRepository
    {
        Task<List<WorkHoursReportDTO>> GetWeeklyWorkHoursAsync();
        Task<List<WorkHoursReportDTO>> GetMonthlyWorkHoursAsync();

        Task<WorkHoursReportDTO> GetReportById(int id);
    }
}
