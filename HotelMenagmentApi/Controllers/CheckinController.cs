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
    }
}
