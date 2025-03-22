using EMS_Backend_Project.EMS.Application.DTOs.TimeSheetDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend_Project.EMS.Application.Interfaces.TimeSheetManagement
{
    public interface ITimeSheetRepository
    {
        Task<ICollection<GetTimeSheetDTO>> GetAllSheets();
        Task<GetTimeSheetDTO> GetSheetByIdAndDate(int employeeId, DateOnly workDate);
        Task AddSheet(TimeSheetDTO timeSheet);
        Task UpdateSheet(int id, TimeSheetDTO timeSheet);
        Task DeleteSheet(int id, DateOnly workDate);
        Task<ICollection<EmployeeSheetDTO>> GetSheetById(int id);
        Task<FileContentResult> ExportAllRecords();
    }
}