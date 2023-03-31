using HBooking.domain;
using System;

namespace HBooking.Api.Dtos
{
    public class ReservationPutPostDto
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int HotelId { get; set; }
        public string Customer { get; set; }
    }
}
