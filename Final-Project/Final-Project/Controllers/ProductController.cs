using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int sortId, int page = 1)
        {
            ViewBag.Categories = _context.Categories.Where(p => !p.IsDeleted)
                .Include(p => p.ProductCategories)
                .ThenInclude(p => p.Category)
                .ToList();
            
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Products.Where(p => !p.IsDeleted).Count() / 3);
            ViewBag.id = sortId;
            List<Product> products = await _context.Products.Where(p => !p.IsDeleted).Include(p=>p.ProductImages).Include(p=>p.ProductCategories).ThenInclude(p=>p.Category).Where(p => p.IsDeleted == false).ToListAsync();
            
            switch (sortId)
            {
                case 1:
                    products = await _context.Products.Include(p => p.ProductCategories).ThenInclude(p => p.Category).Where(p => p.IsDeleted == false).ToListAsync();
                    break;
                case 2:
                    products = await _context.Products.Include(p => p.ProductCategories).ThenInclude(p => p.Category).Where(p => p.IsDeleted == false).OrderByDescending(s => s.Title).ToListAsync();
                    break;
                case 3:
                    products = await _context.Products.Include(p => p.ProductCategories).ThenInclude(p => p.Category).Where(p => p.IsDeleted == false).OrderBy(s => s.Title).ToListAsync();
                    break;
                case 4:
                    products = await _context.Products.Include(p => p.ProductCategories).ThenInclude(p => p.Category).Where(p => p.IsDeleted == false).OrderByDescending(s => s.Price).ToListAsync();
                    break;
                case 5:
                    products = await _context.Products.Include(p => p.ProductCategories).ThenInclude(p => p.Category).Where(p => p.IsDeleted == false).OrderBy(s => s.Price).ToListAsync();
                    break;
                case 6:
                    products = await _context.Products.Include(p => p.ProductCategories).ThenInclude(p => p.Category).Where(p => p.IsDeleted == false && p.Price>=30 &&p.Price<=40).ToListAsync();
                    break;
                default:

                    break;
            }
            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
           
            Product product = await _context.Products
                .Include(p=>p.ProductImages)
                .Include(p=>p.ProductCategories)
                .ThenInclude(p=>p.Category)
                .Where(p=>!p.IsDeleted)
                .FirstOrDefaultAsync(x => x.Id == id);
            return View(product);
        }
        public IActionResult ProductSearch(string search)
        {
            List<Product> searchItem = _context.Products.Where(p => p.Title.ToLower().Contains(search.ToLower()) &&!p.IsDeleted).ToList();
            return PartialView("_SearchProduct", searchItem);
        }
    }
}
