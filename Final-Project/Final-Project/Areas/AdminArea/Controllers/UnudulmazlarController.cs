using Final_Project.Data;
using Final_Project.Helpers;
using Final_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class UnudulmazlarController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _env;

        public UnudulmazlarController(IWebHostEnvironment env, AppDbContext context)
        {
            _env = env;
            _context = context;
        }

        public IActionResult Index()
        {
            List<UnudulmazlarVideo> u = _context.UnudulmazlarVideo.Where(m => !m.IsDeleted).ToList();
            return View(u);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnudulmazlarVideo UnudulmazlarVideo)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!UnudulmazlarVideo.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Sekil Formati secin");
            }

            if (UnudulmazlarVideo.Photo.CheckFileSize(20000))
            {
                ModelState.AddModelError("Photo", "Sekil 20 mb-dan boyuk ola bilmez");
            }


            UnudulmazlarVideo db = new UnudulmazlarVideo();

            string filename = await UnudulmazlarVideo.Photo.SaveImage(_env, "img/Unudulmazlar-card");
            if (UnudulmazlarVideo.VideoFile != null)
            {

                string videoname = await UnudulmazlarVideo.VideoFile.SaveVideo(_env, "img/Unudulmazlar-card");
                db.Video = videoname;
            }

            db.Image = filename;
            db.Name = UnudulmazlarVideo.Name;
            db.Rutbe = UnudulmazlarVideo.Rutbe;
            db.Haqqında = UnudulmazlarVideo.Haqqında;
            db.Birthday = UnudulmazlarVideo.Birthday;

            _context.UnudulmazlarVideo.Add(db);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UnudulmazlarVideo UnudulmazlarVideo = _context.UnudulmazlarVideo.Find(id);
            if (UnudulmazlarVideo == null)
            {
                return NotFound();
            }
            return View(UnudulmazlarVideo);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int? id, UnudulmazlarVideo UnudulmazlarVideo)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!UnudulmazlarVideo.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Sekil Formati secin");
            }

            if (UnudulmazlarVideo.Photo.CheckFileSize(20000))
            {
                ModelState.AddModelError("Photo", "Sekil 20 mb-dan boyuk ola bilmez");
            }
            UnudulmazlarVideo db = _context.UnudulmazlarVideo.Find(id);

            if (db == null)
            {
                return NotFound();
            }
            if (db.Image != null)
            {
                Helper.DeleteImage(_env, "img/Unudulmazlar-card", db.Image);
            }
            if (db.Image != null)
            {

                Helper.DeleteImage(_env, "img/Unudulmazlar-card", db.Image);
            }
            string filename = await UnudulmazlarVideo.Photo.SaveImage(_env, "img/Unudulmazlar-card");
            UnudulmazlarVideo existName = _context.UnudulmazlarVideo.FirstOrDefault(x => x.Name.ToLower() == UnudulmazlarVideo.Name.ToLower());
            string videoname = await UnudulmazlarVideo.VideoFile.SaveImage(_env, "img/Unudulmazlar-card");

            if (existName != null)
            {
                if (db != existName)
                {
                    ModelState.AddModelError("Name", "Name Already Exist");
                    return View();
                }
            }
            db.Video = videoname;
            db.Image = filename;
            db.Name = UnudulmazlarVideo.Name;
            db.Rutbe = UnudulmazlarVideo.Rutbe;
            db.Haqqında = UnudulmazlarVideo.Haqqında;
            db.Birthday = UnudulmazlarVideo.Birthday;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            UnudulmazlarVideo unudulmazlar = _context.UnudulmazlarVideo.FirstOrDefault(c => c.Id == id);
            unudulmazlar.IsDeleted = true;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }


        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UnudulmazlarVideo UnudulmazlarVideo = _context.UnudulmazlarVideo.Find(id);
            if (UnudulmazlarVideo == null)
            {
                return NotFound();
            }
            return View(UnudulmazlarVideo);
        }
    }
}
