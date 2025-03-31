using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
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
        }
    }
} 