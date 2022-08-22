using BiddingApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Infrastructure.Configurations
{
    internal class CompanyNotificationConfiguration : IEntityTypeConfiguration<CompanyNotification>
    {
        public void Configure(EntityTypeBuilder<CompanyNotification> builder)
        {
            builder.HasOne(not => not.Company)
                .WithMany(company => company.Notifications)
                .HasForeignKey(not => not.CompanyId);
        }
    }
}
