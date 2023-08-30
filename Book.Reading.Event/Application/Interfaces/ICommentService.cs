using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Application.Models;

namespace Book.Reading.Event.Application.Interfaces
{
    public interface ICommentService
    {
        Task<int> PostComment(CommentModel response);
        Task<IList<CommentModel>> GetComments();
        Task<CommentModel> ViewComment(int commentId);
        int EditComment(CommentModel response);
    }
}
