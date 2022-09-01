using AutoMapper;
using BiddingApp.Aplication.Commands;
using BiddingApp.Domain.DTOs;
using BiddingApp.Domain.Models;

namespace BiddingApp.API.Profiles
{
    public class ClientNotificationProfile : Profile
    {
        public ClientNotificationProfile()
        {
            CreateMap<CreateClientNotificationDTO, CreateClientNotificationCommand>();
            CreateMap<ClientNotification, GetClientNotificationDTO>();
        }
    }
}
