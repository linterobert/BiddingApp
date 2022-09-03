using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public string Text { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int StarNumber { get; set; }
        public DateTime PostTime { get; set; }
        public ReviewDTO()
        {

        }
        public ReviewDTO(Review dto)
        {
            ReviewID = dto.ReviewID;
            Text = dto.Text;
            ProductId = dto.ProductId;
            ClientId = dto.ClientId;
            StarNumber = dto.StarNumber;
            PostTime = dto.PostTime;
        }
    }
}
