using System;
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
    public class CheckoutController : ControllerBase
    {
        private readonly HotelMenagmentContext _context;

        public CheckoutController(HotelMenagmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetCheckins()
        {
            var roomsToDisplay = _context.Rooms
                       .Where(n => n.Is_ocuppied == true)
                       .Include(c => c.Guest)
                       .ToListAsync();

            return await roomsToDisplay;
        }

        [HttpGet("checkout")]
        public async Task<ActionResult<IEnumerable<Room>>> Checkout(int id)
        {
            var room = _context.Rooms
                                  .Where(n => n.Is_ocuppied == true)
                                  .Include(c => c.Guest)
                                  .ToList();


          


            var roomtocheckout = _context.Rooms
                                 .Where(n => n.RoomID == id)
                                 .Include(c => c.Guest)
                                 .ToList();
            //logowanie błędów
            try
            {
                roomtocheckout.FirstOrDefault().Is_ocuppied = false;
                roomtocheckout.FirstOrDefault().Guest = null;
                await _context.SaveChangesAsync();
            }
            catch 
            {
               

                throw;
            }

            //new segment - to tests - to refine
            var reservationToCheckout = _context.Reserevations
                                        .Where(n => n.Room == roomtocheckout.FirstOrDefault())
                                        .FirstOrDefault();

            var numberOfDaysInHotel = DateTime.Now.DayOfYear - reservationToCheckout.Check_in.DayOfYear;

            var chargeForStayInHotel = numberOfDaysInHotel * roomtocheckout.FirstOrDefault().ReguralPrice;
            if (reservationToCheckout.BreakfestIncluded == true)
            {
                chargeForStayInHotel = (numberOfDaysInHotel * roomtocheckout.FirstOrDefault().ReguralPrice) + (numberOfDaysInHotel * 80);
            }
            // end of ne segment
           
            //return RedirectToAction(nameof(Index));
            return  roomtocheckout;
        }

    }
}
