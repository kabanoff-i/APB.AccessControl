using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class ActionTypeProfile : Profile
    {
        public ActionTypeProfile()
        {
            // Entity to DTO
            CreateMap<ActionType, ActionTypeDto>();
        }
    }
} 