using IssueTracker.Api.DTOsModel;
using IssueTracker.Api.Models;
using IssueTracker.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIssues()
        {
            var issues=await _issueService.GetIssues();
            if (issues.Count == 0)
            {
                return NotFound();
            }
            return Ok(issues);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetIssueById(int id)
        {
            var issue=await _issueService.GetIssueById(id);
            if (issue == null)
            {
                return NotFound();
            }
            return Ok(issue);
        }
        [HttpPost]
        public async Task<IActionResult>CreateIssue(CreateIssueDTO issue)
        {
            var createdIssue=await _issueService.CreateIssue(issue);
            if (createdIssue == null)
            {

                return BadRequest();
            }
            return Ok(createdIssue);
        }
        [HttpPut]
        public async Task<IActionResult>UpdateIssue(Issues issue)
        {
            var isIssue=await _issueService.UpdateIssue(issue);
            if(isIssue == null)
            {
                return BadRequest();
            }
            return Ok(isIssue);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            await _issueService.DeleteIssue(id);
            return Ok();
        }
    }
}
