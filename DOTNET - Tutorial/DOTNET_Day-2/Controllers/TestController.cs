using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day_2.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TestController : Controller
    {
        [HttpGet("/GetData")]
        public IActionResult GetData()
        {
            return Ok("Hello World");
        }
    }
}
