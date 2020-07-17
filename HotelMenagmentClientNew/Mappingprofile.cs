using AutoMapper;
using HotelMenagmentClientNew.Models;
using HotelMenagmentClientNew.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMenagmentClientNew
{
    public class Mappingprofile : Profile
    {
        public Mappingprofile()
        {
            CreateMap<Room, RoomDTO>();
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<ReservationHistory, ReservationHistoryDTO>();
            CreateMap<Guest, GuestDTO>();
           
        }
    }
}
