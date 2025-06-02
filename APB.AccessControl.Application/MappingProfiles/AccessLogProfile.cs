using APB.AccessControl.Application.Filters;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Filters;
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
                .ForMember(dest => dest.MaskPan, opt => opt.MapFrom(src => src.Card.MaskPan))
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => string.Join(" ", src.Employee.LastName, src.Employee.FirstName, src.Employee.PatronymicName)))
                .ForMember(dest => dest.AccessPointName, opt => opt.MapFrom(src => src.AccessPoint.Name))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));


            // Request to Entity
            CreateMap<CreateAccessLogReq, AccessLog>()
                .ForMember(dest => dest.AccessResult, opt => opt.MapFrom(src => (AccessResult)src.AccessResult))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            //CreateMap<AccessLogFilterDto, AccessLogFilter>()
            //    .ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.CardId))
            //    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
            //    .ForMember(dest => dest.AccessPointId, opt => opt.MapFrom(src => src.AccessPointId))
            //    .ForMember(dest => dest.AccessTimeStart, opt => opt.MapFrom(src => src.AccessTimeStart))
            //    .ForMember(dest => dest.AccessTimeEnd, opt => opt.MapFrom(src => src.AccessTimeEnd))
            //    .ForMember(dest => dest.AccessResult, opt => opt.MapFrom(src => src.AccessResult.HasValue ? (AccessResult)src.AccessResult.Value : (AccessResult?)null))
            //    .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
} 