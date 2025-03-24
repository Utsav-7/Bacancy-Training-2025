using EMS_Backend_Project.EMS.Application.DTOs.DepartmentDTOs;

namespace EMS_Backend_Project.EMS.Application.Interfaces.DepartmentManagement
{
    public interface IDepartmentRepository
    {
        Task<ICollection<GetDepartmentDTO>> GetAllDepartment();
        Task<GetDepartmentDTO> GetDepartmentById(int id);
        Task UpdateDepartment(int id, string name);
        Task AddDepartment(string name);
        Task DeleteDepartment(int id);
    }
}
