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
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasOne(card => card.Client)
                .WithMany(client => client.Cards)
                .HasForeignKey(card => card.ClientProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
