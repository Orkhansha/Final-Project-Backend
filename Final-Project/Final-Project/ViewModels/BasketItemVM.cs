using Final_Project.Models;

namespace Final_Project.ViewModels
{
    public class BasketItemVM
    {
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
