using DBContext_DI.Data;
using DBContext_DI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBContext_DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TestController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Sports.ToList());
        }

        [HttpPost]
        public IActionResult AddProduct(Sport sport)
        {
            _context.Sports.Add(sport);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProducts), new { id = sport.SportId }, sport);
        }

    }
}
