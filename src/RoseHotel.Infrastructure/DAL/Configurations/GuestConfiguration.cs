using System;
using System.Collections.Generic;

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
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Email)
                .HasConversion(x => x.Value, x => new Email(x));
            builder.Property(x => x.PhoneNumber)
                .HasConversion(x => x.Value, x => new PhoneNumber(x));
            builder.OwnsOne(x => x.Adress);
            builder.OwnsOne(x => x.Card);


        }
    }


}
