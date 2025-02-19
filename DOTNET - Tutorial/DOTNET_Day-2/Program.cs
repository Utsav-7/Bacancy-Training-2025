using DOTNET_Day_2.Middleware;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<FirstMiddleware>();
app.UseMiddleware<SecondMiddleware>();

app.Use(async (context, next) =>
{
    Console.WriteLine("Hello, This is Middlware using \"Use\" keyword.");
    await next();
});

app.Run(async (context) =>
{
    Console.WriteLine("Hello, This is Middleware using \"Run\" keyword.");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
