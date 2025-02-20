using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_3_Task_1.Middlewares
{
    public class CheckMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // get the path of the request
            if (httpContext.Request.Path == "/v2/PostWeather")
            {
                // get the city from the query string
                string city = httpContext.Request.Query["city"].ToString().ToLower();

                if (city != "ahmedabad")
                {
                    httpContext.Response.StatusCode = 400; // Bad Request
                    await httpContext.Response.WriteAsync("Only Ahmedabad is allowed.");
                    return;
                }

            }  
            await _next(httpContext);
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
