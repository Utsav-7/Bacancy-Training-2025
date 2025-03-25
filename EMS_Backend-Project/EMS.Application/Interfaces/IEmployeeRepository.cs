using EMS_Backend_Project.EMS.Application.DTOs.EmployeeDTOs;

namespace EMS_Backend_Project.EMS.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDataDTO> GetProfileData(int id);
        Task UpdateProfile(int id, EmployeeUpdateDTO employeeUpdate);
        Task ChangePassword(int id, EmployeePwdUpdateDTO employeePwdUpdate);
    }
}
