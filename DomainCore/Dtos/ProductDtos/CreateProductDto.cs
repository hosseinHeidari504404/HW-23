using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainCore.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than Zero")]
        public decimal Price { get; set; }
        [MaxLength(300)]
        [Required]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be greater than Zero")]
        public int Count { get; set; }
    }
}
