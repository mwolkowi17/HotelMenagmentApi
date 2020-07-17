using HotelMenagmentClientNew.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentClientNew.Models
{
    public class ReservationDTO
    {
        public int ReservationID { get; set; }

        [Display(Name = "Checkin Date")]
        [DataType(DataType.Date)]

        public DateTime check_in { get; set; }

        [Display(Name = "Checkout Date")]
        [DataType(DataType.Date)]

        public DateTime check_out { get; set; }
        public ResStatus status { get; set; }
        public string made_by { get; set; }
        //public int GuestID { get; set; }
        public Guest Guest { get; set; }

        public string GuestName { get; set; }
        //public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
