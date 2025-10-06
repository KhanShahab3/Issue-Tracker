using IssueTracker.Api.DataContext;
using IssueTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Api.Repositories
{
    public class IssueRepository:IIssueRepository
    {
        private readonly AppDbContext _appDbContext;
        public IssueRepository(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
        }
        public async Task<List<Issues>> GetAllIssues()
        {
            var issues=await _appDbContext.Issues.ToListAsync();
            return issues;

        }
        public async Task<Issues>GetIssueById(int id)
        {
            var issue=await _appDbContext.Issues.FindAsync(id);
            return issue;
        }
        public async Task<Issues>CreateIssue(Issues issue)
        {
            await _appDbContext.Issues.AddAsync(issue);
            await _appDbContext.SaveChangesAsync();
            return issue;
        }
        public async Task<Issues>UpdateIssue(Issues issues)
        {
            var issue = await _appDbContext.Issues.FindAsync(issues.Id);
            if (issue != null)
            {
                issue.Id = issues.Id;
                issue.ProjectId = issues.ProjectId;
                issue.ProjectId = issue.ProjectId;

            }
           _appDbContext.Issues.Update(issue);
            return issue;

        }
        public async Task<bool> DeleteIssue(int id)
        {
            var isIssue = await _appDbContext.Issues.FindAsync(id);
            {
                if (isIssue != null)
                {
                    _appDbContext.Issues.Remove(isIssue);
                    return true;

                }
                return false;
            }
        }
          
    }
}
