using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentCreateDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "Title length can't be less than 10 charachters.")]
        [MaxLength(280, ErrorMessage = "Title length can't be over 280 charachters.")]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [MinLength(50, ErrorMessage = "Content length can't be less than 50 charachters.")]
        [MaxLength(1000, ErrorMessage = "Content length can't be over 1000 charachters.")]
        public string Content { get; set; } = string.Empty;
    }
}