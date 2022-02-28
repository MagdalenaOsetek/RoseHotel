using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoseHotel.Domain.Entities;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Infrastructure.DAL.Configurations
{
    class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {

            builder.HasIndex(x => x.GuestId).IsUnique();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email)
                .HasConversion(x => x.Value, x => new Email(x));
            builder.Property(x => x.PhoneNumber)
                .HasConversion(x => x.Value, x => new PhoneNumber(x));
            builder.OwnsOne(x => x.Card);
            builder
                .HasOne(u => u.User)
                .WithOne(b => b.Guest)
                .HasForeignKey<User>(u => u.UserId);

        }
    }


}
