using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class AccessPointTypeProfile : Profile
    {
        public AccessPointTypeProfile()
        {
            // Entity to DTO
            CreateMap<AccessPointType, AccessPointTypeDto>();
        }
    }
} 