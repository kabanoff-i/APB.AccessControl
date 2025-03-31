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
            CreateMap<CreateAccessRuleReq, AccessRule>();
            CreateMap<UpdateAccessRuleReq, AccessRule>();
        }
    }
} 