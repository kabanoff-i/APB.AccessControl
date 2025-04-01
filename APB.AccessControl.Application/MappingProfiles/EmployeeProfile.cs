using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Entity to DTO
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => Convert.ToBase64String(src.Photo)));

            // Request to Entity
            CreateMap<CreateEmployeeReq, Employee>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => Convert.FromBase64String(src.Photo)));

            CreateMap<UpdateEmployeeReq, Employee>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => Convert.FromBase64String(src.Photo)));
        }
    }
}
