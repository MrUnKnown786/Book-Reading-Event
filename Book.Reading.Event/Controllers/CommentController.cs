using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Interfaces;
using Book.Reading.Event.Models;

namespace Book.Reading.Event.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentPageService _commentPageService;
        
        public CommentController(ICommentPageService commentPageService)
        {
            this._commentPageService = commentPageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetComments()
        {
            var commetlist = await _commentPageService.GetComments();
            return View(commetlist);
        }

        public async Task<ActionResult> ViewComment(int id)
        {
            var comment = await _commentPageService.ViewComment(id);
            if (comment == null)
            {
                return RedirectToAction("GetComments");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(CommentViewModel commentViewModel)
        {
            var result = await _commentPageService.PostComment(commentViewModel);
            return RedirectToAction("ViewDetails", "Event", new { id = commentViewModel.EventId });
        }

        public async Task<ActionResult> EditComment(int id)
        {
            var ans = await _commentPageService.ViewComment(id);
            if (ans == null)
            {
                return RedirectToAction("GetComments");
            }
            return View(ans);
        }

        [HttpPost]
        public ActionResult EditComment(CommentViewModel commentViewModel)
        {
            var _id = _commentPageService.EditComment(commentViewModel);
            if (_id > 0)
            {
                return RedirectToAction("ViewComment", new { id = _id });
            }
            return View();
        }
    }
}
