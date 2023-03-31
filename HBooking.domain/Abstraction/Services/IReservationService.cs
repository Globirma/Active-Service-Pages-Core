using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBooking.domain.Abstraction.Services
{
    public interface IReservationService
    {
        Task<Reservation> MakeReservation(Reservation reservation);
    }
}
