using EMS_Backend_Project.EMS.Application.Interfaces.Authentication;
using EMS_Backend_Project.EMS.Application.Interfaces;
using EMS_Backend_Project.EMS.Infrastructure.Services;
using EMS_Backend_Project.EMS.Infrastructure.Repositories;
using EMS_Backend_Project.EMS.Application.Interfaces.UserManagement;
using FluentValidation;
using System.Reflection;

namespace EMS_Backend_Project.EMS.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<TokenService>();

            return services;
        }
    }
}