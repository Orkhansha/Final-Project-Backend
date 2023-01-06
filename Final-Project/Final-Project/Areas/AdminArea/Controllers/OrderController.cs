using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Order.Count() / 5);
            ViewBag.CurrentPage = page;
            List<Order> orders = _context.Order.Skip((page - 1) * 5).Take(5).ToList();
            return View(orders);
        }
       

        public IActionResult Edit(int id)
        {
            Order order = _context.Order.Include(o => o.OrderItems).Include(o => o.AppUser).FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
            
        }

        public async Task<IActionResult> Accept(int id, string message)
        {
            Order order = _context.Order.FirstOrDefault(o => o.Id == id);
            AppUser user = await _userManager.FindByIdAsync(order.AppUserId);
            if (order == null) return Json(new { status = 400 });
            order.Status = true;
            order.Message = message;

            _context.SaveChanges();
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("orkhansha@code.edu.az", "Military");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Order";

            string body = string.Empty;

            using (StreamReader reader = new StreamReader("wwwroot/Template/OrderMessage.html"))
            {
                body = reader.ReadToEnd();
            }
            string aboutText = $"{user.UserName}";
            string messageTxt = $"{message}";
            body = body.Replace("{{message}}", messageTxt);
            mail.Body = body.Replace("{{aboutText}}", aboutText);
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("orkhansha@code.edu.az", "mfeudepymigpmlij");
            smtp.Send(mail);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Reject(int id, string message)
        {
            Order order = _context.Order.FirstOrDefault(o => o.Id == id);
            AppUser user = await _userManager.FindByIdAsync(order.AppUserId);
            if (order == null) return Json(new { status = 400 });
            order.Status = false;
            order.Message = message;
            _context.SaveChanges();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("orkhansha@code.edu.az", "Military");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Order";

            string body = string.Empty;

            using (StreamReader reader = new StreamReader("wwwroot/Template/OrderMessage.html"))
            {
                body = reader.ReadToEnd();
            }
            string aboutText = $"{user.UserName}";
            string messageTxt = $"{message}";
            body = body.Replace("{{message}}", messageTxt);
            mail.Body = body.Replace("{{aboutText}}", aboutText);
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("orkhansha@code.edu.az", "mfeudepymigpmlij");
            smtp.Send(mail);
            return Json(new { status = 200 });
        }

    }
}
