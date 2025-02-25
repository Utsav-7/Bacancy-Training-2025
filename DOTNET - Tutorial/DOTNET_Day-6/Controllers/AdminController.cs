using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day_6.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("[controller]/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet("dashboard/")]
        public IActionResult GetDashboard()
        {
            return Ok("Welcome to Admin Dashboard");
        }
    }
}
