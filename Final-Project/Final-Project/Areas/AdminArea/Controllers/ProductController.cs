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
              .Include(m => m.ProductImages)
              .Include(m => m.ProductCategories)
              .ToListAsync();
            return View(products);

        }





        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View();


            List<ProductImages> Images = new List<ProductImages>();
            foreach (var item in product.Photo)
            {

                ProductImages image = new ProductImages();
                image.ImageUrl = await item.SaveImage(_env, "img/products");
                Images.Add(image);
            }
            product.ProductImages = Images;
            product.ProductImages[0].IsMain = true;
            product.ProductCategories = new List<ProductCategories>();

            //foreach (var categoryId in product.CategoryId)
            //{
            ProductCategories pCategory = new ProductCategories
            {
                Product = product,
                CategoryId = product.CategoryId,
            };
            _context.ProductCategories.Add(pCategory);





            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            Product product = await _context.Products.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == id);

            return View(product);
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
                                 .Include(m => m.CategoryId)
                                 .Include(m => m.ProductImages)
                                 .FirstOrDefaultAsync();
        }


        ///__Isleyen edit__/////
        //[HttpGet]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    try
        //    {
        //        if (id is null) return BadRequest();

        //        ViewBag.categories = await GetCategoriesAsync();

        //        Product product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

        //        if (product is null) return NotFound();

        //        return View(product);

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Message = ex.Message;
        //        return View();
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Product product)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(product);
        //        }

        //        Product dbProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

        //        if (dbProduct is null) return NotFound();

        //        if (dbProduct.Title.ToLower().Trim() == product.Title.ToLower().Trim() 
        //            && dbProduct.Price == product.Price 
        //            && dbProduct.Description == product.Description)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }

        //        dbProduct.CategoryId = product.CategoryId;
        //        dbProduct.Title = product.Title;
        //        dbProduct.Price = product.Price;
        //        dbProduct.Description = product.Description;
        //        dbProduct.ProductImages = product.ProductImages;

        //        _context.Products.Update(product);

        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Message = ex.Message;
        //        return View();
        //    }
        //}


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            ViewBag.categories = await GetCategoriesAsync();

            Product dbProduct = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            return View(new ProductUpdateVM
            {
                Id = dbProduct.Id,
                Title = dbProduct.Title,
                Description = dbProduct.Description,
                Price = dbProduct.Price.ToString("0.#####").Replace(",", "."),
                CategoryId = dbProduct.CategoryId,
                Images = dbProduct.ProductImages
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductUpdateVM updatedProduct)
        {
            ViewBag.categories = await GetCategoriesAsync();

            if (!ModelState.IsValid) return View(updatedProduct);

            Product dbProduct = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (updatedProduct.Photos != null)
            {

                foreach (var photo in updatedProduct.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View(updatedProduct);
                    }


                    if (!photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View(updatedProduct);
                    }

                }

                //foreach (var item in dbProduct.ProductImages)
                //{
                //    string path = Helper.GetFilePath(_env.WebRootPath, "img/products", item.ImageUrl);
                //    Helper.DeleteFile(path);
                //}


                List<ProductImages> images = new List<ProductImages>();

                foreach (var photo in updatedProduct.Photos)
                {

                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = Helper.GetFilePath(_env.WebRootPath, "img/products", fileName);

                    await Helper.SaveFile(path, photo);


                    ProductImages image = new ProductImages
                    {
                        ImageUrl = fileName,
                    };

                    images.Add(image);

                }

                images.FirstOrDefault().IsMain = true;

                dbProduct.ProductImages = images;

            }

            decimal convertedPrice = StringToDecimal(updatedProduct.Price);

            dbProduct.Title = updatedProduct.Title;
            dbProduct.ProductImages = (List<ProductImages>)updatedProduct.Images;
            dbProduct.Price = convertedPrice;
            dbProduct.CategoryId = updatedProduct.CategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
