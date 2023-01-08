using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class Slider: BaseEntity
    {
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
