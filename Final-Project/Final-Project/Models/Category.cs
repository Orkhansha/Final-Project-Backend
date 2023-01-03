using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<ProductCategories> ProductCategories { get; set; }
    }
}
