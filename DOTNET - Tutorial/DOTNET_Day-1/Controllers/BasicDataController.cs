     using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DOTNET_Day_1;
using System.Text.Json;

namespace DOTNET_Day_1.Controllers
{
    [Route("/api/basic/[controller]")]
    [ApiController]
    public class BasicDataController : ControllerBase
    {
        //GET API to get all data
        [HttpGet("/v1/GetData")]
        public List<Basic> GetData()
        {
            return Basic.myList;
        }

        // POST API to add data
        [HttpPost("/v1/PostData/{id}")]
        public async Task<IActionResult> PostData(int id,Basic basic)
        {
            try
            {
                Basic.myList.Add(basic);

                // Serialize the object to JSON
                string jsonString = JsonSerializer.Serialize(basic);

                // Define the file path
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "SavedData.txt");

                // Write to file asynchronously
                await System.IO.File.AppendAllTextAsync(filePath, jsonString);
            }
            catch (Exception)
            {
                return BadRequest("Somethings wents wrong....");
            }
            return Ok($"SUCCESS! {id} Data added successfully");
        }

        // PUT API to update data
        [HttpPut("/v1/PutData/{id}")]
        public IActionResult PutData(int id, Basic basic)
        {
            try
            {
                foreach (var item in Basic.myList)
                {
                    if (item.id == id)
                    {
                        item.name = basic.name;
                        item.email = basic.email;
                        item.city = basic.city;
                    }
                }
            }catch(Exception ex) 
            {
                return BadRequest("Somethings wents wrong....");
            }
            return Ok($"SUCCESS! data of {id} is updated.");
        }

        // DELETE API to delete data
        [HttpDelete("/v1/DeleteData/{id}")]
        public IActionResult DeleteData(int id)
        {
            try
            {
                Basic.myList.RemoveAll(x => x.id == id);
            }
            catch
            {
                return BadRequest("Somethings wents wrong....");
            }
            return Ok($"Your ID {id} is deleted successfully");
        }
    }
}
