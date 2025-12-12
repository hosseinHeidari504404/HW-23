using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainCore.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Name must have at least 2 Charecters")]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 Charecters")]
        [Required]
        public string Name { get; set; }
        [MinLength(2, ErrorMessage = "Description must have at least 2 Charecters")]
        [MaxLength(300, ErrorMessage = "Description must be less than 300 Charecters")]
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than Zero")]
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public IFormFile? ImageFile { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be greater than Zero")]
        public int Count { get; set; }
    }
}
