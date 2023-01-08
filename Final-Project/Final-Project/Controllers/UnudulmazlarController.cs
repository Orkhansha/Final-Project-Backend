using Final_Project.Data;
using Final_Project.Helpers;
using Final_Project.Models;
using Final_Project.ViewModels;
using Final_Project.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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




        public async Task<IActionResult> Index(int page = 1, int take = 8)
        {
            List<UnudulmazlarCard> unudulmazlar = await _context.UnudulmazlarCards
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            ViewBag.take = take;

            List<UnudulmazlarListVM> mapDatas = GetMapDatas(unudulmazlar);

            int count = await GetPageCount(take);

            Paginate<UnudulmazlarListVM> result = new Paginate<UnudulmazlarListVM>(mapDatas, page, count);

            return View(result);
        }


        private async Task<int> GetPageCount(int take)
        {
            int Count = await _context.UnudulmazlarCards.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)Count / take);
        }

        private List<UnudulmazlarListVM> GetMapDatas(List<UnudulmazlarCard> unudulmazlar)
        {
            List<UnudulmazlarListVM> unudulmazlarList = new List<UnudulmazlarListVM>();

            foreach (var unudulmaz in unudulmazlar)
            {
                UnudulmazlarListVM newUnudulmaz = new UnudulmazlarListVM
                {
                    Id = unudulmaz.Id,
                    Name = unudulmaz.Name,
                    Surname = unudulmaz.Surname,
                    Rutbe= unudulmaz.Rutbe,
                    Haqqinda= unudulmaz.Haqqında,
                    Images = unudulmaz.Image,
                    //MainImage = unudulmaz.UnudulmazlarImages.Where(m => m.IsMain).FirstOrDefault()?.Image,
                    // CategoryName = product.Category.Name,
                    
                };

                unudulmazlarList.Add(newUnudulmaz);
            }

            return unudulmazlarList;
        }
        
        public IActionResult Search(string search)
        {
            List<UnudulmazlarCard> searchItem = _context.UnudulmazlarCards.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();
            return PartialView("_Search", searchItem);
        }
        public async Task<IActionResult> Details(int id)
        {
            UnudulmazlarVideo UnudulmazlarVideo = await _context.UnudulmazlarVideo.FirstOrDefaultAsync(x => x.Id == id);
            return View(UnudulmazlarVideo);
        }
        public async Task<IActionResult> Detail(int id)
        {
            UnudulmazlarCard unudulmazlarCard = await _context.UnudulmazlarCards.FirstOrDefaultAsync(x => x.Id == id);
            return View(unudulmazlarCard);
        }
    }
}
