using Book.Reading.Event.Application.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Book.Reading.Event.Application.Interfaces
{
    public interface IEventService
    {
        Task<IList<EventModel>> GetEvents();
        Task<EventModel> ViewDetails(int eventId);
        Task<int> CreateEvent(EventModel eventModel);
        int UpdateEvent(EventModel eventModel);
        Task<IList<EventModel>> MyEvents(string organiser);
        Task<IList<CommentModel>> GetAllCommentByEventId(int eventId);
    }
}
