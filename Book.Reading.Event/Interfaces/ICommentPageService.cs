using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Models;

namespace Book.Reading.Event.Interfaces
{
    public interface ICommentPageService
    {
        Task<int> PostComment(CommentViewModel response);
        Task<IList<CommentViewModel>> GetComments();
        Task<CommentViewModel> ViewComment(int commentId);
        int EditComment(CommentViewModel response);
    }
}
