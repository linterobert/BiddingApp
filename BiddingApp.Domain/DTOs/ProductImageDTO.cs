using BiddingApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class ProductImageDTO
    {
        public int ProductImageId { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public ProductImageDTO()
        {

        }
        public ProductImageDTO(ProductImage dto)
        {
            ProductImageId = dto.ProductImageId;
            Title = dto.Title;
            URL = dto.URL;
            Description = dto.Description;
            ProductId = dto.ProductId;
        }
    }
}
