using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Infrastructure.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(product => product.CompanyProfile)
                .WithMany(company => company.Products)
                .HasForeignKey(product => product.CompanyProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(product => product.ClientProfile)
                .WithMany(company => company.ProductsOwn)
                .HasForeignKey(product => product.ClientProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
