using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CommentRepository(ApplicationDbContext context) : ICommentRepository
    {
        private readonly ApplicationDbContext _context = context;
        public Task<Comment> CreateAsync(Comment commentModel)
        {
            throw new NotImplementedException();
        }

        public Task<Comment?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAllAsync() => await _context.Comments.ToListAsync();

        public Task<Comment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}