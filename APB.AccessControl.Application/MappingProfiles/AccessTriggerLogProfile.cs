using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Filters;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class AccessTriggerLogProfile : Profile
    {
        public AccessTriggerLogProfile()
        {
            // Entity to DTO
            CreateMap<AccessTriggerLog, AccessTriggerLogDto>();

            // Request to Entity
            CreateMap<CreateAccessTriggerLogReq, AccessTriggerLog>();

            //CreateMap<AccessTriggerLogFilterDto, AccessTriggerLogFilter>()
            //    .ForMember(dest => dest.AccessLogId, opt => opt.MapFrom(src => src.AccessLogId))
            //    .ForMember(dest => dest.TriggerId, opt => opt.MapFrom(src => src.TriggerId))
            //    .ForMember(dest => dest.ExecuteAtStart, opt => opt.MapFrom(src => src.ExecuteAtStart))
            //    .ForMember(dest => dest.ExecuteAtEnd, opt => opt.MapFrom(src => src.ExecuteAtEnd))
            //    .ForMember(dest => dest.ExecutionResult, opt => opt.MapFrom(src => src.ExecutionResult.HasValue ? (bool)src.ExecutionResult.Value : (bool?)null))
            //    .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
} 