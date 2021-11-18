using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TVTOWebsite.Models;

namespace TVTOWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly tvtoDBContext _context;
        private IHostingEnvironment Environment;

        public IndexModel(tvtoDBContext context, IHostingEnvironment _environment)
        {
            _context = context;
            this.Environment = _environment;
        }

        public List<Content> lastTenContentList { get; set; }

        public List<string> sliderFiles { get; set; }

        public List<Content> lastFiveSelectedContentList { get; set; }

        public Multimedium multimedium { get; set; }

        public List<string> posterFiles { get; set; }

        public async Task OnGet()
        {
            lastTenContentList = await _context.Contents.OrderByDescending(a => a.Date).Take(10).ToListAsync();

            List<string> AbsSliderFiles = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "Uploads/Slider/")).ToList();
            if (AbsSliderFiles.Count > 0)
            {
                sliderFiles = new List<string>();
                int i = 0;
                foreach (var item in AbsSliderFiles)
                {
                    sliderFiles.Add(Path.GetFileName(item));
                    i++;
                }
            }

            lastFiveSelectedContentList = await _context.Contents.OrderByDescending(a => a.Date).Where(a=>a.IsSelected).Take(5).ToListAsync();

            multimedium = await _context.Multimedia.OrderByDescending(a=>a.Id).FirstOrDefaultAsync();

            List<string> AbsPosterFiles = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "Uploads/Poster/")).ToList();
            if (AbsPosterFiles.Count > 0)
            {
                posterFiles = new List<string>();
                int j = 0;
                foreach (var item in AbsPosterFiles)
                {
                    posterFiles.Add(Path.GetFileName(item));
                    j++;
                }
            }
        }
    }
}
