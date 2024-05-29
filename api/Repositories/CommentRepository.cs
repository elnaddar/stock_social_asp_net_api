using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CommentRepository(ApplicationDbContext context) : ICommentRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await GetByIdAsync(id);
            if (comment is null)
            {
                return null;
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync() => await _context.Comments.ToListAsync();

        public async Task<Comment?> GetByIdAsync(int id) => await _context.Comments.FindAsync(id);

        public async Task<Comment?> UpdateAsync(int id, CommentUpdateDto commentDto)
        {
            var comment = await GetByIdAsync(id);
            if (comment is null)
            {
                return null;
            }
            comment.FromUpdateDto(commentDto);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}