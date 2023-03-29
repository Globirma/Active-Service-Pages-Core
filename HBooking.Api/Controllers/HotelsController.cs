using AutoMapper;
using HBooking.Api.Dtos;
using HBooking.Dal;
using HBooking.domain;
using HBooking.domain.Abstraction.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        private readonly IHotelsRepository _hotelsRepo;
        private readonly IMapper _mapper;
       // private readonly DataContext _ctx;
        public HotelsController(DataSource dataSource, IHotelsRepository repo,DataContext ctx, IMapper mapper)
        {
            _dataSource = dataSource;
            _hotelsRepo = repo; 
            _mapper = mapper;
           // _ctx = ctx;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {

            var hotels = await _hotelsRepo.GetAllHotelsAsync();// await _ctx.Hotels.ToListAsync();
            
            var HotelsGet = _mapper.Map<List<HotelGetDto>>(hotels);
         
            return Ok(HotelsGet);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelsRepo.GetHotelByIdAsync(id);
                //await _ctx.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                return NotFound();

            var HotelGet = _mapper.Map<HotelGetDto>(hotel);
            return Ok(HotelGet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelCreateDto hotel)
        {
            var domainHotel = _mapper.Map<Hotel>(hotel);
             await _hotelsRepo.CreateHotelAsync(domainHotel);
            //Taken to repository
            // _ctx.Hotels.Add(domainHotel);
            //await _ctx.SaveChangesAsync();
            var hotelGet = _mapper.Map<HotelGetDto>(domainHotel);

            return CreatedAtAction(nameof(GetHotelById), new { id = domainHotel.HotelId }, hotelGet);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelCreateDto Updated, int id)
        {
            var toUpdate = _mapper.Map<Hotel>(Updated);
            toUpdate.HotelId = id;
           // update.HotelId = id;
            //_ctx.Hotels.Update(update);
            await _hotelsRepo.UpdateHotelAsync(toUpdate);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            //Taken to repository
            //var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);
            var hotel = await _hotelsRepo.DeleteHotelAsync(id);

           if (hotel == null)
                return NotFound();

            //_ctx.Hotels.Remove(hotel);
           // await _ctx.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet]
        [Route("{hotelId}/rooms")]
        public async Task<IActionResult> GetAllHotelRoom(int hotelId)
        {
            var rooms = await _hotelsRepo.ListHotelRoomsAsync(hotelId); //await _ctx.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();
            var mappedRooms = _mapper.Map<List<RoomGetDto>>(rooms);
            return Ok(mappedRooms);
        }
        [HttpGet]
        [Route("{hotelId}/rooms/{roomId}")]
        public async Task<IActionResult> GetHotelRoomById(int hotelId, int roomId)
        {
           // var room = await _ctx.Rooms.FirstOrDefaultAsync(r => r.HotelId == hotelId && r.RoomId == roomId);
           // if (room == null)
              //  return NotFound();
             var room = await _hotelsRepo.GetHotelRoomByIdAsync(hotelId, roomId);
            var mappedRoom = _mapper.Map<RoomGetDto>(room);
            return Ok(mappedRoom);
        }
        [HttpPost]
        [Route("{hotelId}/rooms")]
        public async Task<IActionResult> AddHotelRoom(int hotelId, [FromBody] RoomPostPutDto newRoom)
        {
            var room = _mapper.Map<Room>(newRoom);
            // room.HotelId = hotelId;

            //_ctx.Rooms.Add(room);
            //await _ctx.SaveChangesAsync();

            // Taken to repository
            // var hotel = await _ctx.Hotels.Include(h => h.Rooms)
            // .FirstOrDefaultAsync(h => h.HotelId == hotelId);

            // hotel.Rooms.Add(room);
            // await _ctx.SaveChangesAsync();

            await _hotelsRepo.CreateHotelRoomAsync(hotelId, room);
            var mappedRoom = _mapper.Map<RoomGetDto>(room);

            return CreatedAtAction(nameof(GetHotelRoomById),
                new { HotelId = hotelId, roomId = room.RoomId }, mappedRoom);
        }
        [HttpPut]
        [Route("{hotelId}/rooms/{roomId}")]
        public async Task<IActionResult> UpdateHotelRoom(int hotelId, int roomId,
            [FromBody] RoomPostPutDto UpdatedRoom)
        {
            var toUpdate = _mapper.Map<Room>(UpdatedRoom);
            toUpdate.RoomId = roomId;
            toUpdate.HotelId = hotelId;

            await _hotelsRepo.UpdateHotelRoomAsync(hotelId, toUpdate);

           // _ctx.Rooms.Update(toUpdate);
           // await _ctx.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete]
        [Route("{hotelId}/rooms/{roomId}")]
        public async Task<IActionResult> RemoveRoomFromHotel(int hotelId, int roomId)
        {
           // var room = await _ctx.Rooms.FirstOrDefaultAsync(r => r.RoomId == roomId && r.HotelId == hotelId);
           var room = await _hotelsRepo.DeleteHotelRoomAsync(hotelId,roomId);
            // if (room == null)
            //    return NotFound();

            if (room == null)
               return NotFound();

                // _ctx.Rooms.Remove(room);
                // await _ctx.SaveChangesAsync();
                return NoContent();
        }
    }
}
