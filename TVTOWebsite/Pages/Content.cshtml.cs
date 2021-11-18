using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTOWebsite.Models;

namespace TVTOWebsite.Pages
{
    public class ContentModel : PageModel
    {
        private readonly tvtoDBContext _context;

        public ContentModel(tvtoDBContext context)
        {
            _context = context;
        }

        public Content currentContent { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            currentContent = await _context.Contents.FindAsync(Id);

            if(currentContent == null)
            {
                return RedirectToPage("Error");
            }

            return Page();
        }
    }
}
