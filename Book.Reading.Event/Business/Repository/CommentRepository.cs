using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Book.Reading.Event.Core.Entities;
using Book.Reading.Event.Business.Data;
using Book.Reading.Event.Core.IRepositories;
using Book.Reading.Event.Business.Repository.Base;

namespace Book.Reading.Event.Business.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly EventContext _commentContext;
        public CommentRepository(EventContext commentContext) : base(commentContext)
        {
            this._commentContext = commentContext;
        }

        public async Task<int> PostComment(Comment response)
        {
            var newComment = new Comment()
            {
                comment = response.comment,
                EventId = response.EventId
            };
            await _commentContext.comment.AddAsync(newComment);
            _commentContext.SaveChanges();
            return newComment.Id;
        }

        public async Task<IList<Comment>> GetComments()
        {
            return await _commentContext.comment.OrderBy(x => x.timestamp).ToListAsync();
        }

        public async Task<Comment> ViewComment(int commentId)
        {
            return await _commentContext.comment.FindAsync(commentId);
        }

        public int EditComment(Comment response)
        {
            _commentContext.comment.Update(response);
            _commentContext.SaveChanges();
            return response.Id;
        }
    }
}
