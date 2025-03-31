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

            CreateMap<UpdateGroupReq, AccessGroup>();
        }
    }
} 