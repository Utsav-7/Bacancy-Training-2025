using EMS_Backend_Project.EMS.Application.DTOs.DepartmentDTOs;
using EMS_Backend_Project.EMS.Application.Interfaces.DepartmentManagement;
using EMS_Backend_Project.EMS.Common.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend_Project.EMS.API.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ICollection<GetDepartmentDTO>>> GetAll()
        {
            try
            {
                var departmentList = await _departmentRepository.GetAllDepartment();
                return Ok(departmentList);
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<GetDepartmentDTO>> GetById(int id)
        {
            try
            {
                var department = await _departmentRepository.GetDepartmentById(id);
                return Ok(department);
            }
            catch (DataNotFoundException<int> ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(string name)
        {
            try
            {
                await _departmentRepository.AddDepartment(name);
                return Ok("Department Created Successfully.");
            }
            catch (AlreadyExistsException<string> ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, string name)
        {
            try
            {
                await _departmentRepository.UpdateDepartment(id, name);
                return Ok("Department Updated Successfully.");
            }
            catch (DataNotFoundException<int> ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Deletee(int id)
        {
            try
            {
                await _departmentRepository.DeleteDepartment(id);
                return Ok("Department Deleted Successfully.");
            }
            catch (DataNotFoundException<int> ex)
            {
                return NotFound(new { Message = ex.Message.ToString() });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }
    }
}