using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DOTNET_Day_2.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FirstMiddleware
    {
        private readonly string _config;
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next, IConfiguration config)
        {
            _config = config.GetSection("SecretCredential:Cred").Value;
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                Thread.Sleep(5000);
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine($"{dateTime} : 1st Middleware And credentials " + _config);
                Console.WriteLine("-----------------------------------------------------------");
                return _next(httpContext);
            }catch (Exception)
            {
                Console.WriteLine("Somethings went wrong.!!!!");
                throw;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FirstMiddlewareExtensions
    {
        public static IApplicationBuilder UseFirstMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstMiddleware>();
        }
    }
}
