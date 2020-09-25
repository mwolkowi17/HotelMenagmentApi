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


    }
}
