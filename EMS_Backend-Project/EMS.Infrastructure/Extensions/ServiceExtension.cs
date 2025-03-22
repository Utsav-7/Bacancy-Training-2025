using EMS_Backend_Project.EMS.Application.Interfaces.Authentication;
using EMS_Backend_Project.EMS.Application.Interfaces;
using EMS_Backend_Project.EMS.Infrastructure.Services;
using EMS_Backend_Project.EMS.Infrastructure.Repositories;
using EMS_Backend_Project.EMS.Application.Interfaces.UserManagement;
using FluentValidation;
using System.Reflection;
using EMS_Backend_Project.EMS.Application.Interfaces.TimeSheetManagement;
using EMS_Backend_Project.EMS.Application.Interfaces.LeaveManagement;

namespace EMS_Backend_Project.EMS.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
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