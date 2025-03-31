using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class TriggerProfile : Profile
    {
        public TriggerProfile()
        {
            // Entity to DTO
            CreateMap<Trigger, TriggerDto>()
                .ForMember(dest => dest.AccessResult, opt => opt.MapFrom(src => (int)src.AccessResult));

            // Request to Entity
            CreateMap<CreateTriggerReq, Trigger>()
                .ForMember(dest => dest.AccessResult, opt => opt.MapFrom(src => (AccessResult)src.AccessResult))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<UpdateTriggerReq, Trigger>()
                .ForMember(dest => dest.AccessResult, opt => opt.MapFrom(src => (AccessResult)src.AccessResult));
        }
    }
} 