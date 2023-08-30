using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Book.Reading.Event.Business.Data;
using Book.Reading.Event.Core.IRepositories;
using Book.Reading.Event.Business.Repository.Base;
using Book.Reading.Event.Core.Entities;

namespace Book.Reading.Event.Business.Repository
{
    public class EventRepository : Repository<Event1>, IEventRepository
    {
        private readonly EventContext _eventContext;
        public EventRepository(EventContext eventContext) : base(eventContext)
        {
            this._eventContext = eventContext;
        }

        public async Task<IList<Event1>> GetEvents()
        {
            return await _eventContext.events.OrderBy(x => x.date).ToListAsync();
        }

        public async Task<Event1> ViewDetails(int eventId)
        {
            return await _eventContext.events.FindAsync(eventId);
        }

        public async Task<int> CreateEvent(Event1 _event)
        {
            if(_event.invites == null)
            {
                _event.invites = "admin@gmail.com";
            }
            var newevent = new Event1()
            {
                title = _event.title,
                description = _event.description,
                date = _event.date,
                starttime = _event.starttime,
                location = _event.location,
                duration = _event.duration,
                organiser = _event.organiser,
                invites = _event.invites,
                eventType = _event.eventType
                
            };

            await _eventContext.events.AddAsync(newevent);
            _eventContext.SaveChanges();

            return newevent.Id;
        }

        public int UpdateEvent(Event1 _event)
        {
            _eventContext.events.Update(_event);
            _eventContext.SaveChanges();
            return _event.Id;
        }

        public async Task<IList<Event1>> MyEvents(string organiser)
        {
            var result = from _event in _eventContext.events where _event.organiser == organiser orderby _event.date select _event;
            return await result.ToListAsync();
        }

        public async Task<IList<Comment>> GetAllCommentByEventId(int eventId)
        {
            var result = await (from e in _eventContext.events
                                join c in _eventContext.comment
                                on e.Id equals c.EventId
                                where c.EventId == eventId
                                orderby c.timestamp
                                select new Comment()
                                {
                                    EventId = eventId,
                                    comment = c.comment,
                                    timestamp = c.timestamp
                                }).ToListAsync();
            return result;
        }

    }
}
