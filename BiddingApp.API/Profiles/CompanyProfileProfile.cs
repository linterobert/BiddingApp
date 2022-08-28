using AutoMapper;
using BiddingApp.Aplication.Commands;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;

namespace BiddingApp.API.Profiles
{
    public class CompanyProfileProfile : Profile
    {
        public CompanyProfileProfile()
        {
            CreateMap<CompanyProfile, CompanyProfileDTO>();
            CreateMap<CreateCompanyProfileDTO, CreateCompanyProfileCommand>();
            CreateMap<CompanyProfile, GetCompanyProfileDTO>();
        }
    }
}
