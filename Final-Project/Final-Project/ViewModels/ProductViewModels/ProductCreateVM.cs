using Final_Project.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Final_Project.ViewModels.ProductViewModels
{
    public class ProductCreateVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
        public ProductImages ProductImages { get; set; }
        public DateTime CreateTime { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
    }
}
