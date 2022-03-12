using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.Exceptions;

namespace RoseHotel.Application.Exceptions
{
    public class RoomTypeAlreadyExists : RoseHotelException
    {
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public RoomTypeAlreadyExists(string type, decimal price, int capacity) : base($"Room Type {type} {capacity} {price} already exists")
        {
            Type = type;
            Price = price;
            Capacity = capacity;
        }
    }
}
