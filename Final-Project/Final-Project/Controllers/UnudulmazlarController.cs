using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public class UnudulmazlarController : Controller
    {
        private readonly AppDbContext _context;

        public UnudulmazlarController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        //birinci action yaradiriq sonra views/sharedin icine bax orda _Search var sonra script.js filesinin icinde js kodlari var
        //ada gore axtaris edir , hemin adin detailine gedecek , detail actionunu da ozun yazarsan
        public IActionResult Search(string search)
        {
            List<UnudulmazlarCard> searchItem = _context.UnudulmazlarCards.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();
            return PartialView("_Search", searchItem);
        }

        public async Task<IActionResult> Detail(int id)
        {
            UnudulmazlarCard unudulmazlarCard = await _context.UnudulmazlarCards.FirstOrDefaultAsync(x => x.Id == id);
            return View(unudulmazlarCard);
        }
    }
}
