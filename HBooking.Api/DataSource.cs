using HBooking.domain;
using System.Collections.Generic;

namespace HBooking.Api
{
    public class DataSource
    {
        public DataSource() { 
         Hotels = GetHotels();
        }
        public List<Hotel> Hotels { get; set; }
        private List<Hotel> GetHotels()
        {
            return new List<Hotel>
            {
                new Hotel
                {
                   HotelId = 1,
                   Name = "shariton",
                   Stars = 5,
                   Address = "place",
                   City =" Abuja",
                   Country = "Nigeria",
                   Description = "The best place"

                },
                new Hotel
                {
                   HotelId = 2,
                   Name = "luxry",
                   Stars = 4,
                   Address = "place",
                   City =" Carlifonia",
                   Country = "USA",
                   Description = " Is really a nice place to be"

                }
            };
        }
    }
}
