using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class AccessRuleProfile : Profile
    {
        public AccessRuleProfile()
        {
            // Entity to DTO
            CreateMap<AccessRule, AccessRuleDto>();

            // Request to Entity
            CreateMap<CreateAccessRuleReq, AccessRule>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
                
            CreateMap<UpdateAccessRuleReq, AccessRule>();


        }
    }
} 