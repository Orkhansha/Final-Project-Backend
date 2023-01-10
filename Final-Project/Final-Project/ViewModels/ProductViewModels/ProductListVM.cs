using Final_Project.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.ViewModels.ProductViewModels
{
    public class ProductListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string Images { get; set; }
        public string CategoryName { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public string MainImage { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

        //public ShopBanner ShopBanner { get; set; }
        public Product Product { get; set; }
    }
}
