using APB.AccessControl.Application.Filters;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            // Entity to DTO
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.AccessPointName, opt => opt.MapFrom(src => src.AccessPoint.Name))
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => string.Join(" ", src.Employee.LastName, src.Employee.FirstName, src.Employee.PatronymicName)));

            // Request to Entity
            CreateMap<CreateNotificationReq, Notification>()
                .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => false));

            CreateMap<UpdateNotificationReq, Notification>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AccessPointId, opt => opt.MapFrom(src => src.AccessPointId))
                .ForMember(dest => dest.ShowOnPass, opt => opt.MapFrom(src => src.ShowOnPass))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                .ForAllOtherMembers(opt => opt.Ignore());

            //CreateMap<NotificationFilterDto, NotificationFilter>()
            //    .ForMember(dest => dest.AccessPointId, opt => opt.MapFrom(src => src.AccessPointId))
            //    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
            //    .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => src.IsRead))
            //    .ForMember(dest => dest.Expired, opt => opt.MapFrom(src => src.Expired))
            //    .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
} 