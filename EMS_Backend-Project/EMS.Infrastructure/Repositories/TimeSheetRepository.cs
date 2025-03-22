using EMS_Backend_Project.EMS.Application.DTOs.TimeSheetDTOs;
using EMS_Backend_Project.EMS.Application.Interfaces.TimeSheetManagement;
using EMS_Backend_Project.EMS.Domain.Entities;
using EMS_Backend_Project.EMS.Infrastructure.Database;
using EMS_Backend_Project.EMS.Infrastructure.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS_Backend_Project.EMS.Infrastructure.Repositories
{
    public class TimeSheetRepository : Repository<TimeSheet>, ITimeSheetRepository
    {
        public TimeSheetRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task AddSheet(TimeSheetDTO timeSheet)
        {
            var existingSheet = _context.TimeSheets.FirstOrDefault(s => s.EmployeeId == timeSheet.EmployeeId && s.WorkDate == timeSheet.WorkDate);

            if (existingSheet != null)
                throw new Exception("Time sheet already exists.");

            var newSheet = new TimeSheet
            {
                EmployeeId = timeSheet.EmployeeId,
                WorkDate = timeSheet.WorkDate,
                StartTime = timeSheet.StartTime,
                EndTime = timeSheet.EndTime,
                BreakTime = timeSheet.BreakTime,
                Description = timeSheet.Description,
                CreatedAt = DateTime.UtcNow,
                TotalHours = (timeSheet.EndTime - timeSheet.StartTime - timeSheet.BreakTime)
            };

            _context.TimeSheets.Add(newSheet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSheet(int id, DateOnly date)
        {
            var existingSheet = await _context.TimeSheets.FirstOrDefaultAsync(s => s.EmployeeId == id && s.WorkDate == date);

            if (existingSheet == null)
                throw new Exception("Time sheet not exists.");

            _context.TimeSheets.Remove(existingSheet);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GetTimeSheetDTO>> GetAllSheets()
        {
            var sheetList = await _context.TimeSheets.Include(s => s.Employee)
                                                     .ThenInclude(u => u.User)
                                                     .ThenInclude(d => d.Employee.Department)
                                                     .Select(s => new GetTimeSheetDTO
                                                     {
                                                         TimeSheetId = s.TimeSheetId,
                                                         EmployeeName = s.Employee.User.FirstName +  " " + s.Employee.User.LastName,
                                                         DepartmentName = s.Employee.Department.DepartmentName,
                                                         WorkDate = s.WorkDate,
                                                         StartTime = s.StartTime,
                                                         EndTime = s.EndTime,
                                                         BreakTime = s.BreakTime,
                                                         WorkHours = s.TotalHours,
                                                         Description = s.Description
                                                     }).ToListAsync();

            if(sheetList == null)
                throw new Exception("No sheets found.");

            return sheetList;
        }

        public async Task<GetTimeSheetDTO> GetSheetByIdAndDate(int employeeId, DateOnly workDate)

        {
            var sheet = await _context.TimeSheets.Include(s => s.Employee)
                                                                 .ThenInclude(u => u.User)
                                                                 .ThenInclude(d => d.Employee.Department)
                                                                 .Where(c => c.EmployeeId == employeeId && c.WorkDate == workDate)
                                                                 .Select(s => new GetTimeSheetDTO
                                                                 {
                                                                     TimeSheetId = s.TimeSheetId,
                                                                     EmployeeName = s.Employee.User.FirstName + " " + s.Employee.User.LastName,
                                                                     DepartmentName = s.Employee.Department.DepartmentName,
                                                                     WorkDate = s.WorkDate,
                                                                     StartTime = s.StartTime,
                                                                     EndTime = s.EndTime,
                                                                     BreakTime = s.BreakTime,
                                                                     WorkHours = s.TotalHours,
                                                                     Description = s.Description
                                                                 }).FirstOrDefaultAsync();

            if (sheet == null)
                throw new Exception("No Data found.");

            return sheet;
        }

        public async Task UpdateSheet(int id, TimeSheetDTO timeSheet)
        {
            var existingSheet = _context.TimeSheets.FirstOrDefault(s => s.EmployeeId == id);

            if (existingSheet == null)
                throw new KeyNotFoundException("No sheet found.");

            existingSheet.EmployeeId = id;
            existingSheet.WorkDate = timeSheet.WorkDate;
            existingSheet.StartTime = timeSheet.StartTime;
            existingSheet.EndTime = timeSheet.EndTime;
            existingSheet.BreakTime = timeSheet.BreakTime;
            existingSheet.TotalHours = (timeSheet.EndTime - timeSheet.StartTime - timeSheet.BreakTime);
            existingSheet.Description = timeSheet.Description;

            _context.TimeSheets.Update(existingSheet);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<EmployeeSheetDTO>> GetSheetById(int employeeId)
        {
            var getSheetList = await _context.TimeSheets.Where(s => s.EmployeeId == employeeId).Select(s => new EmployeeSheetDTO
            {
                TimeSheetId = s.TimeSheetId,
                EmployeeId = s.EmployeeId,
                WorkDate = s.WorkDate,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                BreakTime = s.BreakTime,
                TotalWorkHours = s.TotalHours,
                Description = s.Description
            }).ToListAsync();

            if (getSheetList == null)
                throw new Exception("Not sheets found.");

            return getSheetList;
        }

        public async Task<FileContentResult> ExportAllRecords()
        {
            var sheetList = await _context.TimeSheets.Include(s => s.Employee)
                                         .ThenInclude(u => u.User)
                                         .ThenInclude(d => d.Employee.Department)
                                         .Select(s => new
                                         {
                                             TimeSheetId = s.TimeSheetId,
                                             EmployeeName = s.Employee.User.FirstName + " " + s.Employee.User.LastName,
                                             DepartmentName = s.Employee.Department.DepartmentName,
                                             WorkDate = s.WorkDate.ToString("yyyy-MM-dd"),  // Format WorkDate
                                             StartTime = s.StartTime.ToString(@"hh\:mm"),    // Format StartTime
                                             EndTime = s.EndTime.ToString(@"hh\:mm"),        // Format EndTime
                                             BreakTime = s.BreakTime.ToString(@"hh\:mm"),    // Format BreakTime
                                             WorkHours = s.TotalHours.ToString(@"hh\:mm"),   // Format WorkHours
                                             Description = s.Description
                                         }).ToListAsync();


            byte[] fileBytes = ExcelExporter.ExportToExcel(sheetList);

            return new FileContentResult(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "TimeSheet.xlsx"
            };
        }

    }
}
