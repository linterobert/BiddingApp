using AutoMapper;
using BiddingApp.Aplication.Commands;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;

namespace BiddingApp.API.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CreateCardDTO, CreateCardCommand>();
            CreateMap<Card, CardDTO>().ForMember( p => p.ClientId, opt => opt.MapFrom( x => x.ClientProfileId ) );
        }
    }
}
