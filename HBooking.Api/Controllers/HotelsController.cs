using AutoMapper;
using HBooking.Api.Dtos;
using HBooking.Dal;
using HBooking.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        public HotelsController(DataSource dataSource, DataContext ctx, IMapper mapper) {
            _dataSource = dataSource;
            _ctx = ctx;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task <IActionResult> GetAllHotels()
        {
            var hotels = await _ctx.Hotels.ToListAsync();
            var HotelsGet = _mapper.Map<List<HotelGetDto>>(hotels);
            return Ok(HotelsGet);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task <IActionResult> GetHotelById(int id)
        {
           var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                return NotFound();

            var HotelGet = _mapper.Map<HotelGetDto>(hotel);
            return Ok(HotelGet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel( [FromBody] HotelCreateDto hotel)
        {
            var domainHotel = _mapper.Map<Hotel>(hotel);

            _ctx.Hotels.Add(domainHotel);
            await _ctx.SaveChangesAsync();
            var hotelGet = _mapper.Map<HotelGetDto>(domainHotel);

            return CreatedAtAction(nameof(GetHotelById), new { id = domainHotel.HotelId }, hotelGet);
        }
        [HttpPut]
        [Route ("{id}")]
        public async Task <IActionResult> UpdateHotel([FromBody] HotelCreateDto Updated, int id)
        {
            var update = _mapper.Map<Hotel>(Updated);
            update.HotelId = id; 
            _ctx.Hotels.Update(update);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                return NotFound();

            _ctx.Hotels.Remove(hotel);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
