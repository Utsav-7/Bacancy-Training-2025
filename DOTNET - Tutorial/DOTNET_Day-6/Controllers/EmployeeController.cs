using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day_6.Controllers
{
    [Authorize (Roles = "employee")]
    [Route("/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("profile/")]
        public IActionResult GetProfile(int id)
        {
            return Ok("Welcome to Employee Profile");
        }
    }
}
