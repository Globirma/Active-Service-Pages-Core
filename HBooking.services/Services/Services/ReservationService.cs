﻿using HBooking.Dal;
using HBooking.domain;
using HBooking.domain.Abstraction.Repositories;
using HBooking.domain.Abstraction.Services;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBooking.services.Services.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly DataContext _ctx;

        public ReservationService(IHotelsRepository hotelsRepo, DataContext ctx)
        {
            _hotelsRepository = hotelsRepo;
            _ctx = ctx;
        }

        public async Task<Reservation> MakeReservation(Reservation reservation)
        {

            //Step 1: Create a reservation instance

           // var reservation = new Reservation
            //{
            //    HotelId = hotelId,
             //   RoomId = roomId,
              //  CheckInDate = checkIn,
             //   CheckOutDate = checkOut,
              //  Customer = customer
               //  };

            //Step 2: Get the hotel, including all rooms
            var hotel = await _hotelsRepository.GetHotelByIdAsync(reservation.HotelId);

            //step 3 : Find the specified room
            var room =  hotel.Rooms.Where(r => r.RoomId == reservation.RoomId).FirstOrDefault();

            //Step 4 : Make sure the room is available
            var roomBusyFrom = room.BusyFrom == null ? default(DateTime) : room.BusyFrom;
            var roomBusyTo = room.BusyTo == null ? default(DateTime) : room.BusyTo;
            var isBusy = reservation.CheckInDate >= roomBusyFrom
                || reservation.CheckInDate <= roomBusyTo;

            if (isBusy)
                return null;
            if (room.NeedsRepair)
                return null;
            //Step 5: set busyfrom and busyto on the room
            room.BusyFrom = reservation.CheckInDate;
            room.BusyTo = reservation.CheckOutDate;

            // step 6 : persist all changes to the database
            _ctx.Rooms.Update(room);
            _ctx.Reservations.Add(reservation);

            await _ctx.SaveChangesAsync();

            return reservation;
        }
    }
}
