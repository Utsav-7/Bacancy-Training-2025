using EMS_Backend_Project.EMS.Application.DTOs.TimeSheetDTOs;
using EMS_Backend_Project.EMS.Application.Interfaces.TimeSheetManagement;
using EMS_Backend_Project.EMS.Domain.Entities;
using EMS_Backend_Project.EMS.Infrastructure.Database;

namespace EMS_Backend_Project.EMS.Infrastructure.Repositories
{
    public class TimeSheetRepository : Repository<TimeSheet>, ITimeSheetRepository
    {
        public TimeSheetRepository(ApplicationDBContext context) : base(context)
        {
        }

        //public Task AddSheet(TimeSheetDTO timeSheet)
        //{
        //    var newSheet = new TimeSheet
        //    {
        //        EmployeeId = timeSheet.EmployeeId,
        //        WorkDate = timeSheet.WorkDate,
        //        StartTime = timeSheet.StartTime,
        //        EndTime = timeSheet.EndTime,
        //    };
        //}

        //public Task DeleteSheet(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ICollection<TimeSheetDTO>> GetAllSheets()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<TimeSheetDTO> GetSheetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateSheet(int id, TimeSheetDTO timeSheet)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
