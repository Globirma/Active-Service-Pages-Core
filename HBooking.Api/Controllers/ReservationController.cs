using AutoMapper;
using HBooking.Api.Dtos;
using HBooking.domain;
using HBooking.domain.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks;

namespace HBooking.Api.Controllers
    
{
    [ApiController]
    [Route ("api/[controller]")]
    public class ReservationController : Controller
    {
     public readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
    public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationPutPostDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            var result =  await _reservationService.MakeReservation(reservation);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
