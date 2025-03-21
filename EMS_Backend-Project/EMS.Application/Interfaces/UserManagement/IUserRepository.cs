using EMS_Backend_Project.EMS.Application.DTOs.UserDTOs;

namespace EMS_Backend_Project.EMS.Application.Interfaces.UserManagement
{
    public interface IUserRepository
    {
        Task<ICollection<UserDTO>> GetAllUser();
        Task<UserDTO> GetUserById(int id);
        Task AddEmployee(EmplyeeUserDTO emplyeeUserDTO);
        Task AddAdmin(AdminUserDTO adminUserDTO);
        Task UpdateAdminById(int id, AdminUserDTO adminUserDTO);
        Task UpdateEmployeeById(int id, EmplyeeUserDTO emplyeeUserDTO);
        Task DeleteUserById(int id);
    }
}