using System.Collections;
using EMS_Backend_Project.EMS.Application.DTOs.UserDTOs;
using EMS_Backend_Project.EMS.Application.Interfaces.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend_Project.EMS.API.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UserDTO>>> GetAll()
        {
            try
            {
                var usersList = await _userRepository.GetAllUser();

                if (usersList == null)
                    throw new KeyNotFoundException("No User found.");

                return Ok(usersList);
            }
            catch (KeyNotFoundException ex)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            try
            {
                var users = await _userRepository.GetUserById(id);

                if (users == null)
                    throw new KeyNotFoundException("No User found.");

                return Ok(users);
            }
            catch (KeyNotFoundException ex)
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

        [HttpPost("Admin")]
        public async Task<ActionResult<string>> AddAdmin(AdminUserDTO adminUser)
        {
            if (adminUser == null)
                return BadRequest("Admin Data is required.");
            try
            {
                await _userRepository.AddAdmin(adminUser);

                return "New Admin Created Successfully. And Credentials will send in Registered Email.";
            }
            catch (KeyNotFoundException ex)
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

        [HttpPost("Employee")]
        public async Task<ActionResult<string>> AddEmployee(EmplyeeUserDTO emplyeeUser)
        {
            if (emplyeeUser == null)
                return BadRequest("Employee Data is required.");
            try
            {
                await _userRepository.AddEmployee(emplyeeUser);

                return "New Employee Created Successfully. And Credentials will send in Registered Email.";
            }
            catch (KeyNotFoundException ex)
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

        [HttpPut("Admin/{id}")]
        public async Task<ActionResult<string>> UpdateAdmin(int id, AdminUserDTO adminUser)
        {
            if (adminUser == null)
                return BadRequest("Admin Data is required.");
            try
            {
                await _userRepository.UpdateAdminById(id,adminUser);

                return "New Admin Updated Successfully.";
            }
            catch (KeyNotFoundException ex)
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

        [HttpPut("Employee/{id}")]
        public async Task<ActionResult<string>> UpdateEmployee(int id, EmplyeeUserDTO emplyeeUser)
        {
            if (emplyeeUser == null)
                return BadRequest("Employee Data is required.");
            try
            {
                await _userRepository.UpdateEmployeeById(id, emplyeeUser);

                return "New Employee Updated Successfully.";
            }
            catch (KeyNotFoundException ex)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            try
            {
                await _userRepository.DeleteUserById(id);

                return "New User Deleted Successfully.";
            }
            catch (KeyNotFoundException ex)
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
    }
}