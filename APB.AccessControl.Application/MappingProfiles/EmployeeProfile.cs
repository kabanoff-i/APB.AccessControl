using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Entity to DTO
            CreateMap<Employee, EmployeeDto>();

            // Request to Entity
            CreateMap<CreateEmployeeReq, Employee>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<UpdateEmployeeReq, Employee>();
        }
    }
}
