using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DOTNET_Day_2.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SecondMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _config;

        public SecondMiddleware(RequestDelegate next, IConfiguration config)
        {
            _config = config.GetSection("SecretCredential:InnerCred:myCred").Value;
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine($"{dateTime} : 2nd middleware And credentials : " + _config);
                Console.WriteLine("-----------------------------------------------------------");
                return _next(httpContext);
            }
            catch (Exception ex)
            {
                throw new Exception("Somethings went wrong.");
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Second_MiddlewareExtensions
    {
        public static IApplicationBuilder UseSecond_Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecondMiddleware>();
        }
    }
}
