using IssueTracker.Api.DataContext;
using IssueTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Api.Repositories
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<List<Projects>> GetAllProjects()
        {
            var projects=await _context.Projects.ToListAsync();
            return projects;
        }
        public async Task<Projects>GetProjectById(int id)
        {
            var project=await _context.Projects.FindAsync(id);
            return project;
        }

        public async Task<Projects>CreateProject(Projects project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }
        public async Task<Projects>UpdateProject(Projects projects)
        {
            var project=await _context.Projects.FindAsync(projects.Id);
            if (project != null)
            {
                project.ProjectName=projects.ProjectName;
                project.CreatedBy=projects.CreatedBy;
                project.CreatedAt=projects.CreatedAt;
                project.Description=projects.Description;
            }
            await _context.SaveChangesAsync();
            return projects;
        }
        public async Task<bool>DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if(project != null)
            {
                 _context.Remove(project);
                await _context.SaveChangesAsync();
                return true;

            }
            return false;
        }
    }
}
