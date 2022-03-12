using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Domain.ValueObjects;

namespace RoseHotel.Application.DTO
{
    public class BasketDto
    {
        public Guid BasketId { get;  set; }
        public DateTime CheckIn { get;  set; }
        public DateTime CheckOut { get;  set; }
        public List<Capacity> RoomsCapacity { get;  set; }
        public List<Guid> RoomsTypes { get;  set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public Email Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Adress Adress { get;  set; }

    }

}
