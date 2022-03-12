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
    class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasIndex(x => x.RoomId).IsUnique();
            builder.HasIndex(x => x.Number).IsUnique();
            builder
                .HasMany(r => r.Reservations)
                .WithMany(r => r.Rooms)
                .UsingEntity(re => re.ToTable("RoomReservations"));
        }
    }
}





