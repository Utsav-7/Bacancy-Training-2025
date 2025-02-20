using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_3_Task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidController : ControllerBase
    {
        private readonly IGuid1 _guid1;
        private readonly IGuid2 _guid2;
        private readonly IGuid3 _guid3;
        private readonly IGuid3 _guid31;

        public GuidController(IGuid1 guid1, IGuid2 guid2, IGuid3 guid3, IGuid3 guid31)
        {
            _guid1 = guid1;
            _guid2 = guid2;
            _guid3 = guid3;
            _guid31 = guid31;
        }

        [HttpGet("/guid/get")]
        public IActionResult GetGuids()
        {
            Console.WriteLine("Singleton : "+_guid1.GetGuid());
            Console.WriteLine("Transient : "+_guid2.GetGuid());
            Console.WriteLine("Scoped : " +_guid3.GetGuid());
            Console.WriteLine("Scoped : "+_guid3.GetGuid());
            return Ok();
        }
    }
}
