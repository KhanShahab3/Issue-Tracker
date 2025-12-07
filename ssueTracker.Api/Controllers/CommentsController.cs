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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAllComments();
            if (comments.Count == 0)
            {
                return NotFound();
            }
            return Ok(comments);

                
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment == null)
            {

                return NotFound();
            }
            return Ok(comment);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comments comment)
        {
            var isComment = await _commentService.UpdateComment(comment);
            if (isComment != null)
            {
                return Ok(comment);

            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentsDTO comment)
        {
            var createComment = await _commentService.CreateComment(comment);
            if (createComment == null)
            {

                return BadRequest();
            }
            return Ok(createComment);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult>DeleteComment(int id)
        {
            await _commentService.DeleteComment(id);
            return Ok();
        }



    }
}
