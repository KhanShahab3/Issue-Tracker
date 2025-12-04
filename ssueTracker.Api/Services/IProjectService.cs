using IssueTracker.Api.DTOsModel;
using IssueTracker.Api.Models;

namespace IssueTracker.Api.Services
{
    public interface IProjectService
    {
        Task<List<Projects>>GetAllProjects();
        Task<Projects> GetProjectById(int id);
        Task<Projects>UpdateProject(Projects project);
        Task<Projects>CreateProject(CreateProjectDTO project);
        Task<bool> DeleteProject(int id);

    }
}
