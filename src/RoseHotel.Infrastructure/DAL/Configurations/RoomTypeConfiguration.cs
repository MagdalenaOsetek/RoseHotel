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
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {


        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasIndex(x => x.RoomTypeId).IsUnique();
            builder.Property(x => x.Price)
                .HasConversion(x => x.Value, x => new Price(x));
            builder.Property(x => x.Capacity)
                .HasConversion(x => x.Value, x => new Capacity(x));
            builder.Property(x => x.Type)
                .HasConversion(x => x.Value, x => new RoomTypeName(x));
            builder.HasMany<Room>(x => x.Rooms)
                .WithOne(x => x.RoomType)
                .HasForeignKey(x => x.RoomTypeId);
        }
    }

}
