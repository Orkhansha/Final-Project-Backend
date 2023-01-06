namespace Final_Project.Models
{
    public class ProductCategories : BaseEntity
    {
      
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
