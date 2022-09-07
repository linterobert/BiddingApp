using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateProductImageDTO
    {
        public CreateProductImageDTO() { }
        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string Title { get; set; }
        [Url]
        public string URL { get; set; }
        [MinLength(2)]
        [MaxLength(30)]
        public string Description { get; set; }
        [Required]
        public int ProductId { get; set; }

    }
}
