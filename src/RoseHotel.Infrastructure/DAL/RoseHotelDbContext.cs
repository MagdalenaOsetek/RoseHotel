using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Infrastructure.DAL
{
    internal sealed class RoseHotelDbContext : DbContext
    {

        public  DbSet<Room> Rooms { get; set; }
        public  DbSet<Reservation> Reservations { get; set; }
        public  DbSet<Guest> Guests { get; set; }
        public  DbSet<User> Users { get; set; }

        public RoseHotelDbContext(DbContextOptions<RoseHotelDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            
        }
    }
}
