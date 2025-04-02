using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class AccessGridProfile : Profile
    {
        public AccessGridProfile()
        {
            // Request to Entity
            CreateMap<AddEmployeeToGroupReq, AccessGrid>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.AccessGroupId, opt => opt.MapFrom(src => src.AccessGroupId))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
        }
    }
} 