using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Book.Reading.Event.Interfaces;
using Book.Reading.Event.Models;

namespace Book.Reading.Event.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventPageService _eventPageService;
        private readonly ICommentPageService _commentPageService;
        
        public EventController(IEventPageService eventPageService,ICommentPageService commentPageService)
        {
            this._eventPageService = eventPageService ?? throw new ArgumentNullException(nameof(eventPageService));
            this._commentPageService = commentPageService ?? throw new ArgumentNullException(nameof(commentPageService));
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("Events")]
        public async Task<IActionResult> GetEvents()
        {
            var eventlist = await _eventPageService.GetEvents();
            return View(eventlist);
        }
        
        [Route("Event/{id}")]
        public async Task<IActionResult> ViewDetails(int? id)
        {
            var details = await _eventPageService.ViewDetails(id.Value);
            var ans = await _eventPageService.GetAllCommentByEventId(id.Value);
            details.comments = ans;
            if(details == null)
            {
                return RedirectToAction("GetEvents");
            }
            return View(details);
        }

        [Authorize]
        [Route("CreateEvent")]
        public IActionResult CreateEvent()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        [Route("CreateEvent")]
        public async Task<ActionResult> CreateEvent(EventViewModel eventViewModel)
        {
            var result = await _eventPageService.CreateEvent(eventViewModel);
            if (result > 0)
            {
                return RedirectToAction("MyEvents");
            }
            return View();
        }

        [Authorize]
        [Route("UpdateEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("GetEvents");
            }
            var ans = await _eventPageService.ViewDetails(id.Value);

            if (ans == null)
            {
                return RedirectToAction("GetEvents");
            }
            return View(ans);
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateEvent/{id}")]
        public IActionResult UpdateEvent(EventViewModel eventViewModel)
        {
            var _id = _eventPageService.UpdateEvent(eventViewModel);
            if (_id > 0)
            {
                return RedirectToAction("ViewDetails", new { id = _id });
            }
            return View();
        }

        [Authorize]
        [Route("MyEvents")]
        public async Task<IActionResult> MyEvents()
        {
            var organiser = User.Identity.Name;
            var eventlist = await _eventPageService.MyEvents(organiser);
            return View(eventlist);
        }

        [Authorize]
        [Route("EventsInvitedTo")]
        public async Task<IActionResult> EventsInvitedTo()
        {
            var eventlist = await _eventPageService.GetEvents();
            return View(eventlist);
        }

        [Route("FetchComment/{id}")]
        public async Task<IActionResult> GetAllCommentByEventId(int _id)
        {
            var ans = await _eventPageService.GetAllCommentByEventId(_id);
            if (ans == null)
            {
                return RedirectToAction("ViewDetails", new { id = _id });
            }
            return View(ans);
        }
    }
}
