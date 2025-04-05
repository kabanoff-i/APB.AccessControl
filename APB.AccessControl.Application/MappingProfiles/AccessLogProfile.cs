using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class AccessLogProfile : Profile
    {
        public AccessLogProfile()
        {
            // Entity to DTO
            CreateMap<AccessLog, AccessLogDto>()
                .ForMember(dest => dest.AccessResult, opt => opt.MapFrom(src => (int)src.AccessResult))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            // Request to Entity
            CreateMap<CreateAccessLogReq, AccessLog>()
                .ForMember(dest => dest.AccessResult, opt => opt.MapFrom(src => (AccessResult)src.AccessResult));
        }
    }
} 