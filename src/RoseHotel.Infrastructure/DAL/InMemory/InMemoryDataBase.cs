using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;

namespace RoseHotel.Infrastructure.DAL.InMemory
{
    public class InMemoryDataBase
    {

        public static List<Reservation> repositories = new List<Reservation>();
        public static List<Room> rooms = new List<Room>();
        public static List<User> users = new List<User>();
        public static List<Guest> guests = new List<Guest>();
    }
}
