using AutoMapper;
using BiddingApp.Aplication.Commands;
using BiddingApp.Domain.DTOs;
using BiddingApp.Domain.Models;

namespace BiddingApp.API.Profiles
{
    public class CompanyNotificationProfile : Profile
    {
        public CompanyNotificationProfile()
        {
            CreateMap<CreateCompanyNotificationDTO, CreateCompanyNotificationCommand>();
            CreateMap<CompanyNotification, GetCompanyNotificationDTO>();
        }
    }
}
