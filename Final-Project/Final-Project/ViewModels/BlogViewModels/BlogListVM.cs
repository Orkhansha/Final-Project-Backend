using Final_Project.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.ViewModels.BlogViewModels
{
    public class BlogListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public string Images { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }

        public string MainImage { get; set; }

        public Blog Blog { get; set; }
    }
}
