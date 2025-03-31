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
            CreateMap<Notification, NotificationDto>();

            // Request to Entity
            CreateMap<CreateNotificationReq, Notification>()
                .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => false));

            CreateMap<UpdateNotificationReq, Notification>();
        }
    }
} 