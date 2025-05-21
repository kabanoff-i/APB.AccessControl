using APB.AccessControl.Application.Filters;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Filters;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System.Collections;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class AccessRuleProfile : Profile
    {
        public AccessRuleProfile()
        {
            //Entity to DTO
            CreateMap<AccessRule, AccessRuleDto>()
                .ForMember(dest => dest.AccessGroupName, opt => opt.MapFrom(src => src.AccessGroup.Name))
                .ForMember(dest => dest.AccessPointName, opt => opt.MapFrom(src => src.AccessPoint.Name))
                .ForMember(dest => dest.DaysOfWeek, opt => opt.MapFrom(src => ConvertBitArray(src.DaysOfWeek)));

            // Request to Entity
            CreateMap<CreateAccessRuleReq, AccessRule>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.DaysOfWeek, opt => opt.MapFrom(src => new BitArray(src.DaysOfWeek)));

            CreateMap<UpdateAccessRuleReq, AccessRule>()
                .ForMember(dest => dest.DaysOfWeek, opt => opt.MapFrom(src => new BitArray(src.DaysOfWeek)));

            //CreateMap<AccessRuleFilterDto, AccessRuleFilter>()
            //    .ForMember(dest => dest.AccessPointId, opt => opt.MapFrom(src => src.AccessPointId))
            //    .ForMember(dest => dest.AccessGroupId, opt => opt.MapFrom(src => src.AccessGroupId))
            //    .ForAllOtherMembers(opt => opt.Ignore());
        }

        private static bool[] ConvertBitArray(BitArray bitArray)
        {
            bool[] result = new bool[bitArray.Count];
            bitArray.CopyTo(result, 0);
            return result;
        }
    }
} 