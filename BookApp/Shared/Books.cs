using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Shared
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Excerpt { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
