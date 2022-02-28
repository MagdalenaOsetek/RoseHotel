using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Appliction.Abstractions;

namespace RoseHotel.Infrastructure
{
    internal sealed class Clock : IClock
    {
        public DateTime GetCurrentTime() => DateTime.UtcNow;
    }
}
