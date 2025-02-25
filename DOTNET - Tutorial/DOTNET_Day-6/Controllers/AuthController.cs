using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DOTNET_Day_6.Models;
using DOTNET_Day_6;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace DOTNET_Day_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User user = new();
        public static List<User> usersList = new List<User>();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDTO request)
        {
            if (usersList.Any(u => u.username == request.username))
                return BadRequest("User already exists");

            var user = new User
            {
                Id = request.Id,
                username = request.username,
                email = request.email,
                role = request.role,
                password = new PasswordHasher<User>().HashPassword(null, request.password)
            };

            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.password);

            usersList.Add(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] UserDTO request)
        {
            var usernew = usersList.FirstOrDefault(u => u.username == request.username);

            if (request.username == null)
                return Unauthorized(new { message = "Invalid username or password" });

            var passwordHasher = new PasswordHasher<User>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(usernew, usernew.password, request.password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Invalid username or password" });

            var token = GenerateToken(usernew);

            return Ok(new { token });
        }

        private string GenerateToken(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.username) || string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.role))
            {
                throw new ArgumentException("User information is incomplete. Cannot generate token.");
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.username),
                    new Claim(ClaimTypes.Email, user.email),
                    new Claim(ClaimTypes.Role, user.role)
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