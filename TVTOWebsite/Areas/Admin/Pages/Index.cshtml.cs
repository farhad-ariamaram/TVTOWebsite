using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTOWebsite.Models;

namespace BMSWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly tvtoDBContext _context;

        public IndexModel(tvtoDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //var uid = HttpContext.Session.GetString("uid");
            //if (uid == null)
            //{
            //    return RedirectToPage("Login", new { area = "Admin" });
            //}
            return Page();
        }
    }
}
