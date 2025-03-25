using EMS_Backend_Project.EMS.Application.Interfaces.ReportAnalyticsManagement;
using EMS_Backend_Project.EMS.Common.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend_Project.EMS.API.Controllers
{
    [Authorize (Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("GetReportByWeekly")]
        public async Task<ActionResult> GetWeeklyReport(int employeeId, DateOnly Date)
        {
            try
            {
                var ReportList = await _reportRepository.GetWeeklyWorkHoursReportAsync(employeeId, Date);
                return Ok(ReportList);
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

        [HttpGet("GetReportByMonthly")]
        public async Task<ActionResult> GetMonthlyWorkHoursReportAsync(int employeeId, int month, int year)
        {
            try
            {
                var ReportList = await _reportRepository.GetMonthlyWorkHoursReportAsync(employeeId, month, year);
                return Ok(ReportList);
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

        [HttpGet("GetAllEmployeeReportByWeekly")]
        public async Task<ActionResult> GetWeeklyReportOfAll(DateOnly Date)
        {
            try
            {
                var ReportList = await _reportRepository.GetWeeklyReportOfAllEmployee(Date);
                return Ok(ReportList);
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

        [HttpGet("GetAllEmployeeReportByMonthly")]
        public async Task<ActionResult> GetMonthlyWorkHoursReportOfAll(int month, int year)
        {
            try
            {
                var ReportList = await _reportRepository.GetMonthlyReportOfAllEmployee(month, year);
                return Ok(ReportList);
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

        [HttpGet("GetCustomDateReport")]
        public async Task<ActionResult> GetCustomReport(DateOnly startDate, DateOnly endDate)
        {
            try
            {
                var ReportList = await _reportRepository.GetCustomReport(startDate, endDate);
                return Ok(ReportList);
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
