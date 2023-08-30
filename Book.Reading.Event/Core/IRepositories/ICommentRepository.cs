using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Core.Entities;

namespace Book.Reading.Event.Core.IRepositories
{
    public interface ICommentRepository
    {
        Task<int> PostComment(Comment response);
        Task<IList<Comment>> GetComments();
        Task<Comment> ViewComment(int commentId);
        int EditComment(Comment response);
    }
}
