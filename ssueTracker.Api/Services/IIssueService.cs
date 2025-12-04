using IssueTracker.Api.DTOsModel;
using IssueTracker.Api.Models;

namespace IssueTracker.Api.Services
{
    public interface IIssueService
    {
        Task<List<ResponseIssueDTO>> GetIssues();
        Task<Issues>GetIssueById(int id);
        Task<Issues>CreateIssue(CreateIssueDTO issue);
        Task<Issues>UpdateIssue(Issues issue);
        Task<bool>DeleteIssue(int id);
    }
}
