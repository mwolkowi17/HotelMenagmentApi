using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentClientNew.Models
{
    public class GuestDTO
    {
        public int GuestID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset Member_since { get; set; }
    }
}
