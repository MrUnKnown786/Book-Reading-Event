using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Interfaces;
using Book.Reading.Event.Application.Interfaces;
using Book.Reading.Event.Models;
using Book.Reading.Event.Application.Models;

namespace Book.Reading.Event.Services
{
    public class EventPageService : IEventPageService
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        private readonly ILogger<EventPageService> _logger;
        public EventPageService(IEventService eventService,IMapper mapper,ILogger<EventPageService> logger)
        {
            this._eventService = eventService;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<IList<EventViewModel>> GetEvents()
        {
            var eventlist = await _eventService.GetEvents();
            var mapped = _mapper.Map<IList<EventViewModel>>(eventlist);
            return mapped;
        }

        public async Task<EventViewModel> ViewDetails(int eventId)
        {
            var _event = await _eventService.ViewDetails(eventId);
            var mapped = _mapper.Map<EventViewModel>(_event);
            return mapped;
        }

        public async Task<int> CreateEvent(EventViewModel eventViewModel)
        {
            var mapped = _mapper.Map<EventModel>(eventViewModel);
            if(mapped == null)
            {
                throw new Exception($"Entity Could not be mapped.");
            }
            return await _eventService.CreateEvent(mapped);
        }

        public int UpdateEvent(EventViewModel eventViewModel)
        {
            var mapped = _mapper.Map<EventModel>(eventViewModel);
            if (mapped == null)
            {
                throw new Exception($"Entity Could not be mapped.");
            }
            return _eventService.UpdateEvent(mapped);
        }

        public async Task<IList<EventViewModel>> MyEvents(string organiser)
        {
            var eventlist = await _eventService.MyEvents(organiser);
            var mapped = _mapper.Map<IList<EventViewModel>>(eventlist);
            return mapped;
        }

        public async Task<IList<CommentViewModel>> GetAllCommentByEventId(int eventId)
        {
            var commentlist = await _eventService.GetAllCommentByEventId(eventId);
            var mapped = _mapper.Map<IList<CommentViewModel>>(commentlist);
            return mapped;
        }
    }
}
