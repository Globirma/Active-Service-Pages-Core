using HBooking.domain;

namespace HBooking.Api.Dtos
{
    public class RoomGetDto
    {
        public int RoomId { get; set; }
        public int RooNumber { get; set; }
        public int surface { get; set; }
        public bool NeedsRepair { get; set; }
        
    }
}
