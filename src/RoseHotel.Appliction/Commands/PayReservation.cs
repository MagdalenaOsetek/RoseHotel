﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;

namespace RoseHotel.Appliction.Commands
{
    public record PayReservation (Guid ReservationId, decimal Amount, string CardNumber, DateTime ExpirationDate, string Cvv, string FullName) : ICommand;

}
