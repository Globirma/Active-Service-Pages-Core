using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBooking.domain
{
    public class Hotel
    {
        public Hotel() {
            //validation
            //if (string.IsNullOrWhiteSpace(Name))
            //throw new ArgumentNullException("name not valid");    
            
        }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }  
        public List<Room> Rooms { get; set; }
        public string Description { get; set; }

    }
}
