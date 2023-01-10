using Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aksesuar> Aksesuars { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Geyim> Geyims { get; set; }
        public DbSet<Qarishiq> Qarishiqs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Uniforma> Uniformas { get; set; }
        public DbSet<UnudulmazlarCard> UnudulmazlarCards { get; set; }
        public DbSet<UnudulmazlarVideo> UnudulmazlarVideo { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<BlogImages> BlogImages { get; set; }

        //public DbSet<Size> Sizes { get; set; }









        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
