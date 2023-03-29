using AutoMapper;
using HBooking.Api.Dtos;
using HBooking.domain;

namespace HBooking.Api.Automapper
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile() {

            CreateMap<Room,RoomGetDto>();
            CreateMap<RoomPostPutDto, Room>();
        }
    }
}
