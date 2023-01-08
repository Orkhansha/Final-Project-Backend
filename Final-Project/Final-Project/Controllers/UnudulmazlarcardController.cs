using Final_Project.Data;
using Final_Project.Helpers;
using Final_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    [Area("AdminArea")]
    public class UnudulmazlarCardController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _env;

        public UnudulmazlarCardController(IWebHostEnvironment env, AppDbContext context)
        {
            _env = env;
            _context = context;
        }

        public IActionResult Index()
        {
            List<UnudulmazlarCard> u = _context.UnudulmazlarCards.Where(m => !m.IsDeleted).ToList();
            return View(u);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnudulmazlarCard UnudulmazlarCard)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!UnudulmazlarCard.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Sekil Formati secin");
            }

            if (UnudulmazlarCard.Photo.CheckFileSize(20000))
            {
                ModelState.AddModelError("Photo", "Sekil 20 mb-dan boyuk ola bilmez");
            }


            UnudulmazlarCard db = new UnudulmazlarCard(); 
            string filename = await UnudulmazlarCard.Photo.SaveImage(_env, "img/Unudulmazlar-card");
            

            db.Image = filename;
            db.Name = UnudulmazlarCard.Name;
            db.Rutbe = UnudulmazlarCard.Rutbe;
            db.Haqqında = UnudulmazlarCard.Haqqında;
            db.Birthday = UnudulmazlarCard.Birthday;
            
            _context.UnudulmazlarCards.Add(db); 

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UnudulmazlarCard UnudulmazlarCard = _context.UnudulmazlarCards.Find(id);
            if (UnudulmazlarCard == null)
            {
                return NotFound();
            }
            return View(UnudulmazlarCard);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int? id, UnudulmazlarCard UnudulmazlarCard)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!UnudulmazlarCard.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Sekil Formati secin");
            }

            if (UnudulmazlarCard.Photo.CheckFileSize(20000))
            {
                ModelState.AddModelError("Photo", "Sekil 20 mb-dan boyuk ola bilmez");
            }
            UnudulmazlarCard db = _context.UnudulmazlarCards.Find(id); 
            if (db == null)
            {
                return NotFound();
            }
            if (db .Image != null)
            {
                Helper.DeleteImage(_env, "img/Unudulmazlar-card", db.Image);
            }
            if (db .Image != null)
            {

                Helper.DeleteImage(_env, "img/Unudulmazlar-card", db .Image);
            }
            string filename = await UnudulmazlarCard.Photo.SaveImage(_env, "img/Unudulmazlar-card");
            UnudulmazlarCard existName = _context.UnudulmazlarCards.FirstOrDefault(x => x.Name.ToLower() == UnudulmazlarCard.Name.ToLower());
            
            if (existName != null)
            {
                if (db != existName)
                {
                    ModelState.AddModelError("Name", "Name Already Exist");
                    return View();
                }
            } 
            db.Image = filename;
            db.Name = UnudulmazlarCard.Name;
            db.Rutbe = UnudulmazlarCard.Rutbe;
            db.Haqqında = UnudulmazlarCard.Haqqında;
            db.Birthday = UnudulmazlarCard.Birthday;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            UnudulmazlarCard unudulmazlar = _context.UnudulmazlarCards.FirstOrDefault(c => c.Id == id);
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
            UnudulmazlarCard UnudulmazlarCard = _context.UnudulmazlarCards.Find(id);
            if (UnudulmazlarCard == null)
            {
                return NotFound();
            }
            return View(UnudulmazlarCard);
        }
    }
}
