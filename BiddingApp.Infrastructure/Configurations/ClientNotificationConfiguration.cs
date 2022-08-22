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
    internal class ClientNotificationConfiguration : IEntityTypeConfiguration<ClientNotification>
    {
        public void Configure(EntityTypeBuilder<ClientNotification> builder)
        {
            builder.HasOne(notification => notification.Client)
                .WithMany(client => client.Notifications)
                .HasForeignKey(not => not.ClientId);
        }
    }
}
