using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System;
using TVTOWebsite.Models;

namespace TVTOWebsite.Admin.Manage.Content1
{
    public class CreateModel : PageModel
    {
        private readonly tvtoDBContext _context;

        public CreateModel(tvtoDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                return RedirectToPage("../../Login", new { area = "Admin" });
            }

            return Page();
        }

        [BindProperty]
        public Content content { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            content.Date = DateTime.Now;
            _context.Contents.Add(content);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
