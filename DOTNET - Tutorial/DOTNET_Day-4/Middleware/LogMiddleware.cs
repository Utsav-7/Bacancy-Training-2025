using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace DOTNET_Day_4.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                Console.WriteLine($"Request : [{dateTime}] : {httpContext.Request.Method} : {httpContext.Request.GetDisplayUrl()}");
                await _next(httpContext);
                Console.WriteLine($"Response : [{dateTime}] : {httpContext.Response.StatusCode}");
            }
            catch(Exception ex)
            {
                throw new Exception("Log not generate....");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
