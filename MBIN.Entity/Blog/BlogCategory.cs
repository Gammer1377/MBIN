using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.Common;

namespace MBIN.Entity.Blog
{
    public class BlogCategory:BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ImageName { get; set; }
        public string ImageAlt { get; set; }
        public int Parent { get; set; }
        public bool Active { get; set; }
    }
}
