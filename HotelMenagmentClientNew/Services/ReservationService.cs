﻿using AutoMapper;
using HotelMenagmentClientNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelMenagmentClientNew.Services
{
    public class ReservationService
    {
        public static string url = "https://localhost:44343";
        public static HttpClient httpClient = new HttpClient();

        public IMapper _mapper;

        public ReservationService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ICollection<ReservationDTO>> GetAllReservations()
        {
            HotelMenagmentHttpClient HotelClient = new HotelMenagmentHttpClient(url, httpClient);
            ICollection<Reservation> reservations = await HotelClient.ReservationsAllAsync();
            return _mapper.Map<ICollection<ReservationDTO>>(reservations);

        }
    }
}
