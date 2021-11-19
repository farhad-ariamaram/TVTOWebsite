using System;
using System.Collections.Generic;

#nullable disable

namespace TVTOWebsite.Models
{
    public partial class Content
    {
        public int Id { get; set; }
        public string Content1 { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string Abstract { get; set; }
        public string Picture { get; set; }
        public bool IsSelected { get; set; }
        public string Category { get; set; }
    }
}
