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
        public int number { get; set; }
        public string name { get; set; }
        public bool is_ocuppied { get; set; }
        public bool smoke { get; set; }
        public RoomType nubmerbeds { get; set; }
        //public string Guest { get; set; }
    }
}
