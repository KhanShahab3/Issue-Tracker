using IssueTracker.Api.DTOsModel;
using IssueTracker.Api.Models;
using IssueTracker.Api.Repositories;
using IssueTracker.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService) { 
        
        _projectService = projectService;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllProjects()
        {
            var projects=await _projectService.GetAllProjects();
            if (projects.Count == 0) { 
            return NotFound();
            }
            return Ok(projects);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetProjectById(int id)
        {
           var project=await _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
        [HttpPost]
        public async Task<IActionResult>CreateProject(CreateProjectDTO project)
        {
           var createdProject=await _projectService.CreateProject(project);
            if (createdProject == null)
            {
                return BadRequest();
            }
            return Ok(createdProject);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProject(Projects project)
        {
            var updatedProject = await _projectService.UpdateProject(project);
            if (updatedProject == null)
            {
                return BadRequest();
            }
            return Ok(updatedProject);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult>DeleteProject(int id)
        {
            await _projectService.DeleteProject(id);    
            return Ok();
        }

    }
}
