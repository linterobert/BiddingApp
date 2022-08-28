using AutoMapper;
using BiddingApp.Aplication.Commands;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;

namespace BiddingApp.API.Profiles
{
    public class ClientProfileProfile : Profile
    {
        public ClientProfileProfile()
        {
            CreateMap<CreateClientProfileDTO, CreateClientProfileCommand>();
            CreateMap<ClientProfile, ClientProfileDTO>();
            CreateMap<ClientProfile, ClientProfileGetDTO>();
        }
    }
}
