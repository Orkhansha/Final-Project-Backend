using Final_Project.Data;
using Final_Project.Models;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            Blog blog = await _context.Blogs.FirstOrDefaultAsync();
            IEnumerable<Aksesuar> aksesuars = await _context.Aksesuars.ToListAsync();
            IEnumerable<Banner> banners = await _context.Banners.ToListAsync();
            IEnumerable<Brand> brands = await _context.Brands.ToListAsync();
            IEnumerable<Geyim> geyims = await _context.Geyims.ToListAsync();
            IEnumerable<Qarishiq> qarishiqs = await _context.Qarishiqs.ToListAsync();
            IEnumerable<Service> services = await _context.Services.ToListAsync();
            IEnumerable<Product> products = await _context.Products.Include(p=>p.ProductImages).Include(p=>p.ProductCategories)
                .ThenInclude(p=>p.Category).Where(p=>!p.IsDeleted).ToListAsync();
            IEnumerable<Uniforma> uniformas = await _context.Uniformas.ToListAsync();
            IEnumerable<UnudulmazlarCard> unudulmazlarCards = await _context.UnudulmazlarCards.ToListAsync();
            IEnumerable<UnudulmazlarVideo> unudulmazlarVideos = await _context.UnudulmazlarVideo.ToListAsync();


            HomeVM model = new HomeVM
            {
                Blog = blog,
                Sliders = sliders,
                Aksesuars = aksesuars,
                Banners = banners,
                Brands = brands,
                Geyims = geyims,
                Qarishiqs = qarishiqs,
                Services = services,
                Uniformas = uniformas,
                UnudulmazlarCards = unudulmazlarCards,
                UnudulmazlarVideos = unudulmazlarVideos,
                Products = products
            };
            return View(model);
        }

     
        public IActionResult Martyrs(string search)
        {
            List<UnudulmazlarCard> searchItem = _context.UnudulmazlarCards.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();
            return PartialView("_Martyrs", searchItem);
        }
    }
}
