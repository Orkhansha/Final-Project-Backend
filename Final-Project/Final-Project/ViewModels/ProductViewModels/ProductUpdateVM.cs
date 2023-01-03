using Final_Project.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Final_Project.ViewModels.ProductViewModels
{
    public class ProductUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductImages> Images { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
