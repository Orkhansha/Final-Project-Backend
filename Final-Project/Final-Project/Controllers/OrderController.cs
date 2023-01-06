using Final_Project.Models;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Final_Project.Data;
using System.Linq;

namespace Final_Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            OrderVM model = new OrderVM
            {
                
                Username = user.UserName,
        
                BasketItems = _context.BasketItems.Include(b => b.Product).ThenInclude(p => p.ProductImages).Where(b => b.AppUserId == user.Id).ToList(),

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(OrderVM orderVM)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            OrderVM model = new OrderVM
            {
              
                Username = orderVM.Username,
                
                BasketItems = _context.BasketItems.Include(b => b.Product).ThenInclude(p=>p.ProductImages).Where(b => b.AppUserId == user.Id).ToList()
            };
            if (!ModelState.IsValid) return View(model);

             

            if (model.BasketItems.Count == 0) return RedirectToAction("index", "home");
            Order order = new Order
            {
                Country = orderVM.Country,
                Region = orderVM.Region,
                City = orderVM.City,
                Apartment = orderVM.Apartment,
                PostCode = orderVM.PostCode,
                Phone = orderVM.Phone,

                Address = orderVM.Address,
                TotalPrice = 0,
                Date = DateTime.Now,
                AppUserId = user.Id
            };

            foreach (BasketItem item in model.BasketItems)
            {
                order.TotalPrice +=   item.Count * item.Product.Price  ;
                OrderItem orderItem = new OrderItem
                {
                    Title = item.Product.Title,
                    Price =   item.Count * item.Product.Price  ,
                    AppUserId = user.Id,
                    ProductId = item.Product.Id,
                    Order = order
                };
                _context.OrderItems.Add(orderItem);
            }
            _context.BasketItems.RemoveRange(model.BasketItems);
            _context.Order.Add(order);
            _context.SaveChanges(); 

            return RedirectToAction("index", "home");
        }
    }
}
