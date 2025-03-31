using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;

namespace APB.AccessControl.Application.MappingProfiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            // Entity to DTO
            CreateMap<Card, CardDto>();

            // Request to Entity
            CreateMap<CreateCardReq, Card>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<UpdateCardReq, Card>();
        }
    }
} 