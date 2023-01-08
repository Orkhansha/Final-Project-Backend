using Final_Project.Data;
using Final_Project.Models;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;

        public HeaderViewComponent(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                 
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                List<BasketItem> basketItem = _context.BasketItems.Include(b=>b.Product).Where(b => b.AppUserId == user.Id).ToList();
                
                if (basketItem.Count==0)
                {
                    ViewBag.BasketCount = 0;
                }
                else
                {

                ViewBag.BasketCount = basketItem.Count;
                }
                return View(await Task.FromResult(basketItem));
            }
            else
            {
                ViewBag.BasketCount = 0;
                return View(await Task.FromResult(ViewBag.BasketCount));

            }

        }
    }
}
