using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BMSWebApp.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTOWebsite.Models;

namespace BMSWebApp.Pages
{
    public class LoginModel : PageModel
    {

        private readonly tvtoDBContext _context;

        public LoginModel(tvtoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "کد امنیتی را وارد کنید")]
        public string CaptchaCode { get; set; }

        public int RandomNo { get; set; }

        public IActionResult OnGet()
        {
            var uid = HttpContext.Session.GetString("uid");
            if (uid != null)
            {
                return RedirectToPage("Index", new { area = "Admin" });
            }

            RandomNo = new Random().Next(1, 15);

            return Page();
        }

        [BindProperty]
        public User user { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!Captcha.ValidateCaptchaCode(CaptchaCode, HttpContext))
                {
                    RandomNo = new Random().Next(1, 15);
                    ModelState.AddModelError("WrongCaptcha", "کد امنیتی اشتباه است");
                    return Page();
                }

                var u = _context.Users.Where(a => a.Username == user.Username && a.Password == user.Password).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("uid", user.Id + "");
                    return RedirectToPage("Index", new { area = "Admin" });
                }
                else
                {
                    RandomNo = new Random(1).Next(1, 10);
                    ModelState.AddModelError("WrongUser", "نام کاربری یا کلمه عبور اشتباه است");
                    return Page();
                }
            }
            RandomNo = new Random(1).Next(1, 10);
            return Page();
        }

    }

    public class CaptchaResult
    {
        public string CaptchaCode { get; set; }
        public byte[] CaptchaByteData { get; set; }
        public string CaptchBase64Data => Convert.ToBase64String(CaptchaByteData);
        public DateTime Timestamp { get; set; }
    }
}
