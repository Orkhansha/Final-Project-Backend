using Final_Project.Data;
using Final_Project.Helpers;
using Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Brand> brands = await _context.Brands
              .Where(m => !m.IsDeleted)
              .ToListAsync();
            return View(brands);

        }
        #region

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            if (brand.Photo != null)
            {
                if (!brand.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Düzgün formatda fayl seçin");
                    return View();
                }
                if (!brand.Photo.CheckFileSize(2000))
                {
                    ModelState.AddModelError("Photo", "Faylın ölçüsü maksimum 2Mb ola bilər");
                    return View();
                }
                brand.Image = await brand.Photo.SaveImage(_env, "img/Brands");
            }
            else
            {
                ModelState.AddModelError("Photo", "Fayl seçin");
                return View();
            }

            _context.Brands.Add(brand);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));


        }



        public async Task<IActionResult> Delete(int id)
        {
            Brand brand = await _context.Brands
                .Where(m => !m.IsDeleted)
                .FirstOrDefaultAsync(m => m.Id == id);

            brand.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }



        private decimal StringToDecimal(string str)
        {
            return decimal.Parse(str.Replace(".", ","));
        }

        private async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Brands
                                 .Where(m => !m.IsDeleted && m.Id == id)
                                 .FirstOrDefaultAsync();
        }

        #endregion

        public IActionResult Edit(int id)
        {

            Brand brand = _context.Brands.FirstOrDefault(b => b.Id == id);
            if (brand == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Brand brand)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!brand.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Sekil Formati secin");
            }

            if (brand.Photo.CheckFileSize(20000))
            {
                ModelState.AddModelError("Photo", "Sekil 20 mb-dan boyuk ola bilmez");
            }
            Brand db = _context.Brands.Find(id);
            if (db == null)
            {
                return NotFound();
            }
            Helper.DeleteImage(_env, "img/Brands", db.Image);
            string filename = await brand.Photo.SaveImage(_env, "img/Brands");



            db.Image = filename;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
