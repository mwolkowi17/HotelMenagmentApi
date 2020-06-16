using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentApi.Models
{
    public class Guest
    {
        public int GuestID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime member_since { get; set; }
    }
}
