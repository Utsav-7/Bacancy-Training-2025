using EMS_Backend_Project.EMS.Application.DTOs.Authentication;
using EMS_Backend_Project.EMS.Application.Interfaces.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend_Project.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDTO userLoginDTO)
        {
            if (userLoginDTO == null)
                return BadRequest("Login Data is required.");

            try
            {
                var token = await _authRepository.LoginAsync(userLoginDTO);
                return Ok(new { Token = token });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)    
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<ActionResult<string>> ForgotPassword(ForgotPwdDTO forgotPwdDTO)
        {
            if (forgotPwdDTO == null)
                return BadRequest(new { Message = "Email ID is required for password reset." });

            try
            {
                var result = await _authRepository.ForgotPassword(forgotPwdDTO);
                return Ok(new { Message = result });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message }); // 404 if email not found
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult<string>> ResetPassword(ResetPwdDTO resetPwdDTO)
        {
            if (resetPwdDTO == null)
                return BadRequest(new { Message = "Insufficient Information." });

            try
            {
                var result = await _authRepository.ResetPassword(resetPwdDTO);
                return Ok(new { Message = result });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }
    }
}