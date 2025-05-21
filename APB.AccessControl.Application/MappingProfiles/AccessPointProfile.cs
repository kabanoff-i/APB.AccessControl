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
            CreateMap<AccessPoint, AccessPointDto>()
                .ForMember(dest => dest.AccessPointTypeName, opt => opt.MapFrom(src => src.AccessPointType.Name));

            // Request to Entity
            CreateMap<CreateAccessPointReq, AccessPoint>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IsOnline, opt => opt.Ignore());

            CreateMap<UpdateAccessPointReq, AccessPoint>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.IpAddress, opt => opt.MapFrom(src => src.IpAddress))
                .ForMember(dest => dest.AccessPointTypeId, opt => opt.MapFrom(src => src.AccessPointTypeId))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
} 