using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController(ICommentRepository repo) : ControllerBase
    {
        private readonly ICommentRepository _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _repo.GetAllAsync();
            var commentsDto = comments.Select(c => c.ToCommentDto());
            return Ok(comments);
        }
    }
}