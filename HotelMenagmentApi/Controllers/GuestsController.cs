﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelMenagmentApi.Data;
using HotelMenagmentApi.Models;

namespace HotelMenagmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly HotelMenagmentContext _context;

        public GuestsController(HotelMenagmentContext context)
        {
            _context = context;
        }

        // GET: api/Guests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
        {
            return await _context.Guests.ToListAsync();
        }

        // GET: api/Guests/5
        //returns details
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(int id)
        {
            var guest = await _context.Guests.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return guest;
        }

        // PUT: api/Guests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuest(int id, Guest guest)
        {
            if (id != guest.GuestID)
            {
                return BadRequest();
            }

            _context.Entry(guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Guests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Guest>> PostGuest(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuest", new { id = guest.GuestID }, guest);
        }

        // DELETE: api/Guests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guest>> DeleteGuest(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();

            return guest;
        }

        [HttpGet("FindGuestNumber")]
        public async Task<ActionResult<IEnumerable<Guest>>> FindGuestIdB(string guestsurname)
        {


            var searchedGuests = await _context.Guests
                               .Where(n => n.Surname == guestsurname)
                               .ToListAsync();

            var reservationsToDisplay = _context.Reserevations
                                      .Include(c => c.Room)
                                      .Include(c => c.Guest);





            return searchedGuests;
        }


        private bool GuestExists(int id)
        {
            return _context.Guests.Any(e => e.GuestID == id);
        }
    }
}
