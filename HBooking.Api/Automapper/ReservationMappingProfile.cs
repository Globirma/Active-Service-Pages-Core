using AutoMapper;
using HBooking.Api.Dtos;
using HBooking.domain;

namespace HBooking.Api.Automapper
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<ReservationPutPostDto, Reservation>();
        }
    }
}
