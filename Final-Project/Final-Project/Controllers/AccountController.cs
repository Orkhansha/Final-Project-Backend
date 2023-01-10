using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;
using System;
using Final_Project.ViewModels.AccountViewModels;
using Final_Project.Models;
using Final_Project.Helpers.Enums;
using System.IO;
using System.Net.Mail;
using System.Net;
using Final_Project.ViewModels;

namespace Final_Project.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        //private readonly IEmailService _emailService;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager
            //IEmailService emailService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            //_emailService = emailService;
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        #region
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser user = new AppUser
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();

            }

            await _userManager.AddToRoleAsync(user, Roless.User.ToString());
             
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string link = Url.Action(nameof(VerifyEmail), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("orkhansha@code.edu.az", "Military");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Verify Email";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/Template/verifyemail.html"))
            {
                body = reader.ReadToEnd();
            }
            string about = $"Hörmətli <strong>{user.UserName}</strong> , zəhmət olmasa hesabınızı təsdiqləmək üçün klik edin";

            body = body.Replace("{{link}}", link);
            mail.Body = body.Replace("{{About}}", about);
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("orkhansha@code.edu.az", "mfeudepymigpmlij");
            smtp.Send(mail);
            TempData["Verify"] = true;

            TempData["Fail"] = "Please go to gmail and confirm Email!";
            return RedirectToAction(nameof(Login));
        }
        #endregion
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            AppUser user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user is null)
            {
                user = await _userManager.FindByNameAsync(loginVM.Email);
            }

            if (user is null)
            {
                ModelState.AddModelError("", "Email or password wrong");
                return View(loginVM);
            }
            if (user.EmailConfirmed == false)
            {
                TempData["Fail"] = "Please go to gmail and confirm Email!";
                return RedirectToAction("login", "account");

            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or password wrong");
                return View(loginVM);
            }
            bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");


            if (isAdmin)
            {
                return RedirectToAction("Dashboard", "AdminArea");

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        //[Authorize(Roles = "Admin")]
        //public async Task CreateRoles()
        //{
        //    foreach (var role in Enum.GetValues(typeof(Roless)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(role.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        //        }
        //    }

        //}
        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();
            await _userManager.ConfirmEmailAsync(user, token);

            await _signInManager.SignInAsync(user, true);


            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(AccountVM account)
        {
            AppUser user = await _userManager.FindByEmailAsync(account.AppUser.Email);
            if (user == null) return BadRequest();
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action(nameof(ResetPassword), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("orkhansha@code.edu.az", "Military");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Reset Password";
            mail.Body = $"<a href='{link}'>Please click here to reset your password</a>";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("orkhansha@code.edu.az", "mfeudepymigpmlij");
            smtp.Send(mail);
            return RedirectToAction("index", "home");
        }


         

        public async Task<IActionResult> ResetPassword(string Email, string token)
        {
            AppUser user = await _userManager.FindByEmailAsync(Email);
            if (user == null) return BadRequest();
            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(AccountVM account)
        {
            AppUser user = await _userManager.FindByEmailAsync(account.AppUser.Email);
            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = account.Token
            };
            if (!ModelState.IsValid) return View(model);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, account.Token, account.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);

            }
            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
        }

    }
}
