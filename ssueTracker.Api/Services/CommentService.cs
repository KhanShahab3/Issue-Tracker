using IssueTracker.Api.Models;
using IssueTracker.Api.Repositories;

namespace IssueTracker.Api.Services
{
    public class CommentService:ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<List<Comments>> GetAllComments()
        {
            var comments = await _commentRepository.GetAllComments();   
            return comments;
        }
        public async Task<Comments>GetCommentById(int id)
        {
            var comment=await _commentRepository.GetCommentById(id);    
            return comment;
        }
        public async Task<Comments>CreateComment(Comments comment)
        {
            await _commentRepository.CreateComment(comment);
            return comment;
        }
        public async Task<Comments>UpdateComment(Comments comment)
        {
            await _commentRepository.UpdateComment(comment);
            return comment;
        }
        public async Task<bool>DeleteComment(int id)
        {
            await _commentRepository.DeleteComment(id);
            return true;
        }
    }
}
