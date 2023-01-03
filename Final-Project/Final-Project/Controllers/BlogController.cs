using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Final_Project.Controllers
{
    public class BlogController : Controller
    {
        private AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogDetails(int? id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            return View(blog);
        }

    }
}
