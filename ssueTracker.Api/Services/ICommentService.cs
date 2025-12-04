using IssueTracker.Api.Models;

namespace IssueTracker.Api.Services
{
    public interface ICommentService
    {
        Task<List<Comments>> GetAllComments();
        Task<Comments>GetCommentById(int id);
        Task<Comments>CreateComment(Comments comment);
        Task<Comments> UpdateComment(Comments comment);
        Task<bool> DeleteComment(int id);
    }
}
