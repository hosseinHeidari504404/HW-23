using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainCore.Dtos.CategoryDtos
{
    public class GetCategoryDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Name must have less than 20 charecters")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 charecters")]
        public string Name { get; set; }
        public int Id { get; set; }
        [Required]
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
        [MaxLength(400, ErrorMessage = "Description must have less than 400 charecters")]
        public string Description { get; set; }
    }
}
