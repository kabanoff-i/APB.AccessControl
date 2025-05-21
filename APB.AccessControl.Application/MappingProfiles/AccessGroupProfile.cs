using System.Security;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class AccessGroupProfile : Profile
    {
        public AccessGroupProfile()
        {
            // Entity to DTO
            CreateMap<AccessGroup, AccessGroupDto>();

            // Request to Entity
            CreateMap<CreateGroupReq, AccessGroup>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<UpdateGroupReq, AccessGroup>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
} 