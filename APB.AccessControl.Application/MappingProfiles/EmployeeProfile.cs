using APB.AccessControl.Application.Filters;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Filters;
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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.PatronymicName, opt => opt.MapFrom(src => src.PatronymicName))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => Convert.FromBase64String(src.Photo)))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForAllOtherMembers(opt => opt.Ignore());

            //CreateMap<EmployeeFilterDto, EmployeeFilter>()
            //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //    .ForMember(dest => dest.PatronymicName, opt => opt.MapFrom(src => src.PatronymicName))
            //    .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
            //    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
            //    .ForMember(dest => dest.PassportNumber, opt => opt.MapFrom(src => src.PassportNumber))
            //    .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            //    .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
