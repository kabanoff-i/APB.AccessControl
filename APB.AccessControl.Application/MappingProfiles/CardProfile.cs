using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System.Xml;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            // Entity to DTO
            CreateMap<Card, CardDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => string.Join(" ", src.Employee.LastName, src.Employee.FirstName, src.Employee.PatronymicName)));

            // Request to Entity
            CreateMap<CreateCardReq, Card>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<UpdateCardReq, Card>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
} 