using AutoMapper;
using HBooking.Api.Dtos;
using HBooking.domain;

namespace HBooking.Api.Automapper
{
    public class HotelMappingProfiles : Profile
    {
     public HotelMappingProfiles() {
            CreateMap<HotelCreateDto, Hotel>();
            CreateMap<Hotel, HotelGetDto>();
        }
    }
}
