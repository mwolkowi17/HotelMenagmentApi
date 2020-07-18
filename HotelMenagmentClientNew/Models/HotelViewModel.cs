using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentClientNew.Models
{
    public class HotelViewModel
    {
        public List<RoomDTO> RoomList { get; set; }
        public ICollection<GuestDTO> GuestList { get; set; }
        public List<ReservationDTO> ReservationList { get; set; }
        public List<ReservationHistoryDTO> ReservationHistoryList { get; set; }
        public List<ReservationDTO> ReservedForToday { get; set; }
    }
}
