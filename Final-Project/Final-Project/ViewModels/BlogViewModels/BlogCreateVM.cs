using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Final_Project.ViewModels.BlogViewModels
{
    public class BlogCreateVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
    }
}
