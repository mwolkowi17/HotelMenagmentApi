using AutoMapper;
using HotelMenagmentClientNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelMenagmentClientNew.Services
{
    public class RoomService
    {
        public static string url = "https://localhost:44343";
        public static HttpClient httpClient = new HttpClient();

        public IMapper _mapper;

        public RoomService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ICollection<RoomDTO>> GetAllRooms()
        {
            HotelMenagmentHttpClient HotelClient = new HotelMenagmentHttpClient(url, httpClient);
            ICollection<Room> rooms = await HotelClient.RoomsAllAsync();
            return _mapper.Map<ICollection<RoomDTO>>(rooms);

        }


    }
}
