namespace Final_Project.Models
{
    public class OrderItem:BaseEntity
    { 
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int? ProductId { get; set; }
        public string AppUserId { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
        public Order Order { get; set; }
    }
}
