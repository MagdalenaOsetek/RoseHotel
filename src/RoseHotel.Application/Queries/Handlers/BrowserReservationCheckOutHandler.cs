using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoseHotel.Application.Abstractions;
using RoseHotel.Application.DTO;
using RoseHotel.Domain.Repositories;

namespace RoseHotel.Application.Queries.Handlers
{
    //internal sealed class BrowserReservationCheckOutHandler : IQueryHandler<BrowserReservationCheckOut, IReadOnlyCollection<ReservationDto>>
    //{
    //    private readonly IReservationRepository _reservationRepository;

    //    public BrowserReservationCheckOutHandler(IReservationRepository reservationRepository)
    //    {
    //        _reservationRepository = reservationRepository;
    //    }
    //    public async Task<IReadOnlyCollection<ReservationDto>> HandleAsync(BrowserReservationCheckOut query)
    //    {
    //        var reservations = await _reservationRepository.BrowserAsyncByCheckInDate(query.CheckOut);

    //        return reservations.Select(x => x.AsDto()).ToList();
    //    }
    //}

}
