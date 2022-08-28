using AutoMapper;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;

namespace BiddingApp.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductDTO>().ForMember(x => x.CompanyProfileName, opt => opt.MapFrom(x => x.CompanyProfile.CompanyName))
                .ForMember(x => x.ClientProfileName, opt => opt.MapFrom(x => x.ClientProfile.ClientName));
        }
    }
}
