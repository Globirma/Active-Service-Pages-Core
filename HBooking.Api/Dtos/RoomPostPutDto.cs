using HBooking.domain;

namespace HBooking.Api.Dtos
{
    public class RoomPostPutDto
    {

        
        public int RooNumber { get; set; }
        public int surface { get; set; }
        public bool NeedsRepair { get; set; }
       
    }
}
