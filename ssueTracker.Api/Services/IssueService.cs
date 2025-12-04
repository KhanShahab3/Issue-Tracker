using IssueTracker.Api.DTOsModel;
using IssueTracker.Api.Models;
using IssueTracker.Api.Repositories;

namespace IssueTracker.Api.Services
{
    public class IssueService:IIssueService
    {
        private readonly IIssueRepository _issue;
        public IssueService(IIssueRepository issue)
        {
            _issue = issue;
        }
        public async Task<List<ResponseIssueDTO>> GetIssues()
        {
            var issues = await _issue.GetAllIssues();
            return issues;
        }
        public async Task<Issues> GetIssueById(int id)
        {
            var issue = await _issue.GetIssueById(id);
            if (issue == null)
            {

                return null;
            }
            return issue;

        }
        public async Task<Issues>CreateIssue(CreateIssueDTO issue)
        {

            var newIssue = new Issues
            {
                Title = issue.Title,
                Description = issue.Description,
                ProjectId = issue.ProjectId,
                Status = issue.Status,
                Priority = issue.Priority,
                CreatedAt = DateTime.UtcNow,
                AssignedTo = issue.AssignedTo
            };
            await _issue.CreateIssue(newIssue);
            return newIssue;
        }
        public async Task<Issues>UpdateIssue(Issues issue)
        {
            await _issue.UpdateIssue(issue);
            return issue;
        }
        public async Task<bool>DeleteIssue(int id)
        {
            await _issue.DeleteIssue(id);
            return true;

        }
    }
}
