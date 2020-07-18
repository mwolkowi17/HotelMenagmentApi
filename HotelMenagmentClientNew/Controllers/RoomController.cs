using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelMenagmentClientNew.Models;
using HotelMenagmentClientNew.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelMenagmentClientNew.Controllers
{
    public class RoomController : Controller
    {
        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<RoomDTO> roomsToDisplay = await _roomService.GetAllRooms();

            var model = new HotelViewModel()
            {
                RoomList = roomsToDisplay
            };
            return View(model);
        }
    }
}
