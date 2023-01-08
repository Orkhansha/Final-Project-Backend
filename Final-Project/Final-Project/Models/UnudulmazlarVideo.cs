

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class UnudulmazlarVideo: BaseEntity
    {
        public string Image { get; set; }
        [NotMapped]
        public IFormFile    Photo { get; set; }
        public string Video { get; set; }
        [NotMapped]
        public IFormFile VideoFile { get; set; }
        
        public string Name { get; set; }
        public string Rutbe { get; set; }
        public string Haqqında { get; set; }
        public string Birthday { get; set; }

    }
}
