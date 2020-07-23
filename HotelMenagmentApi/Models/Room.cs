using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentApi.Models
{
    public class Room
    {
        public enum RoomType
        {
            singleperson, doubleperson
        }
        public int RoomID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public bool Is_ocuppied { get; set; }
        public bool Smoke { get; set; }
        public RoomType Nubmerbeds { get; set; }
        //public string Guest { get; set; }
    }
}
