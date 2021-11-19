using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TVTOWebsite.Models
{
    public class MDContent
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [StringLength(43000, MinimumLength = 10, ErrorMessage = "طول این فیلد حداقل 10 و حداکثر 43000 کاراکتر می‌باشد")]
        public string Content1 { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "طول این فیلد حداقل 3 و حداکثر 100 کاراکتر می‌باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "طول این فیلد حداقل 3 و حداکثر 500 کاراکتر می‌باشد")]
        public string Abstract { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "طول این فیلد حداقل 3 و حداکثر 50 کاراکتر می‌باشد")]
        public string Picture { get; set; }

    }

    [ModelMetadataType(typeof(MDContent))]
    public partial class Content
    {
    }
}
