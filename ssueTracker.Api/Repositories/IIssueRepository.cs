using IssueTracker.Api.Models;

namespace IssueTracker.Api.Repositories
{
    public interface IIssueRepository
    {
        Task<List<Issues>> GetAllIssues();
        Task<Issues> GetIssueById(int id);

        Task<Issues>CreateIssue(Issues issue);
        Task<Issues> UpdateIssue(Issues issue);
        Task<bool> DeleteIssue(int id);
       
    }
}
