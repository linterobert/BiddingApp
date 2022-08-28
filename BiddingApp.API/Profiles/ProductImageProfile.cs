using AutoMapper;
using BiddingApp.Domain.DTOs;
using BiddingApp.Domain.Models;

namespace BiddingApp.API.Profiles
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageDTO>();
        }
    }
}
