using BiddingApp.Domain.Models;
using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double StartPrice { get; set; }
        public double ActualPrice { get; set; }
        public DateTime FinalTime { get; set; }
        public int CompanyProfileId { get; set; }
        public int? ClientProfileId { get; set; }
        public bool CashOut { get; set; }
        public List<Review> Reviews { get; set; }
        public List<ProductImage> Images { get; set; }

        public ProductDTO(Product dto)
        {
            ProductId = dto.ProductId;
            ProductName = dto.ProductName;
            ActualPrice = dto.ActualPrice;
            StartPrice = dto.StartPrice;
            FinalTime = dto.FinalTime;
            CompanyProfileId = dto.CompanyProfileId;
            ClientProfileId = dto.ClientProfileId;
            CashOut = dto.CashOut;
            Reviews = dto.Reviews;
            Images = dto.Images;
        }
    }
}
