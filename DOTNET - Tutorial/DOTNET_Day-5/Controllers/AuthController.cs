using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DOTNET_Day_5.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DOTNET_Day_5.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User user = new ();
        public static List<User> usersList = new List<User>();

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<User> Register(UserDTO request)
        {
            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.password);
            user.Id = request.Id;
            user.username = request.username;
            user.password = hashedPassword;
            user.email = request.email;
            user.role = request.role;
            usersList.Add(user);

            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<string> Login(string username, string password)
        {
            if(user.username != username)
            {
                return BadRequest("User not found."); 
            }
            if(new PasswordHasher<User>().VerifyHashedPassword(user, user.password, password) == PasswordVerificationResult.Failed) 
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(user);
            Console.WriteLine(token);
            return Ok("Login Success....");
        }

        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(usersList);
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromQuery] int id, [FromBody] User user)
        {
            foreach(User i in usersList)
            {
                if(id == i.Id)
                {
                    i.username = user.username;
                    i.password = user.password;
                    i.email = user.email;
                    i.role = user.role;
                }
            }
            return Ok("User is updated.");
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            foreach(User user in usersList)
            {
                if(id == user.Id)
                {
                    usersList.Remove(user);
                    break;
                }
            }
            return Ok("User removed");
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.username),
                new Claim(ClaimTypes.Role, user.role) // Add role claim for authorization
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
