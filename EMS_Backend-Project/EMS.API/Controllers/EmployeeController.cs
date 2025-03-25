using System.Security.Claims;
using EMS_Backend_Project.EMS.Application.DTOs.EmployeeDTOs;
using EMS_Backend_Project.EMS.Application.DTOs.LeavesDTOs;
using EMS_Backend_Project.EMS.Application.DTOs.TimeSheetDTOs;
using EMS_Backend_Project.EMS.Application.Interfaces;
using EMS_Backend_Project.EMS.Application.Interfaces.LeaveManagement;
using EMS_Backend_Project.EMS.Application.Interfaces.TimeSheetManagement;
using EMS_Backend_Project.EMS.Common.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend_Project.EMS.API.Controllers
{
    [Authorize(Roles = "Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(ILeaveRepository leaveRepository, ITimeSheetRepository timeSheetRepository, IEmployeeRepository employeeRepository)
        {
            _leaveRepository = leaveRepository;
            _timeSheetRepository = timeSheetRepository;
            _employeeRepository = employeeRepository;
        }

        // Extract the logged-in user's ID from the JWT token   
        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("Profile")]
        public async Task<ActionResult> Profile()
        {
            try
            {
                var loginUser = GetLoggedInUserId();
                var profileData = await _employeeRepository.GetProfileData(loginUser);

                return Ok(profileData);
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

        [HttpPut("UpdateProfile")]
        public async Task<ActionResult> UpdateProfile(EmployeeUpdateDTO employeeUpdate)
        {
            if (employeeUpdate == null)
                return BadRequest("Data is required.");
            
            try
            {
                var loggedUser = GetLoggedInUserId();
                await _employeeRepository.UpdateProfile(loggedUser, employeeUpdate);

                return Ok("Your Data has been updated.");
            }
            catch(DataNotFoundException<string> ex)
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

        [HttpGet("YourLeaves")]
        public async Task<ActionResult> GetById()
        {
            try
            {
                var loggedUser = GetLoggedInUserId();
                var leaveRecord = await _leaveRepository.GetLeaveByID(loggedUser);

                return Ok(leaveRecord);
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

        [HttpPost("TakeLeave")]
        public async Task<ActionResult> Add(LeaveDTO leave)
        {
            if (leave == null)
                return BadRequest("Data is required.");

            try
            {
                var employeeId = GetLoggedInUserId();
                await _leaveRepository.AddLeave(employeeId, leave);

                return Ok("Leave record created Successfully.");
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

        [HttpGet("GetYourSheets")]
        public async Task<ActionResult<TimeSheetDTO>> GetYourRecords()
        {
            try
            {
                int currentUser = GetLoggedInUserId();
                var sheetList = await _timeSheetRepository.GetSheetById(currentUser);

                return Ok(sheetList);
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

        [HttpPost("CreateTimeSheet")]
        public async Task<ActionResult> AddTimeSheet(TimeSheetDTO timeSheet)
        {
            if (timeSheet == null)
                return BadRequest("Data is required.");

            try
            {
                var employeeId = GetLoggedInUserId();
                await _timeSheetRepository.AddSheet(employeeId, timeSheet);

                return Ok("Time Sheet Created Successfully.");
            }
            catch (AlreadyExistsException<string> ex)
            {
                return BadRequest(new { Message = ex.Message });
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

        [HttpPut("UpdateTimeSheet")]
        public async Task<ActionResult> Update(TimeSheetDTO timeSheet)
        {
            if (timeSheet == null)
                return BadRequest("Data is required.");

            try
            {
                var loggedUser = GetLoggedInUserId();
                await _timeSheetRepository.UpdateSheet(loggedUser, timeSheet);

                return Ok("Time Sheet Updated Successfully.");
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

        [HttpPut("ChangePassword")]
        public async Task<ActionResult> ChangePassword(EmployeePwdUpdateDTO employeePwdUpdate)
        {
            if (employeePwdUpdate == null)
                return BadRequest("Data is required.");

            if (employeePwdUpdate.NewPassword != employeePwdUpdate.ConfirmPassword)
                return BadRequest("New Password and Confirm Password is not matching.");

            try
            {
                var loggedUser = GetLoggedInUserId();
                await _employeeRepository.ChangePassword(loggedUser, employeePwdUpdate);

                return Ok("Your Password will be updated Successfully.");
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
    }
}