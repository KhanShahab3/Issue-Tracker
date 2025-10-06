using IssueTracker.Api.DataContext;
using IssueTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Api.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comments>> GetAllComments()
        {
            //var comments = new List<Comments>();
           var comments = await _context.Comments.ToListAsync();
            return comments;  
        }
        public async Task<Comments>GetCommentById(int id)
        {
            var comment=await _context.Comments.FindAsync(id);
            return comment;
        }
        public async Task<Comments>CreateComment(Comments comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
        public async Task<Comments>UpdateComment(Comments comment)
        {
            var isComment = await _context.Comments.FindAsync(comment.Id);
            if (isComment != null)
            {
                isComment.Id = comment.Id;
                isComment.IssueId = comment.IssueId;
                isComment.Content = comment.Content;
                isComment.CreatedAt = comment.CreatedAt;
                _context.Comments.Update(isComment);  
               
            }
            return comment;
        }
        public async Task<bool> DeleteComment(int id)
        {
            var isComment = await _context.Comments.FindAsync(id);
            if (isComment != null)
            {
                _context.Remove(isComment);
                return true;

            }
            return false;
        }
    }
}
