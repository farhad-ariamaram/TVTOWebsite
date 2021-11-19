using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVTOWebsite.Models;

namespace TVTOWebsite.Pages
{
    public class MenuContentModel : PageModel
    {
        private readonly tvtoDBContext _context;

        public MenuContentModel(tvtoDBContext context)
        {
            _context = context;
        }

        public MenuContent currentMenuContent { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            currentMenuContent = await _context.MenuContents.FindAsync(Id);

            if(currentMenuContent == null)
            {
                return RedirectToPage("Error");
            }

            return Page();
        }
    }
}
