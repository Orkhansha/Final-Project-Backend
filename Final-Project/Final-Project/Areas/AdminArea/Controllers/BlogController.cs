using Final_Project.Data;
using Final_Project.Helpers;
using Final_Project.Models;
using Final_Project.ViewModels.BlogViewModels;
using Final_Project.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            List<Blog> blogs = await _context.Blogs
                .Where(m => !m.IsDeleted)
                .Include(m => m.BlogImages)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<BlogListVM> mapDatas = GetMapDatas(blogs);

            int count = await GetPageCount(take);

            Paginate<BlogListVM> result = new Paginate<BlogListVM>(mapDatas, page, count);

            return View(result);
        }


        private async Task<int> GetPageCount(int take)
        {
            int productCount = await _context.Blogs.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }

        private List<BlogListVM> GetMapDatas(List<Blog> blogs)
        {
            List<BlogListVM> blogList = new List<BlogListVM>();

            foreach (var blog in blogs)
            {
                BlogListVM newBlog = new BlogListVM
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Images = blog.Images,
                    Description= blog.Description,
                    MainImage = blog.BlogImages.Where(m => m.IsMain).FirstOrDefault()?.ImageUrl,
                };

                blogList.Add(newBlog);
            }

            return blogList;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
     
        public async Task<IActionResult> Create(Blog blog)
        {

            if (!ModelState.IsValid) return View();
            if (blog.Photos != null)
            {
                if (!blog.Photos.IsImage())
                {
                    ModelState.AddModelError("Photo", "Sekil formati duzgun deyil");
                    return View();
                }
                if (!blog.Photos.CheckFileSize(20000))
                {
                    ModelState.AddModelError("Photo", "Max 2mb ola biler");
                    return View();
                }
                blog.Images = await blog.Photos.SaveImage(_env, "img/Blogs");
            }
            else
            {
                ModelState.AddModelError("Photo", "Sekil elave edin");
                return View();
            }

            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Delete(int id)
        {
            Blog blog = await _context.Blogs
                .Where(m => !m.IsDeleted && m.Id == id)
                .Include(m => m.BlogImages)
                .FirstOrDefaultAsync();

            if (blog == null) return NotFound();

            foreach (var item in blog.BlogImages)
            {
                string path = Helper.GetFilePath(_env.WebRootPath, "/img/Blogs", item.ImageUrl);

                Helper.DeleteFile(path);
                item.IsDeleted = true;
            }

            blog.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();


            Blog dbBlog = await GetByIdAsync((int)id);

            return View(new BlogEditVM
            {
                Id = dbBlog.Id,
                Title = dbBlog.Title,
                Description = dbBlog.Description,
                CreateTime = DateTime.Now
                //CategoryId = dbProduct.CategoryId,
                //Photos = dbBlog.BlogImages
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogEditVM updatedBlog)
        {

            if (!ModelState.IsValid) return View(updatedBlog);

            Blog dbBlog = await GetByIdAsync(id);

            if (updatedBlog.Photos != null)
            {

                foreach (var photo in updatedBlog.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View(updatedBlog);
                    }


                    if (!photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View(updatedBlog);
                    }

                }

                foreach (var item in dbBlog.BlogImages)
                {
                    string path = Helper.GetFilePath(_env.WebRootPath, "img", item.ImageUrl);
                    Helper.DeleteFile(path);
                }


                List<BlogImages> images = new List<BlogImages>();

                foreach (var photo in updatedBlog.Photos)
                {

                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = Helper.GetFilePath(_env.WebRootPath, "img", fileName);

                    await Helper.SaveFile(path, photo);


                    BlogImages image = new BlogImages
                    {
                        ImageUrl = fileName,
                    };

                    images.Add(image);

                }

                images.FirstOrDefault().IsMain = true;

                dbBlog.BlogImages = images;

            }


            dbBlog.Title = updatedBlog.Title;
            //dbBlog.BlogImages = updatedBlog.Images;
            dbBlog.Description = updatedBlog.Description;
            //dbProduct.CategoryId = updatedProduct.CategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private decimal StringToDecimal(string str)
        {
            return decimal.Parse(str.Replace(".", ","));
        }

        private async Task<Blog> GetByIdAsync(int id)
        {
            return await _context.Blogs
                                 .Where(m => !m.IsDeleted)
                                 .Include(m => m.BlogImages)
                                 .FirstOrDefaultAsync(m=> m.Id == id);
        }
    }
}
