using System.Numerics;
using AutoMapper;
using EMS_Backend_Project.EMS.Application.DTOs.UserDTOs;
using EMS_Backend_Project.EMS.Domain.Entities;

namespace EMS_Backend_Project.EMS.Infrastructure.Mapping
{

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<EmplyeeUserDTO, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => System.DateTime.UtcNow))
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true));

            CreateMap<EmplyeeUserDTO, Employee>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}