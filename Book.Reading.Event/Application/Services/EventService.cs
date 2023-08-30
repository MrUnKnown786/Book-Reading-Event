using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Application.Interfaces;
using Book.Reading.Event.Application.Mapper;
using Book.Reading.Event.Core.Entities;
using Book.Reading.Event.Core.IRepositories;
using Book.Reading.Event.Application.Models;

namespace Book.Reading.Event.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        public async Task<IList<EventModel>> GetEvents()
        {
            var eventlist = await _eventRepository.GetEvents();
            var mapped = ObjectMapper.Mapper.Map<IList<EventModel>>(eventlist);
            return mapped;
        }

        public async Task<EventModel> ViewDetails(int eventId)
        {
            var _event = await _eventRepository.ViewDetails(eventId);
            var mapped = ObjectMapper.Mapper.Map<EventModel>(_event);
            return mapped;
        }

        public async Task<int> CreateEvent(EventModel eventModel)
        {
            var mapped = ObjectMapper.Mapper.Map<Event1>(eventModel);
            if(mapped == null)
            {
                throw new Exception($"Entity Could not be mapped.");
            }
            return await _eventRepository.CreateEvent(mapped);
        }

        public int UpdateEvent(EventModel eventModel)
        {
            var mapped = ObjectMapper.Mapper.Map<Event1>(eventModel);
            if (mapped == null)
            {
                throw new Exception($"Entity Could not be mapped.");
            }
            return _eventRepository.UpdateEvent(mapped);
        }

        public async Task<IList<EventModel>> MyEvents(string organiser)
        {
            var eventlist = await _eventRepository.MyEvents(organiser);
            var mapped = ObjectMapper.Mapper.Map<IList<EventModel>>(eventlist);
            return mapped;
        }

        public async Task<IList<CommentModel>> GetAllCommentByEventId(int eventId)
        {
            var commentlist = await _eventRepository.GetAllCommentByEventId(eventId);
            var mapped = ObjectMapper.Mapper.Map<IList<CommentModel>>(commentlist);
            return mapped;
        }
    }
}
