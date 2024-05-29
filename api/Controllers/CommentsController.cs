using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController(ICommentRepository repo, IStockRepository stockRepo) : ControllerBase
    {
        private readonly ICommentRepository _repo = repo;
        private readonly IStockRepository _stockRepo = stockRepo;

        [HttpGet(Name = "Comments.Index")]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _repo.GetAllAsync();
            var commentsDto = comments.Select(c => c.ToCommentDto());
            return Ok(comments);
        }

        [HttpGet("{id}", Name = "Comments.Show")]
        public async Task<IActionResult> Show([FromRoute] int id)
        {
            var comment = await _repo.GetByIdAsync(id);
            if (comment is null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost("{stockId}", Name = "Comments.Store")]
        public async Task<IActionResult> Post([FromRoute] int stockId, [FromBody] CommentCreateDto requestComment)
        {
            if (!await _stockRepo.IsExistsAsync(stockId))
            {
                return BadRequest("Stock does not exist.");
            }
            var comment = requestComment.ToComment(stockId);
            await _repo.CreateAsync(comment);
            return CreatedAtRoute("Comments.Show", new { id = comment.Id }, comment.ToCommentDto());
        }

        [HttpPut("{id}", Name = "Comments.Update")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CommentUpdateDto requestComment)
        {
            var comment = await _repo.UpdateAsync(id, requestComment);
            if (comment is null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("{id}", Name = "Commens.Destroy")]
        public async Task<IActionResult> Destroy([FromRoute] int id)
        {
            var comment = await _repo.DeleteAsync(id);
            if (comment is null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
    }
}