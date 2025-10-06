using IssueTracker.Api.Models;

namespace IssueTracker.Api.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Projects>> GetAllProjects();
        Task<Projects> GetProjectById(int id);
        Task<Projects> CreateProject(Projects project);
        Task<Projects>UpdateProject(Projects project);
        Task<bool> DeleteProject(int id);

    }
}
