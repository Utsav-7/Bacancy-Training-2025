using EMS_Backend_Project.EMS.Application.DTOs.LeavesDTOs;
using EMS_Backend_Project.EMS.Application.Interfaces.LeaveManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend_Project.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveRepository _leaveRepository;

        public LeaveController(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult<GetLeaveDTO>> GetAll()
        {
            try
            {
                var leaveRecordsList = await _leaveRepository.GetAllLeaves();

                return Ok(leaveRecordsList);
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


        [Authorize(Roles = "Administrator")]
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            if(id <= 0)
                return BadRequest("Invalid ID. It must be a positive number.");

            try
            {
                var leaveRecord = await _leaveRepository.GetLeaveByID(id);

                return Ok(leaveRecord);
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

        [Authorize(Roles = "Administrator, Employee")]
        [HttpPost]
        public async Task<ActionResult> Add(LeaveDTO leave)
        {
            if (leave == null)
                return BadRequest("Data is required.");

            try
            {
                await _leaveRepository.AddLeave(leave);

                return Ok("Leave record created Successfully.");
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

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<ActionResult> Update(int id, LeaveDTO leave)
        {
            if (id <= 0)
                return BadRequest("Invalid ID. It must be a positive number.");

            if (leave == null)
                return BadRequest("Data is required.");

            try
            {
                await _leaveRepository.UpdateLeave(id, leave);

                return Ok("Leave record updated Successfully.");
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


        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID. It must be a positive number.");

            try
            {
                await _leaveRepository.DeleteLeave(id);

                return Ok("Leave record deleted Successfully.");
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
