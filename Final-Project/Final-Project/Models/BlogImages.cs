using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class BlogImages : BaseEntity
    {
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        [NotMapped]
        public List<IFormFile> Photo { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
