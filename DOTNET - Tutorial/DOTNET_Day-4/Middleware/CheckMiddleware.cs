using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DOTNET_Day_4.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                if(httpContext.Request.Path == "/PostWeather")
                {
                    string city = httpContext.Request.Query["city"].ToString().ToLower();
                    if(city != "ahmedabad")
                    {
                        httpContext.Response.StatusCode = 400; // Bad Request
                        await httpContext.Response.WriteAsync("Only Ahmedabad is allowed.");
                        return;
                    }
                }
                await _next(httpContext);
            }
            catch (Exception ex) 
            {
                throw new Exception("Somethings went wrong....");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckMiddleware>();
        }
    }
}
