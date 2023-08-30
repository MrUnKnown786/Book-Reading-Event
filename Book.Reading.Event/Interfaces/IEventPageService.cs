using Book.Reading.Event.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Book.Reading.Event.Interfaces
{
    public interface IEventPageService
    {
        Task<IList<EventViewModel>> GetEvents();
        Task<EventViewModel> ViewDetails(int eventId);
        Task<int> CreateEvent(EventViewModel eventModel);
        int UpdateEvent(EventViewModel eventModel);
        Task<IList<EventViewModel>> MyEvents(string organiser);
        Task<IList<CommentViewModel>> GetAllCommentByEventId(int eventId);
    }
}
