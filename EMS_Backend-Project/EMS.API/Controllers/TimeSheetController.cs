using System.Security.Claims;
using EMS_Backend_Project.EMS.Application.DTOs.TimeSheetDTOs;
using EMS_Backend_Project.EMS.Application.Interfaces.TimeSheetManagement;
using EMS_Backend_Project.EMS.Common.CustomExceptions;
using EMS_Backend_Project.EMS.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend_Project.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetController : ControllerBase
    {
        private readonly ITimeSheetRepository _timeSheetRepository;
        public TimeSheetController(ITimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        }

        // Extract the logged-in user's ID from the JWT token   
        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("GetAllSheet")]
        public async Task<ActionResult<GetTimeSheetDTO>> GetAll()
        {
            try
            {
                var list = await _timeSheetRepository.GetAllSheets();

                return Ok(list);
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

        [Authorize(Roles = "Administrator")]
        [HttpGet("GetSheetByID&Date")]
        public async Task<ActionResult<GetTimeSheetDTO>> GetByIdDate(int id, DateOnly date)
        {
            if (id <= 0)
                return BadRequest("Invalid ID. It must be a positive number.");

            try
            {
                var sheet = await _timeSheetRepository.GetSheetByIdAndDate(id, date);

                return Ok(sheet);
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

        [Authorize(Roles = "Administrator, Employee")]
        [HttpPost]
        public async Task<ActionResult> Add(TimeSheetDTO timeSheet)
        {
            if (timeSheet == null)
                return BadRequest("Data is required.");

            try
            {
                var employeeId = GetLoggedInUserId();
                await _timeSheetRepository.AddSheet(employeeId, timeSheet);

                return Ok("Time Sheet Created Successfully.");
            }
            catch(AlreadyExistsException<string> ex)
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

        [Authorize (Roles = "Administrator, Employee")]
        [HttpPut]
        public async Task<ActionResult> Update(int employeeId, TimeSheetDTO timeSheet)
        {
            if (employeeId <= 0)
                return BadRequest("Invalid ID. It must be a positive number.");

            if (timeSheet == null)
                return BadRequest("Data is required.");

            try
            {
                await _timeSheetRepository.UpdateSheet(employeeId, timeSheet);

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

        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        public async Task<ActionResult<GetTimeSheetDTO>> Delete(int id, DateOnly date)
        {
            if (id <= 0)
                return BadRequest("Invalid ID. It must be a positive number.");

            try
            {
                await _timeSheetRepository.DeleteSheet(id, date);

                return Ok("Time Sheet Deleted Successfully.");
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

        [Authorize(Roles = "Employee")]
        [HttpGet("YourSheet")]
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

        [Authorize(Roles = "Administrator")]
        [HttpGet("GenerateExcel")]
        public async Task<ActionResult<TimeSheetDTO>> DownloadExcel()
        {
            try
            {
                var sheetList = await _timeSheetRepository.ExportAllRecords();

                return sheetList;
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
    }
}