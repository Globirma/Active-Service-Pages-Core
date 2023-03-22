using HBooking.domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HBooking.Api.Controllers
{
    //CRUD
    //Create
    //Read
    //Update
    //Delete
    [ApiController]
    [Route("Api/[controller]")]
    public class HotelsController : Controller
    {
        private readonly DataSource _dataSource;
        public HotelsController(DataSource dataSource) {
            _dataSource = dataSource;
        }
        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = _dataSource.Hotels;
            return Ok(hotels);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotels = _dataSource.Hotels;
            var hotel = hotels.FirstOrDefault(h => h.HotelId == id);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel( [FromBody] Hotel hotel)
        {
            var hotels = _dataSource.Hotels;
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelById), new {id = hotel.HotelId}, hotel);
        }
        [HttpPut]
        [Route ("{id}")]
        public IActionResult UpdateHotel([FromBody] Hotel Updated, int id)
        {
          var hotels = _dataSource.Hotels;
          var old =hotels.FirstOrDefault(h => h.HotelId==id);
            if (old == null)
                return NotFound();
            hotels.Remove(old);
            hotels.Add(Updated);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            var hotels = _dataSource.Hotels;
            var toDelete = hotels.FirstOrDefault( h => h.HotelId == id);
                if (toDelete == null)
                return NotFound();
              hotels.Remove(toDelete);
            return NoContent();
        }
        
    }
}
