using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBooking.domain
{
    public class Reservation
    {
        public int RoomId { get; set; }
        public int ReservationId { get; set; }
        public Room Room { get; set; }
        // to have null used ?
        public DateTime? CheckInDate { get; set; } 
        public DateTime? CheckOutDate { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string Customer { get; set; }
    }
}
