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
            builder.Property(x => x.Price)
                .HasConversion(x => x.Value, x => new Price(x));
            builder.Property(x => x.Capacity)
                .HasConversion(x => x.Value, x => new Capacity(x));
            builder.Property(x => x.Type)
                .HasConversion(x => x.Value, x => new RoomType(x));
        }
    }
}


public class RoomMap : EntityTypeConfiguration<Room>
{
    public RoomMap()
    {
         this
           .HasMany(x=> x.Reservations)
           .WithMany(c => c.Rooms)
           .Map(cs =>
           {
               cs.MapLeftKey("RoomId");
               cs.MapRightKey("ReservationId");
               cs.ToTable("RoomReservation");
           });
    }
}


