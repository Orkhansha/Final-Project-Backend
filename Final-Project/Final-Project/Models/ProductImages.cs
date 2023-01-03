namespace Final_Project.Models
{
    public class ProductImages : BaseEntity
    {
        public string Image { get; set; }
        public bool IsMain { get; set; } = false;
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; }
    }
}
