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
    public class ReservationsController : ControllerBase
    {
        private readonly HotelMenagmentContext _context;

        public ReservationsController(HotelMenagmentContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReserevations()
        {
            var reservationToDisplay = _context.Reserevations
                                      .Include(n => n.Guest)
                                      .Include(n => n.Room)
                                      .ToListAsync();


            return await reservationToDisplay;
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reserevations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.ReservationID)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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

        // POST: api/Reservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            _context.Reserevations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.ReservationID }, reservation);
        }

        [HttpGet("addreservation")]
        public async Task <ActionResult<Reservation>> AddReservation(RoomType type, int idguest, DateTime checkin, DateTime checkout, bool breakfestincluded)
        {
            var RoomToRentTypeList = (from Room item in _context.Rooms
                                      where item.nubmerbeds == type
                                      select item).ToList();

            var GuestToRent = (from Guest item in _context.Guests
                               where item.GuestID == idguest
                               select item).SingleOrDefault();
            var RoomTypeNumbers = (from Room n in RoomToRentTypeList
                                   select n.RoomID).ToList();
            var ReservationTypes = (from Reservation n in _context.Reserevations
                                    where RoomTypeNumbers.Contains(n.Room.RoomID)
                                    select n);

            // need db for checkin&checkoutvalues
            // filtering method propsal
            DateTime checkinvalue = new DateTime();
            DateTime checkoutvalue = new DateTime();
            checkinvalue = checkin;
            checkoutvalue = checkout;
            int numberOfRoomProposal = (from Reservation m in ReservationTypes
                                        where (checkinvalue < m.Check_in
                                        && checkoutvalue < m.Check_in) ||
                                        (checkinvalue > m.Check_out
                                        && checkoutvalue > m.Check_out)
                                        select m.Room.RoomID).FirstOrDefault();
            // lista numerów zajętych w konkretnej dacie
            var numbersOfRoomOccupied = (from Reservation m in ReservationTypes
                                         where (checkinvalue >= m.Check_in
                                         && checkinvalue <= m.Check_out) ||
                                         (checkoutvalue >= m.Check_in
                                         && checkoutvalue <= m.Check_out)
                                         select m.Room.RoomID).ToList();
            // lista z wyrzuconymi zajętymi numerami
            var RoomsToRent = (from Room n in RoomToRentTypeList
                               where !numbersOfRoomOccupied.Contains(n.RoomID)
                               select n).ToList();
            /*var RoomToRent = (from Room n in RoomToRentTypeList
                              where n.RoomID == numberOfRoomProposal
                              select n).FirstOrDefault();*/

            var RoomToRent = (from Room n in RoomsToRent
                              select n).FirstOrDefault();

            Reservation NewReservation = new Reservation();
            if (RoomToRent != null)
                {
                    //RoomToRent.Is_ocuppied = true;

                    
                    NewReservation.Status = 0;
                    NewReservation.Guest = GuestToRent;

                    NewReservation.Room = RoomToRent;
                    NewReservation.Check_in = checkin;
                    NewReservation.Check_out = checkout;

                    NewReservation.BreakfestIncluded = breakfestincluded;
                    // add breakfest fee with "if" conditional
                    if (NewReservation.BreakfestIncluded == true)
                    {
                        NewReservation.TotalAmount = ((checkout.DayOfYear - checkin.DayOfYear) * RoomToRent.ReguralPrice) + ((checkout.DayOfYear - checkin.DayOfYear) * 80);
                    }
                    else
                    {
                        NewReservation.TotalAmount = (checkout.DayOfYear - checkin.DayOfYear) * RoomToRent.ReguralPrice;
                    }
                    //Old way of Total Amount Count method
                    //NewReservation.TotalAmount = (checkout.DayOfYear - checkin.DayOfYear) * RoomToRent.ReguralPrice;
                    _context.Reserevations.Add(NewReservation);
                    await _context.SaveChangesAsync();

                 
                }
            return  CreatedAtAction("GetReservation", new { id =NewReservation.ReservationID }, NewReservation );
            
            //throw new NotImplementedException();
            
        }
        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> DeleteReservation(int id)
        {
            var reservation = await _context.Reserevations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reserevations.Remove(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        private bool ReservationExists(int id)
        {
            return _context.Reserevations.Any(e => e.ReservationID == id);
        }
    }
}
