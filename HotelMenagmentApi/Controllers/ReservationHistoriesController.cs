using System;
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
    public class ReservationHistoriesController : ControllerBase
    {
        private readonly HotelMenagmentContext _context;

        public ReservationHistoriesController(HotelMenagmentContext context)
        {
            _context = context;
        }

        // GET: api/ReservationHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationHistory>>> GetReservationHistory()
        {
            return await _context.ReservationHistory.ToListAsync();
        }

        // GET: api/ReservationHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationHistory>> GetReservationHistory(int id)
        {
            var reservationHistory = await _context.ReservationHistory.FindAsync(id);

            if (reservationHistory == null)
            {
                return NotFound();
            }

            return reservationHistory;
        }

        // PUT: api/ReservationHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationHistory(int id, ReservationHistory reservationHistory)
        {
            if (id != reservationHistory.ReservationHistoryID)
            {
                return BadRequest();
            }

            _context.Entry(reservationHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationHistoryExists(id))
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

        // POST: api/ReservationHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReservationHistory>> PostReservationHistory(ReservationHistory reservationHistory)
        {
            _context.ReservationHistory.Add(reservationHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationHistory", new { id = reservationHistory.ReservationHistoryID }, reservationHistory);
        }

        // DELETE: api/ReservationHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReservationHistory>> DeleteReservationHistory(int id)
        {
            var reservationHistory = await _context.ReservationHistory.FindAsync(id);
            if (reservationHistory == null)
            {
                return NotFound();
            }

            _context.ReservationHistory.Remove(reservationHistory);
            await _context.SaveChangesAsync();

            return reservationHistory;
        }

        private bool ReservationHistoryExists(int id)
        {
            return _context.ReservationHistory.Any(e => e.ReservationHistoryID == id);
        }
    }
}
