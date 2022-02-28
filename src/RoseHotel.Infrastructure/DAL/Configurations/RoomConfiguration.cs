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
    class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasIndex(x => x.RoomId).IsUnique();
            builder.HasIndex(x => x.Number).IsUnique();
            builder.Property(x => x.Price)
                .HasConversion(x => x.Value, x => new Price(x));
            builder.Property(x => x.Capacity)
                .HasConversion(x => x.Value, x => new Capacity(x));
            builder.Property(x => x.Type)
                .HasConversion(x => x.Value, x => new RoomType(x));
            builder
                .HasMany(r => r.Reservations)
                .WithMany(r => r.Rooms)
                .UsingEntity(re => re.ToTable("RoomReservations"));
        }
    }
}





