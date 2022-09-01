using AutoMapper;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;

namespace BiddingApp.API.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>();
            CreateMap<Review, GetReviewDTO>().ForMember(x => x.Client, opt => opt.MapFrom(x => x.ClientProfile.ClientName));
        }
    }
}
