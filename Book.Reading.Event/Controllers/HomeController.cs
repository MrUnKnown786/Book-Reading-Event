using Book.Reading.Event.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Interfaces;

namespace Book.Reading.Event.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventPageService _eventPageService;

        public HomeController(IEventPageService eventPageService)
        {
            this._eventPageService = eventPageService;
        }
        

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var eventlist = await _eventPageService.GetEvents();
            return View(eventlist);
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("about-us")]
        public IActionResult About()
        {
            return View();
        }

        [Route("customer-support")]
        public IActionResult CustomerSupport()
        {
            return View();
        }

        [Route("website")]
        public IActionResult Website()
        {
            return Redirect("https://helpdesk.nagarro.com");
        }

        [Route("Email")]
        public IActionResult Email()
        {
            return Redirect("mailto:helpdesk@nagarro.com");
        }
    }
}
