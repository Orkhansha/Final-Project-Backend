using Final_Project.Models;
using System.Collections.Generic;

namespace Final_Project.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Aksesuar> Aksesuars { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Geyim> Geyims { get; set; }
        public IEnumerable<Qarishiq> Qarishiqs { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Uniforma> Uniformas { get; set; }
        public IEnumerable<UnudulmazlarCard> UnudulmazlarCards { get; set; }
        public IEnumerable<UnudulmazlarVideo> UnudulmazlarVideos { get; set; }

    }
}
