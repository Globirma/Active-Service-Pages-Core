using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBooking.domain
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Room Room { get; set; }
        // to have null used ?
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public string Customer { get; set; }
    }
}
