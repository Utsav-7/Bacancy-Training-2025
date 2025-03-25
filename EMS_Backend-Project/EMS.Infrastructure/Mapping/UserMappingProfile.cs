using System.Numerics;
using AutoMapper;
using EMS_Backend_Project.EMS.Application.DTOs.EmployeeDTOs;
using EMS_Backend_Project.EMS.Application.DTOs.UserDTOs;
using EMS_Backend_Project.EMS.Domain.Entities;

namespace EMS_Backend_Project.EMS.Infrastructure.Mapping
{

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // Mapping During Employee Profile creation
            CreateMap<EmplyeeUserDTO, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => System.DateTime.UtcNow))
                .ForMember(dest => dest.Password, opt => opt.Ignore())  // Don't overwrite existing
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true));

            CreateMap<EmplyeeUserDTO, Employee>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            // Mapping for Update Employee's profile
            CreateMap<EmployeeUpdateDTO, User>()    
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Don't overwrite existing
                 .ForMember(dest => dest.Password, opt => opt.Ignore())  // Don't overwrite existing
                 .ForMember(dest => dest.Active, opt => opt.Ignore()) 
                 .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<EmployeeUpdateDTO, Employee>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}