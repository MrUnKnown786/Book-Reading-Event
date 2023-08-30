using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Core.Entities;
using Book.Reading.Event.Core.IRepositories.Base;

namespace Book.Reading.Event.Core.IRepositories
{
    public interface IEventRepository : IRepository<Event1>
    {
        Task<IList<Event1>> GetEvents();
        Task<Event1> ViewDetails(int eventId);
        Task<int> CreateEvent(Event1 _event);
        int UpdateEvent(Event1 _event);
        Task<IList<Event1>> MyEvents(string organiser);
        Task<IList<Comment>> GetAllCommentByEventId(int eventId);
    }
}
