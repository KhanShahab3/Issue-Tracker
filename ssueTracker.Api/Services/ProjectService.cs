using IssueTracker.Api.DTOsModel;
using IssueTracker.Api.Models;
using IssueTracker.Api.Repositories;

namespace IssueTracker.Api.Services
{
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<List<Projects>> GetAllProjects()
        {
            var projects=await _projectRepository.GetAllProjects();
            return projects;

        }
        public async Task<Projects>GetProjectById(int id)
        {
            var project =await _projectRepository.GetProjectById(id);
            return project;
        }
        public async Task<Projects>UpdateProject(Projects project)
        {
            await _projectRepository.UpdateProject(project);
            return project;

        }
        public async Task<Projects>CreateProject(CreateProjectDTO projectdto)
        {
            var project = new Projects
            {
                ProjectName = projectdto.ProjectName,
                Description = projectdto.Description,
                CreatedBy = projectdto.CreatedBy,
                CreatedAt = DateTime.UtcNow,
                isDeleted = false
            };
            await _projectRepository.CreateProject(project);
            return project;
        }
        public async Task<bool>DeleteProject(int id)
        {
            await _projectRepository.DeleteProject(id);
            return true;
        }
    }
}
