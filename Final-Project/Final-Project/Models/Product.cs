using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Final_Project.Models
{
    public class Product : BaseEntity
    {
    
        [NotMapped]
        public List<IFormFile> Photo { get; set; }
        public int Stock { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<ProductCategories> ProductCategories { get; set; }
        [NotMapped]
        public int CategoryId { get; set; }
        public List<ProductImages> ProductImages { get; set; }

    }
}
