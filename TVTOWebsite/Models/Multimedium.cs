using System;
using System.Collections.Generic;

#nullable disable

namespace TVTOWebsite.Models
{
    public partial class Multimedium
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public string Music { get; set; }
        public string Movie { get; set; }
        public DateTime Date { get; set; }
    }
}
