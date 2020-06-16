using HotelMenagmentApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentApi.Data
{
    public class HotelMenagmentContext: DbContext
    {
        public HotelMenagmentContext(DbContextOptions<HotelMenagmentContext> options)
            :base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reserevations { get; set; }
        public DbSet<HotelMenagmentApi.Models.ReservationHistory> ReservationHistory { get; set; }

    }
}
