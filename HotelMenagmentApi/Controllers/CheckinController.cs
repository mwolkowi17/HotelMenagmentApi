﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelMenagmentApi.Data;
using HotelMenagmentApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelMenagmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckinController : ControllerBase
    {
        private readonly HotelMenagmentContext _context;

        public CheckinController(HotelMenagmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetCheckins()
        {
            var roomreservedfortoday =  _context.Reserevations
                                        .Where(n => n.Check_in.Date == DateTime.Today.Date)
                                        .Include(c => c.Room)
                                        .Include(c => c.Guest)
                                        .ToListAsync();


           

           
            return await roomreservedfortoday;
        }

        [HttpGet("getroomsoccupied")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsOccupied()
        {
            var roomnotoccupiedtoday = _context.Rooms
                                      .Where(m => m.Is_ocuppied == false)
                                      .Include(c => c.Guest)
                                      .ToListAsync();

            return await roomnotoccupiedtoday;
        }
        
        [HttpGet("addcheckintoroom")]
        public async Task<ActionResult<Room>> CheckinRoomAdd(int id, string name, string surname, DateTime departureDate, bool breakfestincluded)
        {
            var roomtocheckin = _context.Rooms
                                .Where(n => n.RoomID == id)
                                .Include(c => c.Guest)
                                .ToList();

            roomtocheckin.First().Is_ocuppied = true;

            var newguest = new Guest();
            newguest.Name = name;
            newguest.Surname = surname;
            newguest.Member_since = DateTime.Today;





            //if(!_context.Users.Contains(newguest))

            var guestcontain = _context.Guests
                               .Where(n => n.Name == name)
                               .Where(m => m.Surname == surname)
                               .ToList();



            //ViewBag.CheckinInformation = "Check-in Complete.";
            //ViewBag.CheckinData = $"Room nr {roomtocheckin.First().Number} has been rented to {name} {surname}";
            var roomreservedfortoday = _context.Reserevations
                                       .Where(n => n.Check_in.Date == DateTime.Today.Date)
                                       .Include(c => c.Guest)
                                       .Include(c => c.Room)
                                       .ToList();

            var roomnotoccupiedtoday = _context.Rooms
                                       .Where(n => n.Is_ocuppied == false)
                                       .Include(c => c.Guest)
                                       .ToList();

            var simpleguest = from n in _context.Guests
                              select n;
            /*var checkindata = new PensionViewModel
            {
                ReservedForToday = roomreservedfortoday,
                RoomList = roomnotoccupiedtoday,
                GuestList = simpleguest.ToList()

            };*/

            if (guestcontain.Count() == 0)
            {
                _context.Guests.Add(newguest);
                _context.SaveChanges();
            }

            var guestToCheckin = _context.Guests
                                 .Where(n => n.Name == newguest.Name)
                                 .Where(n => n.Surname == newguest.Surname)
                                 .First();

            roomtocheckin.First().Guest = guestToCheckin;
            await _context.SaveChangesAsync();

            Reservation NewReservation = new Reservation();
            NewReservation.Status = 0;
            NewReservation.Guest = guestToCheckin;
            NewReservation.Room = roomtocheckin.First();
            NewReservation.Check_in = DateTime.Now.Date;
            NewReservation.Check_out = departureDate;
            NewReservation.TotalAmount = (departureDate.DayOfYear - DateTime.Now.DayOfYear) * roomtocheckin.First().ReguralPrice;
            NewReservation.BreakfestIncluded = breakfestincluded;
            _context.Reserevations.Add(NewReservation);
            _context.SaveChanges();
            return roomtocheckin.First();
        }

        [HttpGet("checkinadd")]
        public async Task<ActionResult<Room>> CheckinAdd(int id)
        {
            var roomnumbertocheckin = from n in _context.Reserevations
                                      where n.ReservationID == id
                                      select n.Room.RoomID;

            var roomtocheckin = _context.Rooms
                                .Where(m => m.RoomID == roomnumbertocheckin.First())
                                .Include(c => c.Guest)
                                .FirstOrDefault();

            var usertocheckin = from n in _context.Reserevations
                                where n.ReservationID == id
                                select n.Guest;
            //logowanie błędów
            try
            {
                roomtocheckin.Is_ocuppied = true;
                roomtocheckin.Guest = usertocheckin.First();
                await _context.SaveChangesAsync();
            }
            catch 
            {
              

                throw;
            }
            //return RedirectToAction(nameof(Index));
           

            var roomreservedfortoday = _context.Reserevations
                                       .Where(n => n.Check_in.Date == DateTime.Today.Date)
                                       .Include(c => c.Guest)
                                       .Include(c => c.Room)
                                       .ToList();

            var roomnotoccupiedtoday = _context.Rooms
                                       .Where(n => n.Is_ocuppied == false)
                                       .Include(c => c.Guest)
                                       .ToList();

           /* var checkindata = new PensionViewModel
            {
                ReservedForToday = roomreservedfortoday,
                RoomList = roomnotoccupiedtoday.ToList()

            };*/
            return roomnotoccupiedtoday.FirstOrDefault();
        }
    }
}
