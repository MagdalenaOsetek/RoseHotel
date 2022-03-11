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
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasIndex(x => x.ReservationId).IsUnique();
            builder.Property(x => x.ToPay)
                .HasConversion(x => x.Value, x => new Amount(x));
            builder.Property(x => x.Paid)
                .HasConversion(x => x.Value, x => new Amount(x));
            builder.Property(x => x.Status)
                .HasConversion(x => x.Value, x => new ReservationStatus(x));
            builder.HasOne<Guest>(x => x.Guest)
                .WithMany(x => x.Reservations).HasForeignKey(x => x.GuestId);

        }
    }
}
