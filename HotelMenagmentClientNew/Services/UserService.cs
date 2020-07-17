using AutoMapper;
using HotelMenagmentClientNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelMenagmentClientNew.Services
{
    public class UserService
    {
        public static string url = "https://localhost:44343";
        public static HttpClient httpClient = new HttpClient();

        public IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ICollection<GuestDTO>> GetAll()
        {
            HotelMenagmentHttpClient HotelClient = new HotelMenagmentHttpClient(url, httpClient);
            ICollection<Guest> guests = await HotelClient.GuestsAllAsync();
            return _mapper.Map<ICollection<GuestDTO>>(guests);
           // ICollection<Item> items = await libraryClient.ItemsAllAsync();

           // return _mapper.Map<ICollection<ItemDTO>>(items);
        }

    }
}
