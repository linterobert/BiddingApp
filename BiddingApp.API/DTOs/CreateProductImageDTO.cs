using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateProductImageDTO
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }

        public CreateProductImageDTO()
        {

        }
    }
}
