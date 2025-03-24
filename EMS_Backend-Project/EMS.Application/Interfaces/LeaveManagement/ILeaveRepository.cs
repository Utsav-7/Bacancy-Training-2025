using EMS_Backend_Project.EMS.Application.DTOs.LeavesDTOs;

namespace EMS_Backend_Project.EMS.Application.Interfaces.LeaveManagement
{
    public interface ILeaveRepository
    {
        Task<ICollection<GetLeaveDTO>> GetAllLeaves();
        Task<ICollection<GetLeaveDTO>> GetLeaveByID(int id);
        Task AddLeave(int id, LeaveDTO leave);
        Task UpdateLeave(int id, LeaveDTO leave);
        Task DeleteLeave(int id);
    }
}