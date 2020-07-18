using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelMenagmentClientNew.Models;
using HotelMenagmentClientNew.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelMenagmentClientNew.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<GuestDTO> guestsToDisplay = await _userService.GetAll();

            var model = new HotelViewModel()
            {
                GuestList = guestsToDisplay
            };
            /*var guests = from n in _userService.GetAll()
                              select n;
            var guestVM = new HotelViewModel
            {
                GuestList = singleguest.ToList()
            };
            return View(guestVM);*/
            return View(model);
        }
    }
}
