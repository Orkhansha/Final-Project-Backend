using Final_Project.Data;
using Final_Project.Helpers;
using Final_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Final_Project.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Reflection.Metadata;

namespace Final_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products
              .Where(m => !m.IsDeleted)
              .Include(m => m.ProductCategories)
              .ToListAsync();
            return View(products);

        }
        #region

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.Where(c=>!c.IsDeleted).ToList();
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = _context.Categories.Where(c => !c.IsDeleted).ToList();
             


            if (!ModelState.IsValid)
            {
                return View();
            }

          
            product.ProductCategories = new List<ProductCategories>();
            if (product.Photo != null)
            {
                if (!product.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Choose correct image format file");
                    return View();
                }
                if (!product.Photo.CheckFileSize(2000))
                {
                    ModelState.AddModelError("Photo", "File must be max 2000mb");
                    return View();
                }
                product.Image =await product.Photo.SaveImage(_env, "img/products");
            }
            else
            {
                ModelState.AddModelError("Photo", "Choose Image");
                return View();
            }
            

            if (product.CategoryIds != null)
            {
                foreach (var categoryId in product.CategoryIds)
                {
                    ProductCategories productCategories = new ProductCategories
                    {
                        Product = product,
                        CategoryId = categoryId
                    };
                    _context.ProductCategories.Add(productCategories);
                }
            }
            
            

            _context.Products.Add(product);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));


        }



        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products
                .Where(m => !m.IsDeleted)
                //.Include(m => m.ProductImages)
                .FirstOrDefaultAsync(m => m.Id == id);



            product.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }



        private decimal StringToDecimal(string str)
        {
            return decimal.Parse(str.Replace(".", ","));
        }

        private async Task<SelectList> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.IsDeleted).ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }

        private async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                                 .Where(m => !m.IsDeleted && m.Id == id)
                                 //.Include(m => m.CategoryIds)
                                 .FirstOrDefaultAsync();
        }

        #endregion

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories.Where(c => !c.IsDeleted).ToList();
             

            Product product = _context.Products.Include(b => b.ProductCategories).ThenInclude(bc => bc.Category).FirstOrDefault(b => b.Id == id);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            ViewBag.Categories = _context.Categories.Where(c => !c.IsDeleted).ToList();
            

            Product existProduct = _context.Products.Include(b => b.ProductCategories).ThenInclude(bc => bc.Category).FirstOrDefault(x => x.Id == product.Id);



            if (existProduct == null)
            {
                return RedirectToAction("index");
            }
            if (product.Photo != null)
            {
                if (!product.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Choose correct format file");
                    return View(existProduct);
                }
                if (!product.Photo.CheckFileSize(20000))
                {
                    ModelState.AddModelError("Photo", "File must be max 20000mb");
                    return View(existProduct);
                }
                Helpers.Helper.DeleteImage(_env, "img/products", existProduct.Image);
                existProduct.Image =await product.Photo.SaveImage(_env, "img/products");


            }



            if (!ModelState.IsValid)
            {
                return View(existProduct);
            }
            
            
            var existCategories = _context.ProductCategories.Where(x => x.ProductId == product.Id).ToList();
            if (product.CategoryIds != null)
            {
                foreach (var categoryId in product.CategoryIds)
                {
                    var existCategory = existCategories.FirstOrDefault(x => x.CategoryId == categoryId);
                    if (existCategory == null)
                    {
                        ProductCategories productCategories = new ProductCategories
                        {
                            ProductId = product.Id,
                            CategoryId = categoryId,
                        };

                        _context.ProductCategories.Add(productCategories);
                    }
                    else
                    {
                        existCategories.Remove(existCategory);
                    }
                }

            }
            _context.ProductCategories.RemoveRange(existCategories);


             

            existProduct.Title = product.Title;
            existProduct.Stock = product.Stock;
            existProduct.Description = product.Description;
            existProduct.Price = product.Price;
            


            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
