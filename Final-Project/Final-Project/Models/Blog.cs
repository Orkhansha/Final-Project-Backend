using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Images { get; set; }
        [NotMapped]
        public IFormFile Photos { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
    }
}
