using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class AccessPointProfile : Profile
    {
        public AccessPointProfile()
        {
            // Entity to DTO
            CreateMap<AccessPoint, AccessPointDto>();

            // Request to Entity
            CreateMap<CreateAccessPointReq, AccessPoint>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<UpdateAccessPointReq, AccessPoint>();
        }
    }
} 