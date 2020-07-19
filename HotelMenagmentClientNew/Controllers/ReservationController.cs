using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelMenagmentClientNew.Models;
using HotelMenagmentClientNew.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelMenagmentClientNew.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task <IActionResult> Index()
        {
            ICollection<ReservationDTO> reservationToDisplay = await _reservationService.GetAllReservations();
            var model = new HotelViewModel()
            {
                ReservationList = reservationToDisplay
            };
            return View(model);
        }
    }
}
