using HotelMenagmentClientNew.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentClientNew.Models
{
    public class RoomDTO
    {
        public int RoomID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public bool Is_ocuppied { get; set; }
        public bool Smoke { get; set; }
        public RoomType Nubmerbeds { get; set; }
        //public string Guest { get; set; }
    }
}
